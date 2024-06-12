using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgain : MonoBehaviour
{
    // Método para reiniciar el juego
    public void RestartGame()
    {
        // Carga la primera escena (índice 0)
        SceneManager.LoadScene(0);

        // Reinicia el tiempo restante en el GameCounter
        GameCounter.TiempoRestante = 60;
    }
}
