using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeOrDeath : MonoBehaviour
{
    // Referencia al componente Animator
    private Animator anima;

    // Referencia al componente Rigidbody2D
    private Rigidbody2D Rigidb;

    // Start es llamado antes de la primera actualización del frame
    private void Start()
    {
        // Obtiene y guarda la referencia al componente Rigidbody2D adjunto al GameObject
        Rigidb = GetComponent<Rigidbody2D>();

        // Obtiene y guarda la referencia al componente Animator adjunto al GameObject
        anima = GetComponent<Animator>();
    }

    // Método llamado cuando el GameObject colisiona con otro GameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba si el GameObject con el que colisionó tiene la etiqueta "Trap"
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Llama al método Die si colisiona con una trampa
            Die();
        }
    }

    // Método para manejar la muerte del personaje
    private void Die()
    {
        // Cambia el tipo de cuerpo del Rigidbody2D a estático para detener el movimiento
        Rigidb.bodyType = RigidbodyType2D.Static;

        // Activa la animación de muerte
        anima.SetTrigger("death");
    }

    // Método para reiniciar la escena actual
    private void Restart()
    {
        // Carga de nuevo la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
