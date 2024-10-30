public class LivingThing
{
	public int Position;
	public float MovementSpeed = 100f;

	public void Move(int newPosition)
	{
		Position = newPosition;
	}
}
