using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 3;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("BGM");
    }

    // Update is called once per frame 
    void Update()
    {
        float horinzontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horinzontalInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGround())
        {
            rb.AddForce(new Vector2(rb.velocity.x, 300));
        }

        if (Input.GetKeyDown(KeyCode.P))    //Pause the game
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.O))    //resume the game
        {
            Time.timeScale = 1;
        }
    }

    public bool isGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
