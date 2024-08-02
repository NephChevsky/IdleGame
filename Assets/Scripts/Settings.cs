public static class Settings
{
    public static GlobalSettings Global = new();
    public static PlayerSettings Player = new();
    public static TimeSettings Time = new();
    public static EnemySettings Enemy = new();
    public static BossSettings Boss = new();

    public class GlobalSettings
    {
        public float MenuRatio = 0.15f;
        public float GameEngineRatio = 16f / 9f;
        public float GameUIBorderRatio = 0.05f;
    }

    public class TimeSettings
    {
        public float GameSpeed = 1f;
        public float SpawnTime = 1f;
        public float DeathScreenTime = 2f;
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

    public class EnemySettings
    {
        public float BaseHP = 1f;
        public float HPGrowth = 1.3f;
        public float BaseMovementSpeed = 200f;
        public float BaseAttack = 1f;
        public float AttackGrowth = 1.3f;
        public float BaseAttackSpeed = 0.5f;
        public float BaseRange = 15f;
        public float BaseXPOnKill = 1f;
        public float XPOnKillGrowth = -0.3f;
    }

    public class BossSettings
    {
        public float BaseHP = 10f;
        public float HPGrowth = 1.3f;
        public float BaseMovementSpeed = 0f;
        public float BaseAttack = 1.5f;
        public float AttackGrowth = 1.3f;
        public float BaseAttackSpeed = 1f;
        public float BaseRange = 15f;
        public float BaseXPOnKill = 5f;
        public float XPOnKillGrowth = -0.3f;
    }
}
