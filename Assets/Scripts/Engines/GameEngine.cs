using UnityEngine;

public static class GameEngine
{
	public static Player Player;

	public static void Init()
	{
		Player = new();
	}

	public static void Advance(float elapsedTime)
	{
		float time = 0;
		while (time < elapsedTime)
		{
			Move(Player);

			time += Settings.Engine.TickTime;
		}
	}

	private static void Move(LivingThing thing)
	{
		int direction = -1;
		if (thing is Player)
		{
			direction = 1;
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
		thing.Move(newPosition);
	}
}
