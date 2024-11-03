public class LivingThing
{
	public int Level = 1;
	public int Position;
	public float CurrentHP = 1f;
	public float MaxHP = 1f;
	public float BaseAttack = 1f;
	public float AttackRange = 60f;
	public float MovementSpeed = 100f;
	public float AttackTimer = 0f;

	public void Move(int newPosition)
	{
		Position = newPosition;
	}
}
