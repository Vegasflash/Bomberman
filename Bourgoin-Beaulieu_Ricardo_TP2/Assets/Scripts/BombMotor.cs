using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMotor : MonoBehaviour
{
    public GameObject explosion;
    private int blastRange = 3;
    private float fuseTimer = 2;

    void Start()
    {
        Invoke("Explode", fuseTimer);
    }

    public void IncreaseBombRange()
    {
        blastRange += 1;
    }

    public void DecreaseBombRange()
    {
        blastRange -= 1;
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        for ( int i = 0; i < blastRange; i++)
        {
            ExplosionFireSpawn(i * 0.64f);
        }
        Destroy(gameObject);
    }

    void ExplosionFireSpawn(float offset)
    {
        if (offset == 0)
        {
            Instantiate(explosion, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {

            Instantiate(explosion, transform.position + new Vector3(offset, 0, 0), Quaternion.identity);
            Instantiate(explosion, transform.position - new Vector3(offset, 0, 0), Quaternion.identity);
            Instantiate(explosion, transform.position + new Vector3(0, -offset, 0), Quaternion.identity);
            Instantiate(explosion, transform.position - new Vector3(0, -offset, 0), Quaternion.identity);
        }
    }


}
