using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private float scoreValue;
    [SerializeField] private bool hasScored;

    private void Awake()
    {
        hasScored = false;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (hasScored == false)
            {
                ScoreManager.instance.AddPoints(scoreValue);
                hasScored = true;
            }
            else if (hasScored == true) 
            {
                return;
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (hasScored == false)
            {
                ScoreManager.instance.AddPoints(scoreValue);
                hasScored = true;
            }
            else if (hasScored == true)
            {
                return;
            }
        }
    }
}
