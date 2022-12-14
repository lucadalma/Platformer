using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPortal : MonoBehaviour
{
    public float rotation;
    public bool dimension2D;

    bool flipFlop = true;

    private void Start()
    {
        //playerColl = GameManager.Instance.playerRef.coll;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (flipFlop)
            {
                other.gameObject.transform.rotation *= Quaternion.Euler(0, rotation, 0);
                GameManager.Instance.playerRef.playerMov.dimension2D = dimension2D;
                gameObject.SetActive(false);
            }
            else
            {
                other.gameObject.transform.rotation *= Quaternion.Euler(0, -rotation, 0);
                GameManager.Instance.playerRef.playerMov.dimension2D = !dimension2D;
            }
            flipFlop = !flipFlop;
        }
    }
}
