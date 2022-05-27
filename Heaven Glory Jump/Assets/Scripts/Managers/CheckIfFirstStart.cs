using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfFirstStart : MonoBehaviour
{
    public static CheckIfFirstStart instance;   
    [SerializeField] private BoolValue isStarting;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarting.runtimeValue = true;
    }

}
