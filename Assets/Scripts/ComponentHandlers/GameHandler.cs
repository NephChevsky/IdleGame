using System;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject LivingThingPrefab;

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
		RectTransform rt = GetComponentInChildren<Image>().GetComponent<RectTransform>();

		RectTransform playerRT = Player.GetComponent<RectTransform>();
		float playerHeight = rt.rect.height / 5f;
		float playerWidth = playerHeight / 2f;
		playerRT.sizeDelta = new Vector2(playerWidth, playerHeight);
		Player.transform.localPosition = new Vector2(-rt.rect.width / 2 + rt.rect.width * 0.02f + GameEngine.Player.Position * rt.rect.width / Settings.Engine.MapLength + playerWidth / 2, -playerHeight / 2);
	}
}
