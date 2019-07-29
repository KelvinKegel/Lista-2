﻿using UnityEngine;

public class Game : MonoBehaviour
{
    private Player player_ref;

    [SerializeField]
    private GameObject[] prefabsInimigos = new GameObject[4];

    [SerializeField]
    private GameObject[] prefabsPowerUp = new GameObject[2];

    public int xPos;
    public int zPos;

    private float timerStart;

    [SerializeField]
    private float timerMax;

    [SerializeField]
    private float timerStartEnemy;

    [SerializeField]
    private float timerStartPowerUp;

    [SerializeField]
    private float timerMaxEnemy;

    [SerializeField]
    private float timerMaxPowerUp;

    [SerializeField]
    private float timerStartDif;

    [SerializeField]
    private float timerMaxDif;

    [SerializeField]
    [Range(0.1f, 1.0f)]
    private float spawnIncrease;

    private void Start()
    {
        timerStart = Time.time;
        timerStartEnemy = Time.time;
        timerStartDif = Time.time;
        if (!player_ref || player_ref == null)
            player_ref = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Time.time >= timerStartDif + timerMaxDif)
        {
            timerStartDif = Time.time;
            timerMaxEnemy *= spawnIncrease;
        }
        if (Time.time >= timerStartEnemy + timerMaxEnemy)
        {
            timerStartEnemy = Time.time;
            EnemySpawn();
        }
        if (Time.time >= timerStartPowerUp + timerMaxPowerUp)
        {
            timerStartPowerUp = Time.time;
            PowerUpSpawn();
        }
    }

    public void EnemySpawn()
    {
        int enemyCount = 0;

        if (player_ref.isAlive())
        {
            for (int i = 0; i < 3; i++)
            {
                xPos = Random.Range(8, -8);

                zPos = Random.Range(5, -5);
                if (zPos >= 0)
                {
                    zPos = 5;
                }
                else
                {
                    zPos = -5;
                }

                Instantiate(prefabsInimigos[Random.Range(0, 4)], new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
                enemyCount += 1;
            }
        }
    }

    public void PowerUpSpawn()
    {
        int PowerUpCount = 0;

        if (player_ref.isAlive())
        {
            for (int i = 0; i < 1; i++)
            {
                xPos = Random.Range(6, -6);

                zPos = Random.Range(4, -4);

                Instantiate(prefabsPowerUp[Random.Range(0, 2)], new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
                PowerUpCount += 1;
            }
        }
    }
}