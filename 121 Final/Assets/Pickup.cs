using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject[] purple;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!(collision.CompareTag("item")))
        {
            return;
        }

        collision.GetComponent<Onpickup>().pickup();

        purple = GameObject.FindGameObjectsWithTag("Purplewall");

        foreach (GameObject purple in purple)
        {
            purple.GetComponent<SpriteRenderer>().enabled = false;
            purple.GetComponent<BoxCollider2D>().enabled = false;
        }

        Destroy(collision.gameObject);

    }
}
