using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vista_enemigo : MonoBehaviour
{
    //public Transform jugador;
    public Rigidbody rb;
    private bool toca_muro;
    public int desplaza=5;
    
    private RaycastHit hit;
    public int tamanio_rayo=10;
    // Start is called before the first frame update
    void Start()
    {
        
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
	public bool CanMoveUp(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * 20, Color.red);
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

	public bool CanMoveDown(){
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
    
    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(toca_muro);
        if (!toca_muro)
        {
            Debug.Log("mueve");
            
            rb.AddForce(desplaza,0,0);
            
        }

        if (toca_muro)
        {
            Debug.Log("quieto");
            
            if (CanMoveUp()){
                Debug.Log("se puede mover hacia enfrente");
                rb.AddForce(0,0, desplaza);
            }
            
            if (CanMoveDown()){
                Debug.Log("se puede mover hacia atras");
            }

            if (CanMoveRight()){
                Debug.Log("se puede mover hacia derecha");
                rb.AddForce(desplaza,0,0 );
            }

            if (CanMoveLeft()){
                Debug.Log("se puede mover hacia izquierda");
            }

            
            
        }
        
    }
}
