using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public AudioClip boostSource;
    public HealthMotor health;
    public BombMotor bombM;

    float counter;
    bool routineCounter;

    public void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 20)
        {
            bombM.IncreaseBombRange();
                   
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enteriiiing");
        if(col.tag == "Player")
        {
            
            StartCoroutine(PickedUp());
            health.IncreaseHealth();
        }
    }

    private IEnumerator PickedUp()
    {
        AudioManager.instance.PlayBoostSound(boostSource);

        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
