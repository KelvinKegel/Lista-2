using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    float movementSpeed = 4;

    [SerializeField]
    protected int enemyLife = 3; 

    public float lookAtTimer = 0;
    public float maxTimer = 2f;
    [SerializeField]
    int forca;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            attack(other.GetComponent<Player>());

            death();
        }
    }
    private void Start()
    {
        init();

    }
    void Update()
    {
        move();

    }

    public virtual void init()
    {
        if (!player || player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        lookAtTimer = Time.time;
        transform.LookAt(player.transform);
    }

    public virtual void move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

    }

    public virtual void death()
    {
        Destroy(gameObject);
    }

    public virtual void attack(Player alvo)
    {
        alvo.Life -= forca;
    }
}
