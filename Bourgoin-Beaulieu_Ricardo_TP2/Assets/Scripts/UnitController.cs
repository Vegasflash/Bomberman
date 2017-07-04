using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb2d;

    // Use this for initialization
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    public void CharacterMovement(int moveDirection)
    {
        Vector3 playerPos = gameObject.transform.position;

        if (moveDirection == 1)
        {
            player.transform.position -= new Vector3(0.64f, 0, 0);
        }
        if (moveDirection == 2)
        {
            player.transform.position += new Vector3(0.64f, 0, 0);
        }
        if (moveDirection == 3)
        {
            player.transform.position -= new Vector3(0, 0.64f, 0);
        }
        if (moveDirection == 4)
        {
            player.transform.position += new Vector3(0, 0.64f, 0);
        }
    }
}
