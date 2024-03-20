using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameCounter : MonoBehaviour
{
    [SerializeField] private Text contadorText;
    public static float TiempoRestante = 60;
    private int totalScenes;
    
    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }
    // Update is called once per frame
    void Update()
    {
        TiempoRestante -= Time.deltaTime;//Resta el tiempo
        if (TiempoRestante < 0)
        {
            TiempoRestante = 0;
            SceneManager.LoadScene(totalScenes - 1);
        }
        if (TiempoRestante < 10)
        {
            contadorText.color = Color.red;
        }
        ContadorPantalla(TiempoRestante);
    }

    void ContadorPantalla(float TimeFaltante)
    { 
        int minutos = Mathf.FloorToInt(TimeFaltante / 60);
        int segundos = Mathf.FloorToInt(TimeFaltante % 60);
    
        contadorText.text = string.Format("{0:00}:{1:00}", minutos, segundos);  
    }
    

}
