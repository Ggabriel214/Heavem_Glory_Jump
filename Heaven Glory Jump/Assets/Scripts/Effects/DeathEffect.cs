using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public static DeathEffect instace;

    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private GameObject ballObject;

    private void Awake()
    {
        instace = this;
    }

    private void FixedUpdate()
    {
        transform.position = ballObject.transform.position;
    }

    public void EnableDeathEffect() 
    {
        //ballObject.SetActive(false);
        deathEffect.Play();
        //Invoke("ResetState", 1f);
    }

    private void ResetState() 
    {
        ballObject.SetActive(true);
    }
}
