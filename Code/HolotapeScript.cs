using UnityEngine;
using System.Collections;

public class HolotapeScript : MonoBehaviour {
	public GameObject Tape;
	public GameObject MainCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (Tape, MainCamera.transform.position, Quaternion.identity);
		}
	}
}
