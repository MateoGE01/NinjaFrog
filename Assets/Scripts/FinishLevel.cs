using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Level : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        int currentScene = SceneManager.GetActiveScene().buildIndex;//obtiene el indice de la escena actual
        int TotalScenes = SceneManager.sceneCountInBuildSettings;//obtiene el total de escenas

        if (collision.gameObject.name == ("Player"))//si la bandera colisiona con el jugador
        {
            Complete();//llama a la funcion complete y pasa a la siguiente Scene(siguiente nivel)

        }
        
        Debug.Log("Scene" + currentScene + "of" + TotalScenes);//muestra en consola el indice de la escena actual y el total de escenas
    }


    private void Complete()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;//obtiene el indice de la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//carga la siguiente escena
        GameCounter.TiempoRestante += 10 * NextScene;
    }
}
