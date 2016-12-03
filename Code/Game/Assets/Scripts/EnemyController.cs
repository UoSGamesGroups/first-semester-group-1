using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float maxSpeed = 2f;
	bool facingRight = true;
	//Animator anim; //<- for animation
	public bool isChasingPlayer = false;
	[SerializeField]private GameObject self;
	static GameObject player;
	public float distance;
	public float reach = 2f;
	[SerializeField] private PlayerController playerScript;
	public float hfov = 10;
	public float vfov = 5;
	public Vector2 movement;
	public Rigidbody2D rb;


	// Use this for initialization
	void Start()
	{
		//anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		self = GameObject.Find(gameObject.name);
		playerScript = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
	}
	// Update is called once per frame
	void Update()
	{
		//movement.transform.position.x = player.transform.position.x - self.transform.position.x;

		movement = new Vector2 (player.transform.position.x - self.transform.position.x, transform.position.y);
		movement.Normalize();
		movement *= maxSpeed * Time.deltaTime;


		//anim.SetFloat("Speed", Mathf.Abs(movement.magnitude)); //<- for movement animation
		distance = Vector2.Distance(self.transform.position, player.transform.position);
		float vDistance = player.transform.position.y - self.transform.position.y;
		float hDistance = player.transform.position.x - self.transform.position.x;

		if (vDistance > vfov)
		{
			//look up
		}
		if (vDistance < -vfov)
		{
			//look down
		}
		if ((hDistance <= hfov && hDistance >= -hfov) && (vDistance<=vfov && vDistance>=-vfov))
		{
			isChasingPlayer = true;
		}
		if (isChasingPlayer)
		{
			if (distance > reach) //if out of reach move horizontaly towards player
			{
				Vector2 horizontalMovement = new Vector2(movement.x, GetComponent<Rigidbody2D>().velocity.y);

				//self.GetComponent<Rigidbody2D>().AddForce(movement);
				rb.velocity=movement*maxSpeed;
			}
			else //if in reach attack player
			{
				//anim.SetBool("attacking", true);
				isChasingPlayer = false;
				//playerScript.Killed();
			}
		}
		else if (!isChasingPlayer)
		{
			if (distance > reach) //if player moves out of reach then chase player
			{
				//isChasingPlayer = true;
			}
		}
		if (movement.x < 0 && !facingRight)
		{
			Flip();
		}
		else if (movement.x > 0 && facingRight)
		{
			Flip();

		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemy") {
			Destroy (gameObject); 
		}
	}
	void Flip() //for changing facing
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
