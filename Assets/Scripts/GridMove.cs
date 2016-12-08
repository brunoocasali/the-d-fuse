// http://wiki.unity3d.com/index.php/GridMove

using System.Collections;
using UnityEngine;
using System;

class GridMove : MonoBehaviour {
	public float moveSpeed = 3f;
	public float gridSize = 1f;
	private enum Orientation {
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Horizontal;
	private bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;

	public void Update() {
		if (!isMoving && Input.anyKeyDown) {
			input = PlayerInputController.TranslateMove ();
				// new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

			if (!allowDiagonals) {
				if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
					input.y = 0;
				} else {
					input.x = 0;
				}
			}

			if (input != Vector2.zero) {
				StartCoroutine(move(transform));
			}
		}
	}

	public IEnumerator move(Transform transform) {
		isMoving = true;
		startPosition = transform.position;
		t = 0;

		if(gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + Math.Sign(input.x) * gridSize,
				startPosition.y, startPosition.z + Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + Math.Sign(input.x) * gridSize,
				startPosition.y + Math.Sign(input.y) * gridSize, startPosition.z);
		}

		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}

		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}
}