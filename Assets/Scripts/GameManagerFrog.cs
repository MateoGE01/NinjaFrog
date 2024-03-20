using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFrog : MonoBehaviour
{
    [SerializeField] GameObject apples;
    private static GameManagerFrog instance;
    public static GameManagerFrog Instance
    { 
        get
        {
            // Si no hay una instancia existente, la crea
            if (instance == null)
            {
                // Busca la instancia en la escena
                instance = FindObjectOfType<GameManagerFrog>();

                // Si no se encontró, crea un nuevo GameObject y adjunta la instancia al componente
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManagerFrog).Name);
                    instance = singletonObject.AddComponent<GameManagerFrog>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        apples.gameObject.SetActive(true);
    }   
}
