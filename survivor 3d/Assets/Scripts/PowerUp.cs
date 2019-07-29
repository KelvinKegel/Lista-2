using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 0.5f;

    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent < BoxCollider>().enabled = false;    

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;

        Destroy(gameObject);
    }
}
