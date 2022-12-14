using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool isStartPoint;
    void Start()
    {
        if(isStartPoint)
        {
            GameManager.Instance.startPoint = gameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.startPoint = gameObject.transform.position;
        }
    }
}
