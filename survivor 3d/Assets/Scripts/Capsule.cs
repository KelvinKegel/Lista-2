using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Enemy
{

    void Start()
    {
        init();
    }


    void Update()
    {
        move();
    }

    public override void move()
    {
        base.move();
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
