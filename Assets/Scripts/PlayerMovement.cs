using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidb; // Componente Rigidbody2D del personaje
    private Animator anima; // Componente Animator del personaje
    [SerializeField] private float speed = 10f; // Velocidad de movimiento del personaje
    [SerializeField] private float jumpForce = 10f; // Fuerza del salto del personaje
    [SerializeField] private int doubleJump = 0; // Contador para el doble salto
    private bool isGrounded; // Verifica si el personaje está en el suelo
    public Transform groundCheck; // Transform para verificar si el personaje está en el suelo
    [SerializeField] private float checkRadius = 0.025f; // Radio del círculo para la verificación del suelo
    public LayerMask groundLayer; // Capa del suelo para la verificación
    private SpriteRenderer sprite; // Componente SpriteRenderer del personaje

    // Estados de movimiento del personaje
    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling,
        DoubleJumping
    }

    private void Start()
    {
        anima = GetComponent<Animator>();
        Rigidb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Rigidb.velocity = new Vector2(moveX * speed, Rigidb.velocity.y);

        // Verificación del suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Resetear doble salto al estar en el suelo
        if (isGrounded)
        {
            doubleJump = 1;
        }

        // Salto simple o doble
        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && doubleJump < 2)
        {
            Jump();
            doubleJump++;
        }
    }

    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        MovementState state;

        // Determina el estado del personaje según el movimiento y la dirección
        if (horizontalInput > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        // Determina el estado del personaje según la velocidad vertical
        if (Rigidb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (Rigidb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        // Determina el estado del personaje para el doble salto
        if (doubleJump == 2)
        {
            state = MovementState.DoubleJumping;
        }

        anima.SetInteger("state", (int)state);
    }

    // Función para el salto
    private void Jump()
    {
        Rigidb.velocity = new Vector2(Rigidb.velocity.x, jumpForce);
    }
}
