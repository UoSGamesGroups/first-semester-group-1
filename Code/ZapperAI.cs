using UnityEngine;
using System.Collections;

public class ZapperAI : MonoBehaviour {
	int chargeTime = 2;
	float charge = 2;
	public float totalCharge = 0;
	public GameObject spark;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > charge) {
			totalCharge++;
			charge = Time.time + chargeTime;
		}
		if (totalCharge == 3) {
			totalCharge = 0;
			Instantiate(spark, new Vector3(transform.position.x,transform.position.y + 5),Quaternion.identity);
		}
	}
}
