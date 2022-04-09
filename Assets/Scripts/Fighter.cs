using UnityEngine;


/// <summary>
/// Основной класс, вызова Урона
/// </summary>
public class Fighter : MonoBehaviour
{
    public int hitPoint = 3;
    public int maxHitpoint = 10;
    public float pushRecoverSpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg) {
        if (Time.time - lastImmune > immuneTime) {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.up * 10, 1f);
            if (hitPoint <= 0) {
                hitPoint = 0;
                Death();
            }
        }
    
    }

    protected virtual void Death() { 
    
    }
}
