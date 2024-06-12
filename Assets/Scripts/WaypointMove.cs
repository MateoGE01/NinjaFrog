using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // Array de GameObjects que representan los puntos de ruta
    private int currentWaypoint = 0; // Índice del waypoint actual
    [SerializeField] private float speedPlatform = 2.0f; // Velocidad de movimiento de la plataforma

    // Update is called once per frame
    private void Update()
    {
        // Si la distancia entre la posición actual y el siguiente waypoint es menor a 0.1 unidades
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)
        {
            currentWaypoint++; // Avanza al siguiente waypoint en el arreglo

            // Si el índice actual supera o iguala la cantidad de waypoints, reinicia al primer waypoint
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        // Mueve la plataforma hacia el siguiente waypoint con una velocidad suavizada
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speedPlatform * Time.deltaTime);
    }
}
