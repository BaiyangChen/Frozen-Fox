using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "SnowBall")
        {
            Destroy(col.gameObject);
            //do something here

        }
        
    }


}
