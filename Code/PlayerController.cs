using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //variables
    public float maxSpeed = 10f;
    bool facingRight = true;
    public Sprite dead;
    private SpriteRenderer spriteRenderer;
    public float jumpForce = 70f;
    public bool airMovement = true;
    public KeyCode jumpKey = KeyCode.Space;
    bool doubbleJump = false;
    public bool canDoubbleJump = false;
    public bool playerAlive = true;
    static GameObject player;
    private O2Control o2Script;
    //Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    //does this at start
    void Start()
    {
        //anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = dead;
        }
        player = GameObject.Find("Player");
        o2Script = player.GetComponent<O2Control>();
    }
    //does this all the time (does not depend on framerate, less accurate than Update)
    void FixedUpdate()
    {
        //anim.SetBool("Ground", grounded);
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (!grounded && airMovement == false) { return; }//<- for disableing movement in air
        if (!playerAlive)
        {
            return;
        }
        float move = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //changes facing
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "speedUpgrade")
        {
            Destroy(col.gameObject);
            maxSpeed += 5;
        }
        if (col.gameObject.tag == "jumpUpgrade")
        {
            Destroy(col.gameObject);
            canDoubbleJump = true;
        }
        if (col.gameObject.tag == "o2Upgrade")
        {
            Destroy(col.gameObject);
            player.GetComponent<O2Control>().o2max += 50;
        }
    }
    //does this all the time (depends on framerate, more accurate than FixedUpdate)
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (canDoubbleJump && grounded)
        {
            doubbleJump = true;
        }
        if (grounded && Input.GetKeyDown(jumpKey))
        {
            //anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        if (doubbleJump)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                doubbleJump = false;
            }
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
        playerAlive = false;
        spriteRenderer.sprite = dead;
    }

    public static implicit operator GameObject(PlayerController v)
    {
        throw new NotImplementedException();
    }
}