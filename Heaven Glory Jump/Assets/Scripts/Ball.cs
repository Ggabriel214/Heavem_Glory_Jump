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
    private Vector3 startPos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
            return;

        DeathTrigger deathTrigger = collision.transform.GetComponent<DeathTrigger>();
        if (deathTrigger)
            deathTrigger.HitDeathTrigger();

        //Debug.Log("Ball touched the floor");

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * ImpulsForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    public void CheckHealth(float damageTaken)
    {
        lifeValue.runtimeValue -= damageTaken;
    }
}
