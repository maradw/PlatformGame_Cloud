using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private Rigidbody2D myRBD;
    private float _vertical;
    [SerializeField] private float velocityModifier = 5f;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer; // Capa que define el suelo
    private bool isGrounded;


    private GameObject _ghostPrefab;
    public static event Action<int> OnCollisionGhost;

    void Start()
    {

    }

    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;
    }
    public void OnJump(InputAction.CallbackContext jump)
    {
        if (jump.performed)
        {
            myRBD.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    void Update()
    {
        // Aquí puedes manejar la entrada para saltar
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        // Verifica si el jugador está en el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            OnCollisionGhost?.Invoke(5);
        }
    }
    private void Jump()
    {
       
    }


   
    public void FixedUpdate()
    {
        myRBD.velocity = new Vector2(_horizontal * velocityModifier, _vertical * velocityModifier);
    }
    private void OnDrawGizmos()
    {
        // Visualiza el Raycast en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.1f);
    }
}
