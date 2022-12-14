using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is null!");
            }
            return _instance;
        }
    }

    public GameObject startingPoint;

    Vector3 _startPoint;
    public Vector3 startPoint { get { return _startPoint; } set { _startPoint = value; } }

    MyPlayer _playerRef;
    public MyPlayer playerRef { get { return _playerRef; } set { _playerRef = value; }  }

    private void Awake()
    {
        _instance = this;
        _startPoint = startingPoint.transform.position;
    }

}
