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
        RectTransform gameEnginePanelRT = transform.parent.GetComponent<RectTransform>();
        float gameEnginePanelWidth = gameEnginePanelRT.rect.width;
        Vector3 newPosition = transform.localPosition + (MovementSpeed / 4f) * Time.fixedDeltaTime * Settings.Time.GameSpeed * direction;
        transform.localPosition = new Vector3(Mathf.Clamp(newPosition.x, -(0.5f - Settings.Global.GameUIBorderRatio) * gameEnginePanelWidth, (0.5f - Settings.Global.GameUIBorderRatio) * gameEnginePanelWidth), newPosition.y, newPosition.z);
    }
}
