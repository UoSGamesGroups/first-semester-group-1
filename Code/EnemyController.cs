using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 2f;
    bool facingRight = true;
    //Animator anim; //<- for animation
    public bool isChasingPlayer = true;
    private GameObject self;
    private GameObject player;
    private float distance;
    public float reach = 2.5f;
    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        self = GameObject.Find(name);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = player.transform.position - transform.position;
        movement.Normalize();
        movement *= maxSpeed;
        //anim.SetFloat("Speed", Mathf.Abs(movement.magnitude)); //<- for movement animation
        distance = Vector2.Distance(self.transform.position, player.transform.position);
        if (isChasingPlayer)
        {
            if (distance > reach) //if out of reach move towards player
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x, GetComponent<Rigidbody2D>().velocity.y);
            }
            else //if in reach attack player
            {
                //anim.SetBool("attacking", true);
                isChasingPlayer = false;
            }
        }
        else if (!isChasingPlayer)
        {
            if (distance > reach) //if player moves out of reach then chase player
            {
                isChasingPlayer = true;
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
    void Flip() //for changing facing
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
