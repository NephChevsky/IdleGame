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
			time += Settings.Engine.TickTime;
		}
	}
}
