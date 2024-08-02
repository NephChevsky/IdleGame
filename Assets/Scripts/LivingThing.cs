using UnityEditor.Experimental.GraphView;
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

    public void Move()
    {
        Vector3 direction = Vector3.left;
        if (this is Player)
        {
            direction = Vector3.right;
        }
        transform.localPosition += (MovementSpeed / 4f) * Time.fixedDeltaTime * Settings.Time.GameSpeed * direction;
    }
}
