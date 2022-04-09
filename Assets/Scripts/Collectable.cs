using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D col)
    {
        if (col.name == "Player") {
            OnCollect();
        }
    }

    protected virtual void OnCollect() {
        collected = true;
    }
}
