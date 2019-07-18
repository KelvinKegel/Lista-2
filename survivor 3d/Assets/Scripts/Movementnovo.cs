using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementnovo : MonoBehaviour
{
    float horizontal;
    Rigidbody body;

    [SerializeField]
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector3(horizontal * speed, 0, 0);
    }
}
