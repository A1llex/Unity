using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverJugador : MonoBehaviour
{
    
    // Variable global para el jugador.
    // El objeto al que le aplicaremos la fuerza.
    public Rigidbody rb;

    // Variables editables
    // Fuerza que se aplicará al jugador durante el juego.
    public float fuerza = 30;

    // Velocidad de la rotación.
    public float velocidadDeRotación = 100;

    // Velocidad máxima del jugador.
    public float velocidadMáxima = 8;


    // Start is called before the first frame update
    void Start()
    {
        // Debug para la consola
        Debug.Log("Inicia jugador.");

    }

    // Update is called once per frame
    void Update()
    {

        // Movimiento

        // Si presionamos la tecla 'd', aplica una fuerza hacia adelante.
        // Esta fuerza es relativa a la orientación del jugador.
        if (Input.GetKey("w"))
        {
            rb.AddForce(fuerza * transform.forward);
        }

        // Si presionamos la tecla 'd', aplica una fuerza hacia atrás.
        if (Input.GetKey("s"))
        {
            rb.AddForce(-fuerza * transform.forward);
        }

        // Si presionamos la tecla 'a', aplica una fuerza a la izquierda.
        if (Input.GetKey("a"))
        {
        	rb.AddForce(-fuerza * transform.right);
        }

        // Si presionamos la tecla 'd', aplica una fuerza a la derecha.
        if (Input.GetKey("d"))
        {
        	rb.AddForce(fuerza * transform.right);
        }


        // Rotaciones

        // Rotación de la cámara hacia la izquiera. 
        // (En realidad se gira al jugador a la derecha/como las manecillas del reloj vistas desde arriba.)
        if (Input.GetKey("q"))
        {
            transform.Rotate(transform.up, -velocidadDeRotación * Time.deltaTime);
        }

        // Rotación de la cámara hacia la derecha.
        if (Input.GetKey("e"))
        {
            transform.Rotate(transform.up, velocidadDeRotación * Time.deltaTime);
        }


        // Evita que la aceleración incremente la velocidad del jugador a algo mayor a "velocidadMáxima".
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, velocidadMáxima);


    }

}