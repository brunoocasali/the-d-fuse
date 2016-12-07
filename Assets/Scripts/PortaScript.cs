using UnityEngine;
using System.Collections;

public class PortaScript : MonoBehaviour
{
	private bool aberta;
	private bool podeAbrir;


	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		this.aberta = false;
		this.podeAbrir = false;

		this.anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKey (KeyCode.E)) {

			if (!aberta && podeAbrir) {
				aberta = true;
				anim.SetBool ("Aberta", true);
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
