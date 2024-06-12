using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCounter : MonoBehaviour
{
    // Referencia al componente de texto de la interfaz de usuario que muestra el temporizador de cuenta regresiva.
    [SerializeField] private Text contadorText;

    // Variable estática que representa el tiempo restante en segundos.
    public static float TiempoRestante = 60;

    // Número total de escenas en los ajustes de construcción.
    private int totalScenes;

    // Inicializa la variable totalScenes con el número de escenas en los ajustes de construcción.
    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Resta el tiempo transcurrido desde el último frame
        TiempoRestante -= Time.deltaTime;

        // Si el tiempo restante es menor a 0, se ajusta a 0 y se carga la última escena
        if (TiempoRestante < 0)
        {
            TiempoRestante = 0;
            SceneManager.LoadScene(totalScenes - 1); // Cargar la última escena
        }

        // Si el tiempo restante es menor a 10 segundos, cambia el color del texto a rojo
        if (TiempoRestante < 10)
        {
            contadorText.color = Color.red; // Cambiar el color del texto a rojo
        }

        // Actualiza el tiempo mostrado en pantalla
        ContadorPantalla(TiempoRestante);
    }

    // Actualiza el texto de contadorText para mostrar el tiempo restante en formato MM:SS.
    // Parámetro TimeFaltante: El tiempo restante en segundos.
    void ContadorPantalla(float TimeFaltante)
    {
        int minutos = Mathf.FloorToInt(TimeFaltante / 60);
        int segundos = Mathf.FloorToInt(TimeFaltante % 60);

        // Actualizar el texto con el tiempo formateado
        contadorText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
