using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D car)
    {
        car.GetComponent<Movement>().SetSpeed(0);
    }
}
