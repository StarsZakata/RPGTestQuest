using UnityEngine;


/// <summary>
/// Класс оружия в руках игрока и нанесения урона врагам
/// </summary>
public class Weapon : Collidable
{
    public int[] damagePoint = {1, 2, 3, 4, 5, 6, 7 };
    public float[] pushForce = { 2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4f};

    public int weaponLevel = 0;
    public SpriteRenderer spriteRender;

    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;


    protected override void Start()
    {
        base.Start();
        //spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Time.time - lastSwing > cooldown) {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag == "Fighter") {
            // TODO
            if (col.name == "Player") {
                return;
            }
            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };
            col.SendMessage("ReceiveDamage", dmg);

            //Debug.Log(col.name);
        }
    }


    private void Swing() {
        anim.SetTrigger("Swing");
    }


    public void UpgrateWeapon() {
        weaponLevel++;
        spriteRender.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level) {
        weaponLevel = level;
        spriteRender.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
