using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScriptController : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody2D rigidBody;
    public LayerMask groundMask;
    Animator animator;
    const string STATE_ALIVE = "IsAlive";
    const string STATE_ON_THE_GROUND = "IsOnTheGround";
    public float runningSpeed = 2f;
    Vector3 startPosition;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);

        startPosition = this.transform.position;
    }

    private void FixedUpdate()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, //x
                    rigidBody.velocity.y); //
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        Debug.DrawRay(this.transform.position,
            Vector2.down * 1.2f,
            Color.red);

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
    }

    public void Die()
    {
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }

    public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);

        Invoke("RestartPosition", 1f);
    }

    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
    }

    void Jump()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (IsTouchingTheGround()) {
                rigidBody.AddForce(Vector2.up * jumpForce,
                    ForceMode2D.Impulse);
            }

        } 
    }

    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(
            this.transform.position,
            Vector2.down,
            1.2f,
            groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
