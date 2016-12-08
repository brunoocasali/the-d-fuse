using UnityEngine;
using System.Collections;
using System.Linq;

public class GameControllerScript : MonoBehaviour
{
	public GameObject prefabBomb;

	void Start ()
	{
		GameObject[] places = GameObject.FindGameObjectsWithTag ("Empty");

		var child = places [Random.Range (0, places.Length)];

		if (child != null)
			Instantiate (prefabBomb, child.transform.position, child.transform.rotation);
	}

	void Update ()
	{
	}
}
