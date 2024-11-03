public class Mob : LivingThing
{
	public int Id;
	public float XP = 1f;

	public Mob(int id)
	{
		Id = id;
		Position = Settings.Engine.MapLength;
	}
}