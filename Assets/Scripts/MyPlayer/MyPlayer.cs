using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public Vector3 startPoint;
    
    [HideInInspector] public PlayerMovement playerMov;

    [HideInInspector] public Collider coll;

    public float health = 100;

    private void Awake()
    {
        GameManager.Instance.playerRef = this;
    }

    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        //startPoint = GameManager.Instance.startPoint.transform.position;
        coll = GetComponent<Collider>();
        startPoint = GameManager.Instance.startPoint;
    }

    public void TakeDamage(float value)
    {
        if(health > value) // 35 - 35
        {
            health -= value; // health = health - value;
            Debug.Log("Health is: " + health);
        }
        else
        {
            Death();
        }
    }

    void Death()
    {
        playerMov.gameObject.transform.position = GameManager.Instance.startingPoint.transform.position;
        health = 100;
    }
}
