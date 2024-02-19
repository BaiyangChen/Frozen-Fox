using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private GameObject target;
    //private GameObject player;
    public float force;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();   
        target = GameObject.FindGameObjectWithTag("target1"); 
        Vector2 targetV2 =  (Vector2)target.transform.position;
        Vector2 direction = targetV2-(Vector2)transform.position;//rigidbody2D.transform.position;
        Debug.Log("direction is : " + direction);
        //Debug.Log("target location is:",target.transform.position);
        rigidbody2D.velocity = new Vector2(direction.x,direction.y).normalized*force;
    }

    /*public void Launch(Vector2 direction, float force){
        rigidbody2D.AddForce(direction * force);
    }*/

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 100.0f){     //if the object move more than 100o frames, destroy them
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D( Collision2D other){            //for collision detecting
        //Debug.Log("Projectile Collision with "+ other.gameObject);
        playerMovement e = other.collider.GetComponent<playerMovement>();
        if(e != null){
            //e.Fix();
            //e.PlaySound(hitClip);
            Destroy(gameObject); //fix the enermy if collide
        }
           
    }
}
