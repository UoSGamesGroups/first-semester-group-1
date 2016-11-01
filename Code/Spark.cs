using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {
	GameObject target;
	private Vector3 look;
	float angle;
	float speed = 4;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");

		look = target.transform.position - transform.position;

		angle = Mathf.Atan2 (look.y, look.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
	}

	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);

	}
}
