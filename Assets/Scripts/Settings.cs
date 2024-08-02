public static class Settings
{
    public static GlobalSettings Global = new();
    public static PlayerSettings Player = new();

    public class GlobalSettings
    {
        public float MenuRatio = 0.15f;
        public float GameEngineRatio = 16f / 9f;
    }

    public class PlayerSettings
    {
        public float BaseHP = 100f;
        public float BaseMovementSpeed = 100f;
        public float BaseAttack = 1f;
        public float BaseAttackSpeed = 0.5f;
        public float BaseRange = 15f;
        public float BaseXP = 20f;
        public float XPGrowth = 1.3f;
    }
}
