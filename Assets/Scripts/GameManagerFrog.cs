using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFrog : MonoBehaviour
{
    // Referencia al GameObject de manzanas
    [SerializeField] GameObject apples;

    // Instancia estática de GameManagerFrog para implementar el patrón Singleton
    private static GameManagerFrog instance;

    // Propiedad para acceder a la instancia del GameManagerFrog
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

    // Método Awake es llamado cuando el script se instancia
    private void Awake()
    {
        // Si no hay una instancia existente, asigna esta instancia y no la destruye al cargar una nueva escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruye este GameObject para mantener el Singleton
            Destroy(gameObject);
        }
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Activa el GameObject de manzanas
        apples.gameObject.SetActive(true);
    }
}
