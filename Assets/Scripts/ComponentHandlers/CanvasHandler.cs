using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    public GameObject MenuPrefab;
    public GameObject GameUIPrefab;
    public GameObject InventoryPrefab;

    private GameObject Menu;
	private GameObject Game;
	private GameObject Inventory;

    void Start()
    {
        Menu = Instantiate(MenuPrefab);
        Menu.transform.SetParent(transform);
        Menu.transform.localScale = Vector3.one;

		Game = Instantiate(GameUIPrefab);
		Game.transform.SetParent(transform);
		Game.transform.localScale = Vector3.one;

		Inventory = Instantiate(InventoryPrefab);
        Inventory.transform.SetParent(transform);
        Inventory.transform.localScale = Vector3.one;

		ResizeUI();
    }

    void Update()
    {
		ResizeUI();
	}

    void ResizeUI()
    {
        RectTransform rt = GetComponent<RectTransform>();

        RectTransform menuRT = Menu.GetComponent<RectTransform>();
        float menuWidth = rt.rect.height * Settings.UI.Menu.WidthRatio;
        float menuHeight = rt.rect.height;
		menuRT.sizeDelta = new Vector2(menuWidth, menuHeight);
        Menu.transform.localPosition = new Vector2( -rt.rect.width / 2 + menuWidth / 2, 0);

		RectTransform gameRT = Game.GetComponent<RectTransform>();
        float gameWidth = (rt.rect.height / 2) * Settings.UI.Game.PanelRatio;
		float maxGameWidth = rt.rect.width - menuWidth;
		if (gameWidth > maxGameWidth)
		{
			gameWidth = maxGameWidth;
		}
		float gameHeight = gameWidth / Settings.UI.Game.PanelRatio;
		gameRT.sizeDelta = new Vector2(gameWidth, gameHeight);
		Game.transform.localPosition = new Vector2(menuRT.rect.width / 2, rt.rect.height / 4);

		RectTransform inventoryRT = Inventory.GetComponent<RectTransform>();
		float inventoryWidth = rt.rect.width - menuRT.rect.width;
		float inventoryHeight = rt.rect.height / 2;
		inventoryRT.sizeDelta = new Vector2(inventoryWidth, inventoryHeight);
		Inventory.transform.localPosition = new Vector2(menuWidth / 2, - rt.rect.height / 4);
	}
}
