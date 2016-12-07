using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlePortaScript : MonoBehaviour
{
	private bool podeAbrir = false;
	private bool aberto = false;
	public bool HELL_DOOR = false;

	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.E)) {
			if (podeAbrir && !aberto) {
				aberto = true;
				anim.SetBool ("Aberta", true);
            
				if (this.HELL_DOOR) {
					SceneManager.LoadScene ("Menu");
				}
			}
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			podeAbrir = true;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			podeAbrir = false;
		}
	}
}
