using Assets.Scripts.Classes;
using UnityEngine;

public class ItemTooltipHandler : MonoBehaviour
{
    public static ItemTooltipHandler _instance;
    public Canvas Canvas;

	private void Awake()
	{
		if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
	}

	void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
		
	}

    void Update()
    {
        UpdatePosition();
    }

    public void SetAndShowTooltip(Item item)
    {
		transform.SetAsLastSibling();
        UpdatePosition();
		gameObject.SetActive(true);
    }

	public void HideTooltip()
	{
		gameObject.SetActive(false);
	}

    private void UpdatePosition()
    {
		RectTransform canvasRT = Canvas.GetComponent<RectTransform>();
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRT, Input.mousePosition, Camera.main, out Vector2 localPoint);
		RectTransform rt = GetComponent<RectTransform>();
		Vector3 localPoint3D = new Vector3(localPoint.x + rt.rect.width / 2, localPoint.y + rt.rect.height / 2, 10);
		transform.localPosition = localPoint3D;
	}
}
