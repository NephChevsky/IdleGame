using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public Player Player;
    public TMP_Text DeathText;
    public TMP_Text MapLevelText;
    public TMP_Text PlayerLevelText;
    public TMP_Text PlayerXPText;

    private EnemyGenerator EnemyGenerator;

    private List<GameObject> Enemies = new();
    private List<GameObject> RemainingEnemies = new();

    private float SpawnTimer = Settings.Time.SpawnTime;
    private float DeathTimer = 0;
    private float AutoSaveTimer = 0;

    void Start()
    {
        EnemyGenerator = GetComponent<EnemyGenerator>();
    }

    void FixedUpdate()
    {
        if (Enemies.Count == 0 && RemainingEnemies.Count == 0)
        {
            ResetGame();
        }

        if (DeathTimer > 0)
        {
            DeathTimer -= Time.fixedDeltaTime * Settings.Time.GameSpeed;
            if (DeathTimer <= 0)
            {
                DeathTimer = -1f;
                GoToPreviousMapLevel();
            }
            return;
        }

        Player.Move();

        foreach (GameObject enemy in Enemies)
        {
            enemy.GetComponent<Enemy>().Move();
        }

        Player.AttackTimer += Time.fixedDeltaTime * Settings.Time.GameSpeed;
        if (Player.AttackTimer > 1f)
        {
            GameObject opponent = Player.GetReachableOpponent();
            if (opponent != null)
            {
                Enemy enemy = opponent.GetComponent<Enemy>();
                if (Player.Attack(enemy))
                {
                    Player.AddXP(enemy.XPOnKill);
                    Enemies.Remove(opponent);
                    Destroy(opponent);
                    if (RemainingEnemies.Count == 0)
                    {
                        GoToNextMapLevel();
                    }
                }
                Player.AttackTimer -= Mathf.Floor(Player.AttackTimer);
            }
        }

        foreach (GameObject enemy in Enemies)
        {
            LivingThing enemyLT = enemy.GetComponent<LivingThing>();
            enemyLT.AttackTimer += Time.fixedDeltaTime * Settings.Time.GameSpeed;
            if (enemyLT.AttackTimer > 1)
            {
                GameObject opponent = enemyLT.GetReachableOpponent();
                if (opponent != null)
                {
                    enemyLT.AttackTimer -= Mathf.Floor(enemyLT.AttackTimer);
                    if (enemyLT.Attack(Player))
                    {
                        DeathTimer = Settings.Time.DeathScreenTime;
                        break;
                    }
                }
            }
        }

        SpawnTimer += Time.fixedDeltaTime * Settings.Time.GameSpeed;
        if ((RemainingEnemies.Count > 1 && SpawnTimer > Settings.Time.SpawnTime) || (RemainingEnemies.Count == 1 && Enemies.Count == 0 && SpawnTimer > Settings.Time.SpawnTime))
        {
            SpawnEnemy();
            SpawnTimer -= Settings.Time.SpawnTime;
        }
    }

    void Update()
    {
        if (DeathTimer > 0)
        {
            Image panelImage = GetComponent<Image>();
            Color color = panelImage.color;
            color.a = DeathTimer / Settings.Time.DeathScreenTime;
            panelImage.color = color;
            color = DeathText.color;
            color.a = 1 - (DeathTimer * Settings.Time.DeathScreenTime / 2);
            if (color.a < 0)
            {
                color.a = 0;
            }
            DeathText.color = color;
        }
        else if (DeathTimer == -1f)
        {
            DeathTimer = 0;
            Image panelImage = GetComponent<Image>();
            Color color = panelImage.color;
            color.a = 1;
            panelImage.color = color;
            color = DeathText.color;
            color.a = 0;
            DeathText.color = color;
        }

        MapLevelText.text = $"Map level: {PlayerPrefs.GetInt("MapLevel")}";
        PlayerLevelText.text = $"Player Level: {Player.Level}";
        PlayerXPText.text = $"XP: {Mathf.CeilToInt(Player.XP)}/{Mathf.CeilToInt(Player.MaxXP)}";

        AutoSaveTimer += Time.deltaTime * Settings.Time.GameSpeed;
        if (AutoSaveTimer > Settings.Time.AutoSaveTime)
        {
            Save();
            AutoSaveTimer = 0;
        }
    }

    void Save()
    {
        PlayerPrefs.SetString("Player", JsonUtility.ToJson(Player));
        PlayerPrefs.Save();
    }

    void GenerateMap()
    {
        foreach (GameObject enemy in RemainingEnemies)
        {
            Destroy(enemy);
        }
        RemainingEnemies.Clear();

        foreach (GameObject enemy in Enemies)
        {
            Destroy(enemy);
        }
        Enemies.Clear();

        int mapLevel = PlayerPrefs.GetInt("MapLevel", 1);
        for (int i = 0; i < 10 + Mathf.CeilToInt(mapLevel / 10); i++)
        {
            RemainingEnemies.Add(EnemyGenerator.CreateEnemy(mapLevel));
        }
        RemainingEnemies.Add(EnemyGenerator.CreateBoss(mapLevel));
    }

    void ResetGame()
    {
        GenerateMap();
        Player.ResetPosition();
        Player.CurrentHP = Player.MaxHP;
        Player.AttackTimer = 0;
        SpawnTimer = 0;
    }

    void GoToPreviousMapLevel()
    {
        int mapLevel = PlayerPrefs.GetInt("MapLevel", 1) - 1;
        if (mapLevel < 1)
        {
            mapLevel = 1;
        }
        PlayerPrefs.SetInt("MapLevel", mapLevel);
        ResetGame();
        Player.CurrentHP = Player.MaxHP;
    }

    void GoToNextMapLevel()
    {
        PlayerPrefs.SetInt("MapLevel", PlayerPrefs.GetInt("MapLevel", 1) + 1);
        ResetGame();
    }

    void SpawnEnemy()
    {
        GameObject enemy = RemainingEnemies[0];
        enemy.GetComponent<Enemy>().ResetPosition();
        enemy.SetActive(true);
        Enemies.Add(enemy);
        RemainingEnemies.RemoveAt(0);
    }
}
