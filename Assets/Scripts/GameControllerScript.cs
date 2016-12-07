using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
	public GameObject prefabBomb;
	public Text mostrador;

	public float timeRemaining = 120f;

	void Start ()
	{
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 1.0f);

		GameObject[] doors = GameObject.FindGameObjectsWithTag ("PortaSala");

		foreach (GameObject obj in doors) {
			var child = obj.transform.parent.
				transform.Cast<Transform> ().Where (c => c.gameObject.tag == "Empty").First ();

			if (child != null) {
				Instantiate (prefabBomb, child.transform.position, child.transform.rotation);
				break;
			}
		}
	}

	void Update ()
	{
		if (timeRemaining == 0.0f) {
			SceneManager.LoadScene ("Menu");
		}

		mostrador.text = timeRemaining.ToString ("## 'seg'");
	}

	void decreaseTimeRemaining ()
	{
		timeRemaining--;
	}
}
