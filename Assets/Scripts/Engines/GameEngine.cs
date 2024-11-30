using Assets.Scripts.Classes;
using Assets.Scripts.Engines;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameEngine
{
	public static Player Player;
	public static Map Map;
	public static List<Item> Inventory { get; set; }

	public static float SpawnTimer = 1f;
	public static float SaveTimer = 0f;

	public static void Init()
	{
		if (PlayerPrefs.HasKey("PlayerLevel"))
		{
			Player = new(PlayerPrefs.GetInt("PlayerLevel"));
		}
		else
		{
			Player = new Player(1);
		}

		if (PlayerPrefs.HasKey("MapLevel"))
		{
			Map = MapGenerator.Generate(PlayerPrefs.GetInt("MapLevel"));
		}
		else
		{
			Map = MapGenerator.Generate(1);
		}

		if (PlayerPrefs.HasKey("Inventory"))
		{
			string json = PlayerPrefs.GetString("Inventory");
			Inventory = JsonConvert.DeserializeObject<List<Item>>(json);
		}
		else
		{
			Inventory = new();
		}
		InitMap();
	}

	public static void Advance(float elapsedTime)
	{
		float time = 0;
		while (time < elapsedTime * Settings.Engine.GameSpeed)
		{
			time += Settings.Engine.TickTime;

			if (Player.CurrentHP <= 0 || (Map.SpawnedMobs.Count == 0 && Map.MobsToSpawn.Count == 0))
			{
				int nextMapLevel = Map.Level;
				if (Map.SpawnedMobs.Count == 0 && Map.MobsToSpawn.Count == 0)
				{
					nextMapLevel++;
				}
				Map = MapGenerator.Generate(nextMapLevel);
				InitMap();
			}

			SpawnTimer += Settings.Engine.TickTime;
			if (SpawnTimer >= 1f && Map.MobsToSpawn.Count > 0)
			{
				Map.SpawnedMobs.Add(Map.MobsToSpawn[0]);
				Map.MobsToSpawn.RemoveAt(0);
				SpawnTimer -= 1f;
			}

			Move(Player);

			foreach (Mob mob in Map.SpawnedMobs)
			{
				Move(mob);
			}

			Player.AttackTimer += Settings.Engine.TickTime;
			if (Player.AttackTimer > 1f)
			{
				Mob mob = FindClosestEnemy(Player) as Mob;
				if (mob != null)
				{
					if (Attack(Player, mob))
					{
						bool drop = Random.Range(0f, 1f) >= 0.95f;
						if (drop && Inventory.Count < 50)
						{
							Item item = ItemEngine.Generate();
							Inventory.Add(item);
						}
						int id = mob.Id;
						Map.SpawnedMobs.RemoveAll(x => x.Id == id);
						Player.CurrentXP += mob.XP;
						if (Player.CurrentXP >= Player.MaxXP)
						{
							Player.LevelUp();
						}
					}
					Player.AttackTimer = 0f;
				}
			}

			foreach (Mob mob in Map.SpawnedMobs)
			{
				mob.AttackTimer += Settings.Engine.TickTime;
				if (mob.AttackTimer > 1f)
				{
					LivingThing thing = FindClosestEnemy(mob);
					if (thing != null)
					{
						mob.AttackTimer = 0f;
						if (Attack(mob, thing))
						{
							break;
						}
					}
				}
			}
		}

		SaveTimer += elapsedTime;
		if (SaveTimer > 30f)
		{
			SaveTimer = 0f;
			PlayerPrefs.SetInt("PlayerLevel", Player.Level);
			PlayerPrefs.SetInt("MapLevel", Map.Level);
			string json = JsonConvert.SerializeObject(Inventory);
			PlayerPrefs.SetString("Inventory", json);
		}
	}

	private static void InitMap()
	{
		Player.Position = 0;
		Player.AttackTimer = 0f;
		Player.CurrentHP = Player.MaxHP;
		SpawnTimer = 0f;
	}

	private static LivingThing FindClosestEnemy(LivingThing thing)
	{
		if (thing is Player && Map.SpawnedMobs.Count > 0 && Map.SpawnedMobs[0].Position < Player.Position + Player.AttackRange)
		{
			return Map.SpawnedMobs[0];
		}
		else if (thing is Mob && Player.Position > thing.Position - thing.AttackRange)
		{
			return Player;
		}
		return null;
	}

	private static bool Attack(LivingThing attacker, LivingThing defender)
	{
		defender.CurrentHP -= attacker.BaseAttack;
		if (defender.CurrentHP <= 0)
		{
			return true;
		}
		return false;
	}

	private static void Move(LivingThing thing)
	{
		int direction = -1;
		int currentEnemyId = -1;
		if (thing is Player)
		{
			direction = 1;
		}
		else
		{
			currentEnemyId = (thing as Mob).Id;
		}
		int newPosition = thing.Position + Mathf.RoundToInt(Settings.Engine.TickTime * direction * thing.MovementSpeed);
		if (newPosition < 0)
		{
			newPosition = 0;
		}
		if (newPosition > Settings.Engine.MapLength)
		{
			newPosition = Settings.Engine.MapLength;
		}
		if (thing is Player)
		{
			if (Map.SpawnedMobs.Count > 0 && newPosition > Map.SpawnedMobs[0].Position - 50)
			{
				newPosition = Map.SpawnedMobs[0].Position - 50;
			}
		}
		else
		{
			if (newPosition < Player.Position + 50)
			{
				newPosition = Player.Position + 50;
			}
			Mob mob = Map.SpawnedMobs.Where(x => x.Id == currentEnemyId - 1).FirstOrDefault();
			if (mob != null)
			{
				if (newPosition < mob.Position + 50)
				{
					newPosition = mob.Position + 50;
				}
			}
		}
		thing.Move(newPosition);
	}
}
