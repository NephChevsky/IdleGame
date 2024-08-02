using System.Collections;
using System.Collections.Generic;
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

        ResetPosition();
    }

    public void ResetPosition()
    {
        RectTransform gameEnginePanelRT = transform.parent.GetComponent<RectTransform>();
        RectTransform playerRT = GetComponent<RectTransform>();
        transform.localPosition = new Vector2( -(0.5f - Settings.Global.GameUIBorderRatio) * gameEnginePanelRT.rect.width, -0.12f * gameEnginePanelRT.rect.height);
    }
}
