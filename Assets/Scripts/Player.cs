using UnityEngine;

public class Player : LivingThing
{
    public int Level = 1;
    public float XP;
    public float MaxXP;

    void Start()
    {
        string playerJson = PlayerPrefs.GetString("Player", null);
        if (string.IsNullOrEmpty(playerJson) || playerJson == "{}")
        {
            Level = 1;
            CurrentHP = Settings.Player.BaseHP;
            MaxHP = Settings.Player.BaseHP;
            MovementSpeed = Settings.Player.BaseMovementSpeed;
            BaseAttack = Settings.Player.BaseAttack;
            BaseAttackSpeed = Settings.Player.BaseAttackSpeed;
            Range = Settings.Player.BaseRange;
            XP = 0;
            MaxXP = Settings.Player.BaseXP;
        }
        else
        {
            JsonUtility.FromJsonOverwrite(playerJson, this);
            CurrentHP = MaxHP;
        }
    }

    public void AddXP(float xp)
    {
        XP += xp;
        if (XP >= MaxXP)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        XP -= MaxXP;
        MaxXP = Settings.Player.BaseXP * Mathf.Pow(Settings.Player.XPGrowth, Level - 1);
        MaxHP = Settings.Player.BaseHP * Level;
        BaseAttack = Settings.Player.BaseAttack * Level;
    }
}
