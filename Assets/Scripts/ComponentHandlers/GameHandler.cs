using System;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject LivingThingPrefab;
	public GameObject Map;

    private GameObject Player;

    void Start()
    {
		Image panel = GetComponentInChildren<Image>();

		Player = Instantiate(LivingThingPrefab);
		Player.transform.SetParent(panel.transform);
		Player.transform.localScale = Vector3.one;

        ResizeUI();
	}

    void Update()
    {
        ResizeUI();
    }

    void ResizeUI()
    {
		RectTransform rt = Map.GetComponent<RectTransform>();

		RectTransform playerRT = Player.GetComponent<RectTransform>();
		float playerHeight = rt.rect.height / 5f;
		float playerWidth = playerHeight / 2f;
		playerRT.sizeDelta = new Vector2(playerWidth, playerHeight);
		Player.transform.localPosition = new Vector2(-(rt.rect.width - (playerWidth / 2))/ 2 + GameEngine.Player.Position * (rt.rect.width - (playerWidth / 2)) / Settings.Engine.MapLength, -playerHeight / 2);
	}
}
