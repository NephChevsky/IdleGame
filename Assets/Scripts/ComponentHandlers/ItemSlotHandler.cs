using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item Item;

    void Start()
    {
        
    }

    void Update()
    {
		if (Item != null)
        {
			Image image = GetComponentInChildren<Image>();
			image.color = new Color(0.6f, 0.6f, 0.6f);
		}
    }

	void OnMouseEnter()
	{
        
	}

	void OnMouseExit()
	{
        
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ItemTooltipHandler._instance.SetAndShowTooltip(Item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ItemTooltipHandler._instance.HideTooltip();
	}
}
