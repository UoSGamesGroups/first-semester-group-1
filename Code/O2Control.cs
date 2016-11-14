using UnityEngine;
using System.Collections;

public class O2Control : MonoBehaviour
{
    public float o2max = 100;
    public float o2 = 100;
    public float o2loss = 0.1f;
    public bool outside = false;
    static GameObject player;
    private PlayerController playerScript;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Fixedupdate()
    {
        if (player.GetComponent<PlayerController>().playerAlive)
        {
            if (outside)
            {
                o2 -= o2loss;
            }
            if (o2 <= o2max && !outside)
            {
                o2++;
            }
        }
        if (o2 <= 0)
        {
            playerScript.Killed();
        }
    }
}
