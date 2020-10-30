using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Nodo;

public class MoverEnemigo : MonoBehaviour
{
    //public Transform jugador;
    //public Rigidbody rb;
    private bool toca_muro= false;
    public int desplaza=1;
    
    private RaycastHit hit;
    private int tamanio_rayo=9;

    private Boolean VerMeta = false;

    public Vector3 inicio ;
    // Start is called before the first frame update
    void Start()
    {
        intPosition = finPosition= transform.position = new  Vector3(5.0f,1.5f,5.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.tag =="Muro"){
            Debug.Log("El " + gameObject.name + " coliciono con el gamobject " + collision.gameObject.tag);   
            toca_muro=true;
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag =="Muro"){
                Debug.Log("El " + gameObject.name + " esta colisionando con el gamobject " + collision.gameObject.tag);
                toca_muro=true;
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("El " + gameObject.name + " dejo de colisionar con el gamobject " + collision.gameObject.tag);
        toca_muro=false;
    }
    
    // TODO: Determina si en la posición actual del agente puede moverse hacia arriba.
	// Se lanza un rayo (del tamaño de una celda) que va desde la posición de agente con el vector de dirección correspondiente
	// para determinar si hay colisión con una pared.
	// Analogamente para el resto de las direcciónes.
	public bool CanMoveFrwd(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * tamanio_rayo, Color.red);
		if (Physics.Raycast (transform.position, fwd,out hit, tamanio_rayo)) {
			if(hit.collider.gameObject.CompareTag("Muro"))
				return false;
		}
		return true;
	}

	public bool CanMoveRight(){
		Vector3 rkt = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, rkt * tamanio_rayo, Color.red);
		if (Physics.Raycast (transform.position, rkt, out hit, tamanio_rayo)) {
			if(hit.collider.gameObject.CompareTag("Muro"))
				return false;
		}
		return true;
	}

	public bool CanMoveBack(){
		Vector3 bck = transform.TransformDirection(Vector3.back);
        Debug.DrawRay(transform.position, bck * tamanio_rayo, Color.red);
		if (Physics.Raycast (transform.position, bck, out hit, tamanio_rayo)) {
			if(hit.collider.gameObject.CompareTag("Muro"))
				return false;
		}
		return true;
	}

	public bool CanMoveLeft(){
		Vector3 lft = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, lft * tamanio_rayo, Color.red);
		if (Physics.Raycast (transform.position, lft, out hit, tamanio_rayo)) {
			if(hit.collider.gameObject.CompareTag("Muro"))
				return false;
		}
		return true;
	}
    

    //Vector del incio del moviento
    Vector3 intPosition ;
    //Vector objetivo
    Vector3 finPosition ;
    //Referncia al tiempo desde el que se tomo la ultima actualizacion
    float t = 0;
    //Stack de los nodos visitados por el enemigo
    Stack< Vector3 > DFS = new Stack< Vector3 >();
    //Stack para llevar el camino actual y en dado caso regresar por el
    Stack< Vector3 > camino = new Stack< Vector3>();
    //Para usar numeros aleatorios
    //Random random = new Random();
    //Vector3 noDireccion = new Vector3(Single.NegativeInfinity,Single.NegativeInfinity,Single.NegativeInfinity);

    Vector3 CanMove (){
        //Vectores posible
        Vector3 posible;
        //Aqui revisamos las direcciones y las añadimos a un conjunto para despues añadirlas a una monticulo
        //Se codifican las direcciones con numeros
        if (CanMoveFrwd() & !DFS.Contains(posible = (finPosition + Vector3.forward*10)))
        {
            Debug.Log("se puede mover hacia enfrente");
            return posible;
        }
        if (CanMoveBack() & !DFS.Contains(posible = (finPosition + Vector3.back*10)))
        {
            Debug.Log("se puede mover hacia atras");
            return posible;
            
        }
        if (CanMoveRight() & !DFS.Contains(posible = (finPosition + Vector3.right*10)))
        {
            Debug.Log("se puede mover hacia derecha");
            return posible;
            
        }
        if (CanMoveLeft() & !DFS.Contains(posible = (finPosition + Vector3.left*10)))
        {
            Debug.Log("se puede mover hacia izquierda");
            return posible;
            
        }else{
            return Vector3.zero;
        }
    }

    Vector3 MoveMeta (){
        return Vector3.zero;
    }

    /**
    Metodo que se actualiza en cada tick del juego
    **/
    void FixedUpdate()
    {
        //Debug.Log(toca_muro);
        //Debug.Log("quieto");

        //Solo si llega hasta o un poco mas se busca la siguiente poscion
        if( Math.Abs(finPosition.x - transform.position.x)<=0.1f & Math.Abs(finPosition.z - transform.position.z)<=0.1f ){
            //se toma como posicion inicial la actual
            intPosition = transform.position ;
            //Se guarda la poscion a la que llego y se agrega al camino recorrido
            camino.Push(finPosition);
            //Se agrega a los nodos visitados 
            DFS.Push(finPosition);
            
            //el tiempo en el que inicia acontar
            t = Time.deltaTime;
            //si no ve la meta seguira buscando
            if (!VerMeta)
            {
                finPosition = CanMove();
                //si ya no podemos movernos a ninguna direccion regresaremos por nuestra ruta de camino
                if( finPosition.y == 0 ){
                    //Si mi camino esta vacio es que no me quedan caminos por recorrer es decir no enconto la meta
                    if(camino.Count == 0){
                        //Termina de buscar o lo intenta
                        return;
                    }else{
                        camino.Pop();
                        finPosition = camino.Pop();
                    }
                }else{
                    
                }
            }else{
            //Si Encuentra la meta se movera hacia ella
                finPosition = MoveMeta();
            }
        }
        transform.position = Vector3.Lerp(transform.position , finPosition, Time.deltaTime+0.1f);
        
    }

}

