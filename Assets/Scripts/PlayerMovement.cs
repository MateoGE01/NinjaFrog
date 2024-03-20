using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidb;//se declara una variable de tipo Rigidbody2D llamada Rigidb
    private Animator anima;//se declara una variable de tipo Animator llamada anima
    [SerializeField] private float speed = 10f;//se declara una variable de tipo float llamada speed y se le asigna un valor de 10
    [SerializeField] private float jumpForce = 10f;//se declara una variable de tipo float llamada jumpForce y se le asigna un valor de 10
    [SerializeField] private int doubleJump = 0;//se declara una variable de tipo int llamada doubleJump
    private bool isGrounded;//se declara una variable de tipo bool llamada isGrounded
    public Transform groundCheck;//variable de tipo Transform que se usa para saber si el personaje esta en el suelo
    [SerializeField]private float checkRadius = 0.025f;// variable que determina el radio del circulo que se usa para saber si el personaje esta en el suelo
    public LayerMask groundLayer;//variable que determina el Layer del suelo y colisiona con el circulo que se usa para saber si el personaje esta en el suelo
    private SpriteRenderer sprite;//variable de tipo SpriteRenderer que se usa para voltear al personaje

    private enum MovementState// Representa el estado del personaje, es decir si esta corriendo, saltando, cayendo, etc
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
        float moveX = Input.GetAxisRaw("Horizontal");//cada frame se actualiza el valor de moveX si se presiona "a" o "d", GetAxisRaw retorna -1 si se presiona "a" y 1 si se presiona "d" y 0 si se queda quieto, al mismo tiempo elimina la aceleracion cuando se suelta la tecla
        Rigidb.velocity = new Vector2(moveX * speed, Rigidb.velocity.y);//se actualiza la velocidad del rigidbody en el eje x, es decir el movimiento del personaje 
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer); //Se crea un circulo en la posicion de groundCheck con un radio de checkRadius, si el circulo colisiona con el layer groundLayer, isGrounded es verdadero, de lo contrario es falso
        
        if (isGrounded)
        {
            doubleJump = 1;
        }
        
        //Si el personaje unde el boton de saltar y esta en el suelo, salta
        if (Input.GetButton("Jump") && isGrounded)
        {
            jump();//se llama a la funcion jump

        //Si el personaje no esta en el suelo, y tiene disponible el doble salto y le dio al boton de saltar, salta
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded &&  doubleJump < 2)
        { 
            jump();//se llama a la funcion jump
            doubleJump++;//se incrementa el valor de doubleJump a 2, es decir ya no se puede saltar
        }

    }

    //Es recomendable usar LateUpdate para las animaciones
    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");//cada frame se actualiza el valor de horizontalInput si se presiona "a" o "d", GetAxisRaw retorna -1 si se presiona "a" y 1 si se presiona "d" y 0 si se queda quieto, al mismo tiempo elimina la aceleracion cuando se suelta la tecla

        MovementState state;

        //si el personaje se mueve en el eje x
        if (horizontalInput > 0f)
        {
            state = MovementState.Running;//se activa la animacion de correr
            sprite.flipX = false;
        }
        //si el personaje no se mueve en el eje x
        else if (horizontalInput < 0f)
        {
            state = MovementState.Running;//se activa la animacion de correr
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;//se desactiva la animacion de correr y se activa la animacion de idle
        }

        if (Rigidb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;//se activa la animacion de saltar
        }
        else if (Rigidb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;//se activa la animacion de caer
        }
        if (doubleJump == 2)
        {
            state = MovementState.DoubleJumping;//se activa la animacion de doble salto
        }
        
        
        anima.SetInteger("state", (int)state);
    }

    //funcion para saltar
    private void jump()
    {
        Rigidb.velocity = new Vector2(Rigidb.velocity.x, jumpForce);//se actualiza la velocidad del rigidbody en el eje y, es decir el personaje salta

    }   
}
