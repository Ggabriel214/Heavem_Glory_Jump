using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;

    [SerializeField] private FloatValue lifeValue;

    private bool ignoreNextCollision;
    public Rigidbody rb;
    public float ImpulsForce = 10.3f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
            return;

        Debug.Log("Ball touched the floor");

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * ImpulsForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckHealth(float damageTaken)
    {
        lifeValue.runtimeValue -= damageTaken;
    }
}
