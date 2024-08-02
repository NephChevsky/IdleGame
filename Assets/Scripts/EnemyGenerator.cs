using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject GameEnginePanel;

    private GameObject CreateEnemy(float hp, float movementSpeed, float attack, float attackSpeed, float range, float xpOnKill)
    {
        RectTransform gameEnginePanelRT = GameEnginePanel.GetComponent<RectTransform>();
        GameObject enemyGameObject = Instantiate(EnemyPrefab, GameEnginePanel.transform);
        enemyGameObject.transform.localPosition = new Vector2((0.5f - Settings.Global.GameUIBorderRatio) * gameEnginePanelRT.rect.width, -0.12f * gameEnginePanelRT.rect.height);
        enemyGameObject.SetActive(false);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.CurrentHP = hp;
        enemy.MaxHP = hp;
        enemy.MovementSpeed = movementSpeed;
        enemy.BaseAttack = attack;
        enemy.BaseAttackSpeed = attackSpeed;
        enemy.Range = range;
        enemy.XPOnKill = xpOnKill;
        return enemyGameObject;
    }

    public GameObject CreateEnemy(int level)
    {
        float hp = Settings.Enemy.BaseHP * Mathf.Pow(Settings.Enemy.HPGrowth, level - 1);
        float movementSpeed = Settings.Enemy.BaseMovementSpeed;
        float attack = Settings.Enemy.BaseAttack * Mathf.Pow(Settings.Enemy.AttackGrowth, level - 1);
        float attackSpeed = Settings.Enemy.BaseAttackSpeed;
        float range = Settings.Enemy.BaseRange;
        float xpOnKill = Settings.Enemy.BaseXPOnKill * (level + (level - 1) * Settings.Boss.XPOnKillGrowth);
        return CreateEnemy(hp, movementSpeed, attack, attackSpeed, range, xpOnKill);
    }

    public GameObject CreateBoss(int level)
    {
        float hp = Settings.Boss.BaseHP * Mathf.Pow(Settings.Enemy.HPGrowth, level - 1);
        float movementSpeed = Settings.Boss.BaseMovementSpeed;
        float attack = Settings.Boss.BaseAttack * Mathf.Pow(Settings.Enemy.AttackGrowth, level - 1);
        float attackSpeed = Settings.Boss.BaseAttackSpeed;
        float range = Settings.Boss.BaseRange;
        float xpOnKill = Settings.Boss.BaseXPOnKill * (level + (level - 1) * Settings.Boss.XPOnKillGrowth);
        return CreateEnemy(hp, movementSpeed, attack, attackSpeed, range, xpOnKill);
    }
}
