using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    Player player_ref;

    [SerializeField]
    GameObject[] prefabsInimigos = new GameObject[4];

    public int xPos;
    public int zPos;

    public TextMeshProUGUI scoreText;
    
    private float timerStart;
    [SerializeField]
    private float timerMax;
    [SerializeField]
    private int score;


    [SerializeField]
    private float timerStartEnemy;
    [SerializeField]
    private float timerMaxEnemy;

    [SerializeField]
    private float timerStartDif;
    [SerializeField]
    private float timerMaxDif;
    [SerializeField]
    [Range(0.1f,1.0f)]
    float spawnIncrease;

    void Start()
    {
        timerStart = Time.time;
        timerStartEnemy = Time.time;
        timerStartDif = Time.time;
        if (!player_ref || player_ref == null)
            player_ref = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
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

        if (Time.time >= timerStart + timerMax && player_ref.Life > 0)
        {
            timerStart = Time.time;
            score += 5;

            scoreText.text = "Score: " + score;
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
                
               Instantiate(prefabsInimigos[Random.Range(0,4)], new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
               enemyCount += 1;
          }
        }

    }
}
