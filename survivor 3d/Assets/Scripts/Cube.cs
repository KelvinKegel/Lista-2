using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Enemy
{
    void Start()
    {
        init();
    }

    void Update()
    {
        move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            attack(other.GetComponent<Player>());

            death();
        }
    }
}
