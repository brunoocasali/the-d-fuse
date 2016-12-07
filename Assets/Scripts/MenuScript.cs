using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetButton ("Fire1") || Input.GetKeyDown (KeyCode.R)) {
			iniciar ();
		}
	}

	public void iniciar ()
	{
		SceneManager.LoadScene ("Cena01");
	}
}