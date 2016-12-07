using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitCoroutine : MonoBehaviour {

	public static IEnumerator Do(float time, Action callback) {
		yield return new WaitForSeconds(time);

		callback();
	}

	public static IEnumerator Do(float time) {
		yield return new WaitForSeconds(time);
	}
}
