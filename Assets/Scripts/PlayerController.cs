using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private Rigidbody2D myRBD;

    [SerializeField] private float velocityModifier;

    [SerializeField] private float jumpForce;

    [SerializeField] private int maxJumps = 2;  
    private int jumpCount = 0;
    int life = 10;

    public static event Action<int> OnCollisionItem;



    void Start()
    {

    }

    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
       // _vertical = move.ReadValue<Vector2>().y;
    }
    public void OnJump(InputAction.CallbackContext jump)
    {
        if (jump.performed && jumpCount < maxJumps)
        {
             myRBD.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount += 1;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag== "Ground")
        {

            jumpCount = 0;

        }
        
        if (collision.gameObject.tag == "Coin")
        {
            OnCollisionItem?.Invoke(5);
            Destroy(collision.gameObject);
            Debug.Log("Coin");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }
    void Update()
    {
       // Debug.Log(jumpCount);
    }
   
    public void FixedUpdate()
    {
        myRBD.velocity = new Vector2(_horizontal * velocityModifier, myRBD.velocity.y);
    }
    public void SendPosition()
    {

    }
   
}
