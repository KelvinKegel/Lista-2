using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 4;
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
