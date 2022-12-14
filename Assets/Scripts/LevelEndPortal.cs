using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPortal : MonoBehaviour
{
    Vector3 startPoint;

    private void Start()
    {
        startPoint = GameManager.Instance.startPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = startPoint;
        }
    }
}
