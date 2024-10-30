using UnityEngine;
using UnityEngine.UI;

public class ArmoryHandler : MonoBehaviour
{
    public GameObject ItemSlotPrefab;

    private GameObject Helm;
    private GameObject Amulet;
	private GameObject Gloves;
	private GameObject Chest;
    private GameObject RingL;
    private GameObject Belt;
    private GameObject RingR;
    private GameObject Pants;
    private GameObject Boots;
    private GameObject MainHand;
    private GameObject OffHand;

    void Start()
    {
		Image panel = GetComponentInChildren<Image>();

		Helm = Instantiate(ItemSlotPrefab);
		Amulet = Instantiate(ItemSlotPrefab);
		Gloves = Instantiate(ItemSlotPrefab);
		Chest = Instantiate(ItemSlotPrefab);
		RingL = Instantiate(ItemSlotPrefab);
		Belt = Instantiate(ItemSlotPrefab);
		RingR = Instantiate(ItemSlotPrefab);
		Pants = Instantiate(ItemSlotPrefab);
		Boots = Instantiate(ItemSlotPrefab);
		MainHand = Instantiate(ItemSlotPrefab);
		OffHand = Instantiate(ItemSlotPrefab);

		Helm.name = "Helm";
		Amulet.name = "Amulet";
		Gloves.name = "Gloves";
		Chest.name = "Chest";
		RingL.name = "RingL";
		Belt.name = "Belt";
		RingR.name = "RingR";
		Pants.name = "Pants";
		Boots.name = "Boots";
		MainHand.name = "MainHand";
		OffHand.name = "OffHand";

		Helm.transform.SetParent(panel.transform);
		Amulet.transform.SetParent(panel.transform);
		Gloves.transform.SetParent(panel.transform);
		Chest.transform.SetParent(panel.transform);
		RingL.transform.SetParent(panel.transform);
		Belt.transform.SetParent(panel.transform);
		RingR.transform.SetParent(panel.transform);
		Pants.transform.SetParent(panel.transform);
		Boots.transform.SetParent(panel.transform);
		MainHand.transform.SetParent(panel.transform);
		OffHand.transform.SetParent(panel.transform);

		Helm.transform.localScale = Vector3.one;
		Amulet.transform.localScale = Vector3.one;
		Gloves.transform.localScale = Vector3.one;
		Chest.transform.localScale = Vector3.one;
		RingL.transform.localScale = Vector3.one;
		Belt.transform.localScale = Vector3.one;
		RingR.transform.localScale = Vector3.one;
		Pants.transform.localScale = Vector3.one;
		Boots.transform.localScale = Vector3.one;
		MainHand.transform.localScale = Vector3.one;
		OffHand.transform.localScale = Vector3.one;

		ResizeUI();
	}

    void Update()
    {
		ResizeUI();
    }

	private float GetItemSlotSize(float height)
	{
		return height / 4.5f;
	}

    public float GetWidth(float height)
    {
		float itemSlotHeight = GetItemSlotSize(height);
		return itemSlotHeight * 3;
    }

	void ResizeUI()
	{
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();
		float standardItemSize = GetItemSlotSize(rt.rect.height);

		RectTransform helmRT = Helm.GetComponent<RectTransform>();
		helmRT.sizeDelta = new Vector2(standardItemSize, standardItemSize);
		Helm.transform.localPosition = new Vector2(0, rt.rect.height / 2 - standardItemSize / 2);

		RectTransform amuletRT = Amulet.GetComponent<RectTransform>();
		amuletRT.sizeDelta = new Vector2(standardItemSize / 2, standardItemSize / 2);
		Amulet.transform.localPosition = new Vector2(rt.rect.width / 2 - standardItemSize / 2, rt.rect.height / 2 - standardItemSize);

		RectTransform glovesRT = Gloves.GetComponent<RectTransform>();
		glovesRT.sizeDelta = new Vector2(standardItemSize / 2, standardItemSize);
		Gloves.transform.localPosition = new Vector2(-rt.rect.width / 2 + standardItemSize / 2, rt.rect.height / 2 - standardItemSize * 1.5f);

		RectTransform chestRT = Chest.GetComponent<RectTransform>();
		chestRT.sizeDelta = new Vector2(standardItemSize, standardItemSize);
		Chest.transform.localPosition = new Vector2(0, rt.rect.height / 2 - standardItemSize * 1.5f);

		RectTransform ringLRT = RingL.GetComponent<RectTransform>();
		ringLRT.sizeDelta = new Vector2(standardItemSize / 2, standardItemSize / 2);
		RingL.transform.localPosition = new Vector2(-rt.rect.width / 2 + standardItemSize / 2, 0);

		RectTransform beltRT = Belt.GetComponent<RectTransform>();
		beltRT.sizeDelta = new Vector2(standardItemSize, standardItemSize / 2f);
		Belt.transform.localPosition = new Vector2(0, 0);

		RectTransform ringRRT = RingR.GetComponent<RectTransform>();
		ringRRT.sizeDelta = new Vector2(standardItemSize / 2, standardItemSize / 2);
		RingR.transform.localPosition = new Vector2(rt.rect.width / 2 - standardItemSize / 2, 0);

		RectTransform pantsRT = Pants.GetComponent<RectTransform>();
		pantsRT.sizeDelta = new Vector2(standardItemSize, standardItemSize);
		Pants.transform.localPosition = new Vector2(0, -rt.rect.height / 2 + standardItemSize * 1.5f);

		RectTransform bootsRT = Boots.GetComponent<RectTransform>();
		bootsRT.sizeDelta = new Vector2(standardItemSize, standardItemSize);
		Boots.transform.localPosition = new Vector2(0, -rt.rect.height / 2 + standardItemSize / 2);

		RectTransform mainHandRT = MainHand.GetComponent<RectTransform>();
		mainHandRT.sizeDelta = new Vector2(standardItemSize, standardItemSize * 2);
		MainHand.transform.localPosition = new Vector2(-rt.rect.width / 2 + standardItemSize / 2, -rt.rect.height / 2 + standardItemSize);

		RectTransform offHandRT = OffHand.GetComponent<RectTransform>();
		offHandRT.sizeDelta = new Vector2(standardItemSize, standardItemSize * 2);
		OffHand.transform.localPosition = new Vector2(rt.rect.width / 2 - standardItemSize / 2, -rt.rect.height / 2 + standardItemSize);
	}
}
