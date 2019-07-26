using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{

    public GameObject theEnemy;
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
            EnemyDrop();
        }

        if (Time.time >= timerStart + timerMax)
        {
            timerStart = Time.time;
            score += 5;

            scoreText.text = "Score: " + score;
        }

    }



    public void EnemyDrop()
    {
        int enemyCount = 0;
        while (enemyCount < 3)
        {
            xPos = Random.Range(8, -8);
            zPos = Random.Range(5, -5);
            Instantiate(theEnemy, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
            enemyCount += 1;
        }
    }
}
