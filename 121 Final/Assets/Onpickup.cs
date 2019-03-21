using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onpickup : MonoBehaviour
{
    [SerializeField] private Image image;

    public void pickup()
    {
        image.enabled = true;
    }
}
