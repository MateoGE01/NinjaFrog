using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    // Variable para contar los coleccionables recogidos
    private int collectables = 0;

    // Referencia al componente de texto de la interfaz de usuario que muestra la cantidad de coleccionables
    [SerializeField] private Text collectableText;

    // Método que se llama cuando otro objeto entra en el trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el objeto colisionado tiene la etiqueta "Collectable"
        if (collision.gameObject.CompareTag("Collectable"))
        {
            // Destruye el objeto coleccionable
            Destroy(collision.gameObject);

            // Incrementa el contador de coleccionables
            collectables++;

            // Actualiza el texto de la interfaz de usuario con la nueva cantidad de coleccionables
            collectableText.text = "Frutas: " + collectables;

            // Aumenta el tiempo restante en el GameCounter
            GameCounter.TiempoRestante += 30;
        }
    }
}
