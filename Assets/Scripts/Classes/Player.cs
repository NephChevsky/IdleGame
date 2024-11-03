using UnityEngine;

public class Player : LivingThing
{
	public float CurrentXP = 0f;
	public float MaxXP;

	public Player(int level)
	{
		Position = 0;
		Level = level;
		ComputeStats();
		CurrentHP = MaxHP;
	}

	public void LevelUp()
	{
		Level++;
		ComputeStats();
	}

	public void ComputeStats()
	{
		BaseAttack = 1f * (1f + 0.3f * (Level - 1));
		MaxHP = 20f * (1f + 0.3f * (Level - 1));
		MaxXP = 10f * Mathf.Pow(1.3f, Level - 1);
	}
}