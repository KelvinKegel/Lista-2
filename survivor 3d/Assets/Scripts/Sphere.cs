using UnityEngine;

public class Sphere : Enemy
{
    private void Start()
    {
        init();
    }

    private void Update()
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