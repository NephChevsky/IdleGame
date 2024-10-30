using UnityEngine;
using UnityEngine.UI;

public class InventoryTabHandler : MonoBehaviour
{
    public GameObject ArmoryPrefab;
	public GameObject InventoryPrefab;

    private GameObject Armory;
	private GameObject Inventory;

	void Start()
    {
		Image panel = GetComponentInChildren<Image>();

		Armory = Instantiate(ArmoryPrefab);
		Armory.transform.SetParent(panel.transform);
		Armory.transform.localScale = Vector3.one;

		Inventory = Instantiate(InventoryPrefab);
		Inventory.transform.SetParent(panel.transform);
		Inventory.transform.localScale = Vector3.one;
		InventoryHandler inventoryScript = Inventory.GetComponentInChildren<InventoryHandler>();
		inventoryScript.Rows = 5;
		inventoryScript.Columns = 10;

		ResizeUI();
	}

    void Update()
    {
        ResizeUI();   
    }

    void ResizeUI()
    {
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();

		RectTransform armoryRT = Armory.GetComponent<RectTransform>();
		float armoryHeight = rt.rect.height;
		float armoryWidth = Armory.GetComponent<ArmoryHandler>().GetWidth(armoryHeight);
		armoryRT.sizeDelta = new Vector2(armoryWidth, armoryHeight);
		Armory.transform.localPosition = new Vector2(-rt.rect.width / 2 + armoryWidth / 2, 0);

		RectTransform inventoryRT = Inventory.GetComponent<RectTransform>();
		InventoryHandler inventoryScript = Inventory.GetComponent<InventoryHandler>();
		float inventoryWidth = inventoryScript.GetWidth(rt.rect.height);
		float maxInventoryWidth = rt.rect.width - armoryWidth;
		if (inventoryWidth > maxInventoryWidth)
		{
			inventoryWidth = maxInventoryWidth;
		}
		float inventoryHeight = inventoryScript.GetHeight(inventoryWidth);
		inventoryRT.sizeDelta = new Vector2(inventoryWidth, inventoryHeight);
		Inventory.transform.localPosition = new Vector2(-rt.rect.width / 2 + armoryWidth + inventoryWidth / 2, 0);
	}
}
