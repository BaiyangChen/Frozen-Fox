using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallShooter : MonoBehaviour
{
    public GameObject SnowBall;
    public Transform snowballPos;
    private float timer;
    //Rigidbody2D rigidbody2d;
    private playerMovement playerScript;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        playerScript = FindObjectOfType<playerMovement>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isFreeze == true)
        {
            canShoot = false;
        }
        timer += Time.deltaTime;
        if (timer > 2 && canShoot)
        {
            timer = 0;
            shoot();
        }
        else if (!canShoot)
        {
            StartCoroutine(wait());
        }
    }

    void shoot()
    {
        //Instantiate(SnowBall, snowballPos.position);

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector2 move = new Vector2(rigidbody2d.position.x, rigidbody2d.position.y);
        //lookDirection.Set(move.x, move.y);
        //lookDirection.Normalize();
        //Debug.Log("direction is : " + lookDirection);

        GameObject projectileObject = Instantiate(SnowBall, snowballPos.position/*rigidbody2d.position + Vector2.up * 0.5f*/, Quaternion.identity);
        //SnowBallMovement projectile = projectileObject.GetComponent<SnowBallMovement>();
        //projectile.Launch(lookDirection, 300);

        //animator.SetTrigger("Lauch");

    }

    IEnumerator wait()
    {
        Debug.Log("aa");
        yield return new WaitForSeconds(10);
        canShoot = true;
    }


}
