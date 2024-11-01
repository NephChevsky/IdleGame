public static class MobGenerator
{
	public static Mob GenerateMob(int id, int level)
	{
		Mob mob = new(id);
		mob.Level = level;
		return mob;
	}

	public static Mob GenerateBoss(int id,int level)
	{
		Mob boss = new(id);
		boss.Level = level;
		boss.MovementSpeed = 0f;
		return boss;
	}
}
