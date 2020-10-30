using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMeta : MonoBehaviour
{
    // Variable meta que será asociada a la meta para
    // que el enemigo tenga fijado la posición actual de
    // la meta en todo momento.
    public Transform meta;

    // Variable del enemigo.
    UnityEngine.AI.NavMeshAgent enemigo_bot;
    
    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos al enemigo.
        enemigo_bot = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame.
    void Update()
    {
        enemigo_bot.destination = meta.position;
    }
}
