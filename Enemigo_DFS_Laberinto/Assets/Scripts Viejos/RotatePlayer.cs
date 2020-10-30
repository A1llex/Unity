using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{

    public float velocidadDeRotación;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
        	transform.Rotate(transform.up, velocidadDeRotación * Time.deltaTime);
        }

        if (Input.GetKey("e"))
        {
        	transform.Rotate(transform.up, velocidadDeRotación * Time.deltaTime);
        }
    }
}
