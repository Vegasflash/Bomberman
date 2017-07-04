using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMotor : MonoBehaviour
{
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    public GameObject player;

    int healthCounter;

    // Use this for initialization
    void Start ()
    {
        healthCounter = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(healthCounter == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
        }
        else if(healthCounter == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(false);
        }
        else if(healthCounter == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);
        }
        else
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            Destroy(player);
        }
	}

    public void IncreaseHealth()
    {
        healthCounter += 1;
        if(healthCounter > 3)
        {
            healthCounter = 3;
        }
    }

    public void DecreasePlayerHealth()
    {
        healthCounter -= 1;
    }
}
