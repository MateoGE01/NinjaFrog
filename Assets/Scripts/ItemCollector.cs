using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int collectables = 0;
    [SerializeField] private Text collectableText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            collectables++;
            collectableText.text = "Frutas: " + collectables;
            GameCounter.TiempoRestante += 30;
        }
    }
}
