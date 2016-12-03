using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
	//variables
	public float maxSpeed = 10f;
	bool facingRight = true;
	public Sprite dead;
	public Sprite alive;
	private SpriteRenderer spriteRenderer;
	public float jumpForce = 70f;
	public bool airMovement = true;
	public KeyCode jumpKey = KeyCode.Space;
	bool playerAlive = true;
	//Animator anim;
	bool grounded = false;
	public Transform respawn;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private int level;
	private int maxLevel = 1;
	//does this at start
	void Start()
	{
		//anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer.sprite == null)
		{
			spriteRenderer.sprite = dead;
		}
	}
	//does this all the time (does not depend on framerate, less accurate than Update)
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		//anim.SetBool("Ground", grounded);
		//anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		if (!grounded && airMovement == false) { return; }//<- for disableing movement in air
		if (!playerAlive)
		{
			return;
		}
		else if (playerAlive)
		{
			
			float move = Input.GetAxis("Horizontal");
			//anim.SetFloat("Speed", Mathf.Abs(move));
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			//changes facing
			//Debug.Log (move);
			if (move > 0 && facingRight)
			{
				Flip();

			}
			else if (move < 0 && !facingRight)
			{
				Flip();
			}
		}
	}
	//does this all the time (depends on framerate, more accurate than FixedUpdate)
	void Update()
	{
		if (grounded && Input.GetKeyDown(jumpKey))
		{
			//anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}
	void Flip() //for changing facing
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void Killed()
	{
		spriteRenderer.sprite = dead;
		gameObject.transform.position = new Vector2 (respawn.position.x, respawn.position.y);
		spriteRenderer.sprite = alive;	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemy") {
			SceneManager.LoadScene (level);
		}
		if (coll.gameObject.tag == "Finish") {
			
			if (level < maxLevel) {
				level += 1;
				SceneManager.LoadScene (level);
			}
		}
	}


	public static implicit operator GameObject(PlayerController v)
	{
		throw new NotImplementedException();
	}
}
