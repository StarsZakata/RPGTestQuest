using UnityEngine;

/// <summary>
/// Класс, для описания поведения Противника 
/// </summary>
public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 1;
    public float chaseLength = 5;
    private bool chasing;
    private bool collideringWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;


    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];


    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();

    }

    protected void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength) {
                chasing = true;
            }
            if (chasing)
            {
                if (!collideringWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collideringWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            if (hits[i].name == "Fighter" && hits[i].name == "Player") {
                hits[i].gameObject.GetComponent<Player>().Heal(-1);
                collideringWithPlayer = true;  
            }

            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrandXp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }

}

