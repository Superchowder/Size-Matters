using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    bool forward;
    float y;
    float consty;
    // Start is called before the first frame update
    void Start()
    {
        forward = true;
        consty = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        y = transform.localPosition.y;
        if (y < consty)
        {
            y += .0005f;
            forward = true;
        }
        else if (y > (consty + 0.04))
        {
            y -= .0005f;
            forward = false;
        }
        else
        {
            if (forward)
            {
                y += .0005f;
            }
            else
            {
                y -= .0005f;
            }
        }

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}
