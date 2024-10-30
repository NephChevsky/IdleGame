using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    public int Rows;
    public int Columns;

    public GameObject ItemSlotPrefab;

    private List<GameObject> Inventory = new();

    void Start()
    {
		Image panel = GetComponentInChildren<Image>();

		for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                GameObject item = Instantiate(ItemSlotPrefab);
				item.transform.SetParent(panel.transform);
				item.transform.localScale = Vector3.one;
                item.name = $"Item{row * Columns + column}";
                Inventory.Add(item);
			}
        }

        ResizeUI();
	}

    void Update()
    {
        ResizeUI();
	}

	private float GetItemSlotHeight(float height)
	{
		return height / Rows;
	}

	private float GetItemSlotWidth(float height)
	{
		return height / Columns;
	}

	public float GetWidth(float height)
	{
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();
		float itemSlotHeight = GetItemSlotHeight(height - rt.offsetMin.x * 2);
		return itemSlotHeight * Columns + rt.offsetMin.x * 2;
	}

	public float GetHeight(float width)
	{
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();
		float itemSlotwidth = GetItemSlotWidth(width - rt.offsetMin.x * 2);
		return itemSlotwidth * Rows + rt.offsetMin.x * 2;
	}

	void ResizeUI()
    {
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();
		float standardItemSize = GetItemSlotHeight(rt.rect.height);

		int column = 0;
		int row = 0;
		foreach (GameObject item in Inventory)
        {
			RectTransform itemRT = item.GetComponent<RectTransform>();
			itemRT.sizeDelta = new Vector2(standardItemSize, standardItemSize);
			item.transform.localPosition = new Vector2(-rt.rect.width / 2 + (column + 0.5f) * standardItemSize, rt.rect.height / 2 - (row + 0.5f) * standardItemSize);
			column++;
			if (column >= Columns)
			{
				column = 0;
				row++;
			}
		}
    }
}
