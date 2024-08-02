using UnityEngine;

public class LivingThing : MonoBehaviour
{
    public float CurrentHP;
    public float MaxHP;
    public float MovementSpeed;
    public float BaseAttack;
    public float BaseAttackSpeed;
    public float Range;
    public float AttackTimer;

    private bool Moving = true;

    public void Move()
    {
        if (Moving)
        {
            Vector3 direction = this is Player ? Vector3.right : Vector3.left;
            float distance = (MovementSpeed / 200f) * Time.fixedDeltaTime * Settings.Time.GameSpeed;
            Vector3 newPosition = transform.position + distance * direction;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.MovePosition(newPosition);
        }
    }

    public bool Attack(LivingThing opponent)
    {
        opponent.CurrentHP -= BaseAttack;
        if (opponent.CurrentHP <= 0)
        {
            opponent.CurrentHP = 0;
            return true;
        }
        return false;
    }

    public GameObject GetReachableOpponent()
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];
        Vector3 direction = this is Player ? Vector3.right : Vector3.left;
        string opponentTag = this is Player ? "Enemy" : "Player";
        float range = (Range / 2f) * transform.GetComponent<RectTransform>().rect.width / transform.parent.GetComponent<RectTransform>().rect.width;
        Debug.DrawRay(transform.position, direction * range);
        if (GetComponent<Collider2D>().Raycast(direction, hits, range) != 0)
        {
            if (hits[0].collider.gameObject.CompareTag(opponentTag))
            {
                return hits[0].collider.gameObject;
            }
        }
        return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Moving = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Moving = true;
    }
}
