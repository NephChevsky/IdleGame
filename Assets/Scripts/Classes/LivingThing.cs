public class LivingThing
{
	public int Level = 1;
	public int Position;
	public float MovementSpeed = 100f;

	public void Move(int newPosition)
	{
		Position = newPosition;
	}
}
