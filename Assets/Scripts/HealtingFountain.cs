using UnityEngine;

/// <summary>
/// Взаимодействие с фонтаном 
/// </summary>
public class HealtingFountain : Collidable
{
    public int healingAmoubt = 1;

    private float healCooldown = 1.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D col)
    {
        if (col.name != "Player") {
            return;
        }

        if (Time.time - lastHeal > healCooldown) {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmoubt);
        }
    }


}
