﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Player;

    [SerializeField]
    float movementSpeed = 4;

    [SerializeField]
    protected int enemyLife = 3; 

    public float lookAtTimer = 0;
    public float maxTimer = 2f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Player>().Life -= 2;

            enemyLife -= 3;
            if (enemyLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        lookAtTimer = Time.time;
        transform.LookAt(Player.transform);
    }
    void Update()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        //print(( maxTimer + lookAtTimer) + " | " + Time.time);
        if ((lookAtTimer + maxTimer) <= Time.time)
        {
            
            lookAtTimer = Time.time;
            transform.LookAt(Player.transform);
        }
    }
}
