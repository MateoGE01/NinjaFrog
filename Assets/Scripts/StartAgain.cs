using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartAgain : MonoBehaviour
{
    public void RestartGame()
    { 
        SceneManager.LoadScene(0);
        GameCounter.TiempoRestante = 60;
    }

}
