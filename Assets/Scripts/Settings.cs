public static class Settings
{
    public static GlobalSettings Global = new();
    public static PlayerSettings Player = new();
    public static TimeSettings Time = new();

    public class GlobalSettings
    {
        public float MenuRatio = 0.15f;
        public float GameEngineRatio = 16f / 9f;
        public float GameUIBorderRatio = 0.05f;
    }

    public class TimeSettings
    {
        public float GameSpeed = 10f;
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
