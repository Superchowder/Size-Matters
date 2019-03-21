using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    [SerializeField] private float mult;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player")))
        {
            return;
        }

        Debug.Log("Trampoline activated");
        collision.GetComponent<Rigidbody2D>().velocity = transform.up * mult;

    }
}
