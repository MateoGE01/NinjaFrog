using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlatformAndPlayer : MonoBehaviour
{
    // Este método se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el collider que entró es el jugador
        if (collision.gameObject.name == "Player")
        {
            // Establece el padre del jugador como el transform actual (posiblemente la plataforma)
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Este método se llama cuando otro collider sale del trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica si el collider que salió es el jugador
        if (collision.gameObject.name == "Player")
        {
            // Remueve cualquier padre que tenga el jugador (lo devuelve a ser hijo de null)
            collision.gameObject.transform.SetParent(null);
        }
    }
}
