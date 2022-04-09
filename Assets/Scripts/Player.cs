using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс Игрока
/// </summary>
public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;

    protected override void Start()
    {
        base.Start();
        maxHitpoint = 6;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
            return;


        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }
    protected override void Death()
    {
        isAlive = false;
        base.Death();
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }



    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (isAlive)
        {
            UpdateMotor(new Vector3(x, y, 0));
        }

        // TODO //
        if (Input.GetKeyDown(KeyCode.U)){
            Debug.Log("Delet All Save");
            PlayerPrefs.DeleteAll();
        }
    }

    public void SwapSprite(int skinID) {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinID];
    }


    public void OnLevelUp() {
        maxHitpoint++;
        hitPoint = maxHitpoint;
    }
    public void SetLevel(int level) {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Heal(int healingAmount){
        if (hitPoint == maxHitpoint)
            return;

        hitPoint += healingAmount;
        if (hitPoint > maxHitpoint)
        {
            hitPoint = maxHitpoint;
        }
        GameManager.instance.ShowText("+" + healingAmount.ToString() + " hp", 25, Color.green, transform.position, Vector3.up * 30, 1f);
        GameManager.instance.OnHitPointChange();
    }


    public void Respawn() {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }



}
