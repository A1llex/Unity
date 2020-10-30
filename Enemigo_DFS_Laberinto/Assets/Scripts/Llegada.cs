using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Llegada : MonoBehaviour
{
    // Se activa cada vez que un objeto haga una colisión.
    private void OnCollisionEnter(Collision objeto)
    {
        // Detecta el tag "Player" si ha hecho la colisión con la meta.
        if(objeto.transform.CompareTag("Player"))
        {
            // Carga la escena de Victoria.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
        // Detecta el tag "Enemigo" si ha hecho la colisión con la meta.
        if(objeto.transform.CompareTag("Enemigo"))
        {
            // Carga la escena de Derrota.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
        }
    }
}
