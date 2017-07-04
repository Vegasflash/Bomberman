using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Player player;

    float counter;

    int direction;

    int healthCounter;

    void Start()
    {
        healthCounter = 1;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= 2)
        {
            counter = 0;
            MoveEnemy(Random.Range(1,4));
        }

        if(healthCounter == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.DamagePlayer(1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Debug.Log("breakthisshit");

            BoxCollider2D boxCol = collision.gameObject.GetComponent<BoxCollider2D>();
            boxCol.isTrigger = true;
            DamageEnemy(1);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
        }
        Debug.Log("entering in trigger but...");
    }

    public void DamageEnemy(int damage)
    {
        healthCounter -= damage;
    }


    public void MoveEnemy(int moveDirection)
    {
        Vector3 playerPos = gameObject.transform.position;

        if (moveDirection == 1 && playerPos.x > -2)
        {
            transform.position -= new Vector3(0.64f, 0, 0);
        }
        if (moveDirection == 2 && playerPos.x < 2)
        {
            transform.position += new Vector3(0.64f, 0, 0);
        }
        if (moveDirection == 3 && playerPos.y > -2)
        {
            transform.position -= new Vector3(0, 0.64f, 0);
        }
        if (moveDirection == 4 && playerPos.y < 2)
        {
            transform.position += new Vector3(0, 0.64f, 0);
        }
    }
}
