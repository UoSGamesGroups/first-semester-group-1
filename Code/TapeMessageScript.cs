using UnityEngine;
using System.Collections;

public class TapeMessageScript : MonoBehaviour {

	void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			Destroy (gameObject);
		}
	}
}
