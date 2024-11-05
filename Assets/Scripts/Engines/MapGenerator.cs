using System.Linq;
using UnityEngine;

public static class MapGenerator
{
	public static Map Generate(int level)
	{
		Map map = new();

		map.Level = level;
		map.MobsToSpawn = new();

		int maxMobs = 10 + Mathf.FloorToInt(level / 10);

		int i;
		for (i = 0; i < maxMobs - 1; i++)
		{
			map.MobsToSpawn.Add(MobGenerator.GenerateMob(i, level));
		}

		map.MobsToSpawn.Add(MobGenerator.GenerateBoss(i, level));

		return map;
	}
}
