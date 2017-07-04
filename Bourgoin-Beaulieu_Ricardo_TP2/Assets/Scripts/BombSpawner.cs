using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    public GameObject bomb;

    int firePower = 1;
    int bombCount = 1;

    void Update()
    {
        SpawnBomb();
    }

    public void SpawnBomb()
    {
        if (Input.GetKeyDown("space") && bombCount > 0)
        {
            Vector3 desiredSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            Instantiate(bomb, desiredSpawnPos, Quaternion.identity);
            bombCount--;
            Invoke("AddBomb", 1);
        }     
    }

    public void AddBomb()
    {
        bombCount++;
    }
}
