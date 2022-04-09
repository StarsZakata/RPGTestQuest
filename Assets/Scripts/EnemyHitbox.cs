using UnityEngine;


/// <summary>
/// Столкновение с противником
/// </summary>
public class EnemyHitbox : Collidable
{
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag == "Figther") {
            Debug.Log("Col");
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            col.SendMessage("ReceiveDamage", dmg);
        }
    }
}
