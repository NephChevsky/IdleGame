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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Moving = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Moving = true;
    }
}
