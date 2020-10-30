using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pasar : MonoBehaviour
{
	private void OnCollisionEnter(Collision objeto)
	{
		if (objeto.transform.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
	

}
