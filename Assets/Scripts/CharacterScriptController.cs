using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScriptController : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody2D rigidBody;
    public LayerMask groundMask;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

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
    }

    void Jump()
    {
        if (IsTouchingTheGround()) {
            rigidBody.AddForce(Vector2.up * jumpForce,
                ForceMode2D.Impulse);
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
