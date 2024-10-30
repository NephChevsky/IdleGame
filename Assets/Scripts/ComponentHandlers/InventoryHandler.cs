using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject ArmoryPrefab;

    private GameObject Armory;

    void Start()
    {
		Armory = Instantiate(ArmoryPrefab);
		Armory.transform.SetParent(transform);
		Armory.transform.localScale = Vector3.one;

        ResizeUI();
	}

    void Update()
    {
        ResizeUI();   
    }

    void ResizeUI()
    {
		RectTransform rt = GetComponent<RectTransform>();

		RectTransform armoryRT = Armory.GetComponent<RectTransform>();
		float armoryHeight = rt.rect.height;
		float armoryWidth = Armory.GetComponentInChildren<ArmoryHandler>().GetWidth(armoryHeight);
		armoryRT.sizeDelta = new Vector2(armoryWidth, armoryHeight);
		Armory.transform.localPosition = new Vector2(-rt.rect.width / 2 + armoryWidth / 2, 0);
	}
}
