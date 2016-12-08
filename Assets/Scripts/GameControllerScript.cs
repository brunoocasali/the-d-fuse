using UnityEngine;
using System.Collections;
using System.Linq;

public class GameControllerScript : MonoBehaviour
{
	public GameObject prefabBomb;

	void Start ()
	{
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
	}
}
