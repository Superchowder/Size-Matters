using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool forward;
    float x;
    float constx;
    // Start is called before the first frame update
    void Start()
    {
        forward = true;
        constx = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.localPosition.x;
        if (x < constx)
        {
            x += .01f;
            forward = true;
        }
        else if (x > (constx + 0.6))
        {
            x -= .01f;
            forward = false;
        }
        else
        {
            if (forward)
            {
                x += .01f;
            }
            else
            {
                x -= .01f;
            }
        }

        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!CompareTag("Player"))
    //    {
    //        return;
    //    }

    //    Debug.Log("Collision");

    //    var pos = collision.transform.position.x;
    //    collision.transform.position = new Vector3(pos + x, collision.transform.position.y, collision.transform.position.z);


    //}
}
