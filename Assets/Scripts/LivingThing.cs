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
        float distance = MovementSpeed * Time.fixedDeltaTime * Settings.Time.GameSpeed * gameEnginePanelRT.rect.width / 1200f;
        float posX = transform.localPosition.x + distance * direction.x;
        posX = Mathf.Clamp(posX, gameEnginePanelRT.rect.width * (-0.5f + Settings.Global.GameUIBorderRatio), gameEnginePanelRT.rect.width * (0.5f - Settings.Global.GameUIBorderRatio));
        Vector3 localRayEndpoint = new(posX + direction.x * GetComponent<RectTransform>().rect.width / 2f, transform.localPosition.y, transform.localPosition.z);
        Vector3 worldRayEndpoint = transform.parent.TransformPoint(localRayEndpoint);
        RaycastHit2D[] hits = new RaycastHit2D[1];
        Debug.DrawRay(transform.position, worldRayEndpoint - transform.position, Color.red);
        if (GetComponent<CapsuleCollider2D>().Raycast(direction, hits, Mathf.Abs((worldRayEndpoint - transform.position).x)) == 0)
        {
            transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
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

    public void ResetPosition()
    {
        RectTransform gameEnginePanelRT = transform.parent.GetComponent<RectTransform>();
        RectTransform playerRT = GetComponent<RectTransform>();
        float initialPosition = this is Player ? -1f : 1f;
        transform.localPosition = new Vector2(initialPosition * (0.5f - Settings.Global.GameUIBorderRatio) * gameEnginePanelRT.rect.width, -playerRT.rect.height / 2);
    }
}
