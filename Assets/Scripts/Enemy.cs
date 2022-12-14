using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MyPlayer playerRef;
    public float damage = 25;
    public float knockback = 50;
    public float heightOfKnock = 10;

    void Start()
    {
        playerRef = GameManager.Instance.playerRef;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRef.TakeDamage(damage);
            //playerRef.playerMov.KnockBack(gameObject.transform.position, heightOfKnock, knockback);
        }
    }

 
}
