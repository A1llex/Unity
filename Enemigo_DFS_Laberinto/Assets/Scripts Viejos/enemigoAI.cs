using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemigoAI : MonoBehaviour
{
    public Transform jugador;

    UnityEngine.AI.NavMeshAgent enemigo_bot;

    private bool contacto;


    void Start()
    {
    	Debug.Log("EnemigoAI.Start()");
    	enemigo_bot = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
    	if (other.tag == "Player") {
    		contacto = true;
    		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    	}
    }

    void OnTriggerExit(Collider other)
    {
    	if (other.tag == "Player") {
    		contacto = false;
    	}
    }
    
    void Update()
    {
    	if (!contacto) {
    		enemigo_bot.destination = jugador.position;
    	}
    	if (contacto) {
    		enemigo_bot.destination = this.transform.position;
    	}
    }
}
