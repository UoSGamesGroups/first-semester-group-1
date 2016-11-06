using UnityEngine;
using System.Collections;

public class ambushController : MonoBehaviour
{
    private GameObject self;
    private GameObject player;
    private PlayerController playerScript;
    private float distance;
    public float reach = 2f;
    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        self = GameObject.Find(name);
        playerScript = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(self.transform.position, player.transform.position);
        if (distance < reach)
        {
            //anim.SetBool("attacking", true);
            playerScript.Killed();
        }
    }
}