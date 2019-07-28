using UnityEngine;

public class Cube : Enemy
{
    private void Start()
    {
        init();
    }

    private void Update()
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