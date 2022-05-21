using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState 
{
    idle,
    playing,
    death
}

public class Ball : MonoBehaviour
{
    public static Ball instance;

    [Header("Player States")]
    public PlayerState playerState;

    [Header("Life Settings")]
    [SerializeField] private FloatValue lifeValue;

    [Header("Rigidbody Physics Settings")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float defaultImpulseForce;
    [SerializeField] private float currentImpulseForce;
    [SerializeField] private float deathImpulseForce;
    private bool ignoreNextCollision;
    
    [Header("Position Settings")]
    [SerializeField] private VectorValue startPos;

    [Header("Skin Settings")]
    [SerializeField] private MeshRenderer currentRenderer;
    [SerializeField] private Material[] skinList;
    [SerializeField] private IntValue skinIndexValue;

    private void Awake()
    {
        instance = this;
        playerState = PlayerState.idle;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos.defaultValue = transform.position;
        currentImpulseForce = defaultImpulseForce;
        ChooseSkin();
    }

    private void Update()
    {
        CheckRevive();
    }

    private void ChooseSkin() 
    {
        currentRenderer.material = skinList[skinIndexValue.runtimeValue];
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (ignoreNextCollision)
            return;

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * currentImpulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);
                
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    private void ChangeImpulseForce() 
    {
        currentImpulseForce = defaultImpulseForce;
    }

    private void ResetBall()
    {
        transform.position = startPos.defaultValue;
        currentImpulseForce = deathImpulseForce;
        Invoke("ChangeImpulseForce", 2f);
    }

    public void CheckHealth(float damageTaken)
    {
        lifeValue.runtimeValue -= damageTaken;

        if (lifeValue.runtimeValue == 0)
        {
            ManagerGame.instance.CheckDeathState();
            playerState = PlayerState.death;
        }

        else
        {
            ResetBall();
        }
    }

    private void CheckRevive() 
    {
        if (ManagerGame.instance.canRevive == true)
        {
            lifeValue.runtimeValue = lifeValue.initialValue;
            playerState = PlayerState.playing;
            ResetBall();
            ManagerGame.instance.canRevive = false;
        }
    }

}
