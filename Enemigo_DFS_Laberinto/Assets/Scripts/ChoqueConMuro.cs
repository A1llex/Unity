using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueConMuro : MonoBehaviour
{
    // Se activa cada vez que el objeto haga una colisión o toque otro objeto.
    // En este caso, cada vez que el jugador choque con un muro.
    private void OnCollisionEnter(Collision objeto)
    {
        // Detecta el tag (la etiqueta asociada a un objeto) "Player"
        // si ha hecho la colisión con el obstáculo.
        if(objeto.transform.CompareTag("Player"))
        {
            // Regresa al jugador al inicio del laberinto.
            objeto.transform.position = new Vector3(5, 1.2f, 15);
            objeto.rigidbody.velocity = Vector3.zero;
            objeto.rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
