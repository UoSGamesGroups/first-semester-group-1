using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;
    public bool isChasingPlayer = true;
    private GameObject self;
    private GameObject player;
    private float distance;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        self = GameObject.Find("enemy");
    }
    // Update is called once per frame
    void fixedUpdate()
    {
        Vector2 movement = Vector2.MoveTowards(self.transform.position, player.transform.position, maxSpeed);
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude));
        distance = Vector2.Distance(self.transform.position, player.transform.position);
        if (isChasingPlayer)
        {
            if (distance > 1)
            {
                self.transform.Translate(movement);
            }
            else
            {
                isChasingPlayer = false;
            }
        }
        else if (!isChasingPlayer)
        {
            if (distance > 1)
            {
                isChasingPlayer = true;
            }
        }
        if (movement.magnitude > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.magnitude < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
