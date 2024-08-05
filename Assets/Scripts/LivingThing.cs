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
        Vector3 direction = this is Player ? Vector3.right : Vector3.left;
        RectTransform gameEnginePanelRT = transform.parent.GetComponent<RectTransform>();
        float distance = MovementSpeed * Time.fixedDeltaTime * Settings.Time.GameSpeed;
        float posX = transform.localPosition.x + distance * direction.x;
        posX = Mathf.Clamp(posX, gameEnginePanelRT.rect.width * (-0.5f + Settings.Global.GameUIBorderRatio), gameEnginePanelRT.rect.width * (0.5f - Settings.Global.GameUIBorderRatio));
        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
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
        //Debug.DrawRay(transform.position, direction * range);
        if (GetComponent<Collider2D>().Raycast(direction, hits, range) != 0)
        {
            if (hits[0].collider.gameObject.CompareTag(opponentTag))
            {
                return hits[0].collider.gameObject;
            }
        }
        return null;
    }
}
