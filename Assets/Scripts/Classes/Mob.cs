public class Mob : LivingThing
{
	public int Id;

	public Mob(int id)
	{
		Id = id;
		Position = Settings.Engine.MapLength;
	}
}