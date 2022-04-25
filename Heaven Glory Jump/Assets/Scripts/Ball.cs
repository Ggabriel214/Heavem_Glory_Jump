using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;

    [SerializeField] private FloatValue lifeValue;

    public Rigidbody rb;
    public float jumpForce;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(Vector3.up * jumpForce);

    }

    public void CheckHealth(float damageTaken) 
    {
        lifeValue.runtimeValue -= damageTaken;
    }
}
