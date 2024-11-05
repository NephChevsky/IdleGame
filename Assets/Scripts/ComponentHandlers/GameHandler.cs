using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject LivingThingPrefab;
	public GameObject Map;

    private GameObject Player;
	private List<GameObject> Mobs = new();

    void Start()
    {
		SpawnAndDeSpawn();
		ResizeUI();
	}

    void Update()
    {
		SpawnAndDeSpawn();
		UpdateHP();
		ResizeUI();
    }

	void SpawnAndDeSpawn()
	{
		if (Player == null)
		{
			Player = InstantiateLivingThing();
			Player.GetComponent<LivingThingHandler>().IsPlayer = true;
		}

		for (int i = 0; i < Mobs.Count; i++)
		{
			int id = int.Parse(Mobs[i].name.Split(" ")[1]);
			Mob mob = GameEngine.Map.SpawnedMobs.Where(x => x.Id == id).FirstOrDefault();
			if (mob == null)
			{
				Destroy(Mobs[i]);
				Mobs.RemoveAt(i);
				i--;
			}
		}

		foreach (Mob mob in GameEngine.Map.SpawnedMobs)
		{
			GameObject mobGameObject = Mobs.Where(x => x.name == $"Mob {mob.Id}").FirstOrDefault();
			if (mobGameObject == null)
			{
				mobGameObject = InstantiateLivingThing();
				mobGameObject.name = $"Mob {mob.Id}";
				mobGameObject.tag = "Mob";
				Mobs.Add(mobGameObject);
			}
		}
	}

	GameObject InstantiateLivingThing()
	{
		Image panel = GetComponentInChildren<Image>();

		GameObject gameObject = Instantiate(LivingThingPrefab);
		gameObject.transform.SetParent(panel.transform);
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	void UpdateHP()
	{
		float hpRatio = GameEngine.Player.CurrentHP / GameEngine.Player.MaxHP;
		Player.GetComponent<LivingThingHandler>().LifeRatio = hpRatio;

		foreach (GameObject mobGameObject in Mobs)
		{
			int currentId = int.Parse(mobGameObject.name.Split(" ")[1]);
			Mob mob = GameEngine.Map.SpawnedMobs.Where(x => x.Id == currentId).First();
			hpRatio = mob.CurrentHP / mob.MaxHP;
			mobGameObject.GetComponent<LivingThingHandler>().LifeRatio = hpRatio;
		}
	}

	void ResizeUI()
    {
		RectTransform rt = Map.GetComponent<RectTransform>();

		RectTransform playerRT = Player.GetComponent<RectTransform>();
		float playerHeight = rt.rect.height / 5f;
		float playerWidth = playerHeight / 2f;
		playerRT.sizeDelta = new Vector2(playerWidth, playerHeight);
		Player.transform.localPosition = new Vector2(-(rt.rect.width - (playerWidth / 2)) / 2 + GameEngine.Player.Position * (rt.rect.width - (playerWidth / 2)) / Settings.Engine.MapLength, -playerHeight / 2);

		foreach (Mob mob in GameEngine.Map.SpawnedMobs)
		{
			GameObject mobGameObject = Mobs.Where(x => x.name == $"Mob {mob.Id}").FirstOrDefault();
			RectTransform mobRT = mobGameObject.GetComponent<RectTransform>();
			float mobHeight = rt.rect.height / 5f;
			float mobWidth = mobHeight / 2f;
			mobRT.sizeDelta = new Vector2(mobWidth, mobHeight);
			mobGameObject.transform.localPosition = new Vector2(-(rt.rect.width - (mobWidth / 2)) / 2 + mob.Position * (rt.rect.width - (mobWidth / 2)) / Settings.Engine.MapLength, -mobHeight / 2);
		}
	}
}
