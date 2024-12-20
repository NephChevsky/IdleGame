public static class Settings
{
	public static UI UI = new();
	public static Engine Engine = new();
}

public class UI
{
	public Menu Menu = new();
	public Game Game = new();
}

public class Menu
{
	public float WidthRatio = 0.2f;
}

public class Game
{
	public float PanelRatio = 16f / 9f;
}

public class Engine
{
	public float GameSpeed = 10f;
	public float TickTime = 0.02f;
	public int MapLength = 1000;
}