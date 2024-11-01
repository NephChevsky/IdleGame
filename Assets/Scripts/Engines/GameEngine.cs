using System.Linq;
using UnityEngine;

public static class GameEngine
{
	public static Player Player;
	public static Map Map;

	public static float SpawnTimer = 1f;

	public static void Init()
	{
		Player = new();
		Map = MapGenerator.Generate(1);
	}

	public static void Advance(float elapsedTime)
	{
		float time = 0;
		while (time < elapsedTime)
		{
			time += Settings.Engine.TickTime;

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
		}
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
