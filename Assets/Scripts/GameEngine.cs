using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public EnemyGenerator EnemyGenerator;
    public Player Player;

    private List<GameObject> Enemies = new();
    private List<GameObject> RemainingEnemies = new();
    private float SpawnTimer = Settings.Time.SpawnTime;

    void Start()
    {
        EnemyGenerator = GetComponent<EnemyGenerator>();
        GenerateMap();
    }

    void FixedUpdate()
    {
        Player.Move();

        foreach (GameObject enemy in Enemies)
        {
            enemy.GetComponent<Enemy>().Move();
        }

        SpawnTimer += Time.fixedDeltaTime * Settings.Time.GameSpeed;
        if ((RemainingEnemies.Count > 1 && SpawnTimer > Settings.Time.SpawnTime) || (RemainingEnemies.Count == 1 && Enemies.Count == 0 && SpawnTimer > Settings.Time.SpawnTime))
        {
            SpawnEnemy();
            SpawnTimer -= Settings.Time.SpawnTime;
        }
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
        for (int i = 0; i < 1 /*10 + Mathf.CeilToInt(mapLevel / 10)*/; i++)
        {
            RemainingEnemies.Add(EnemyGenerator.CreateEnemy(mapLevel));
        }
        RemainingEnemies.Add(EnemyGenerator.CreateBoss(mapLevel));
    }

    void SpawnEnemy()
    {
        GameObject enemy = RemainingEnemies[0];
        enemy.SetActive(true);
        Enemies.Add(enemy);
        RemainingEnemies.RemoveAt(0);
    }
}
