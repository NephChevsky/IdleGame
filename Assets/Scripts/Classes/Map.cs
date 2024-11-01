using System.Collections.Generic;

public class Map
{
	public int Level { get; set; }

	public List<Mob> SpawnedMobs { get; set; } = new();
	public List<Mob> MobsToSpawn { get; set; } = new();
}
