using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{

    public Sprite wallHit;
    public int hp = 1;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall ()
    {
        Debug.Log("suup");
        spriteRenderer.sprite = wallHit;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Debug.Log("breakthisshit");
 
           
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            DamageWall();
        }
        Debug.Log("entering in trigger but...");
    }
}
