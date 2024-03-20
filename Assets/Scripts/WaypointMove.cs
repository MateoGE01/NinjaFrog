using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;
    [SerializeField] private float speedPlatform = 2.0f;
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)//si la distancia entre el punto actual y el siguiente es menor a 0.1
        {
            currentWaypoint++;//aumenta el índice en waypoints y cambia la dirección al waypoint correspondiente al indice en la lista de waypoints
            if (currentWaypoint >= waypoints.Length)//si el index del waypoint es mayor o igual a la cantidad de datos en la lista waypoints
            {
                currentWaypoint = 0;//se reinicia el index al waypoint inicial
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speedPlatform * Time.deltaTime);//mueve la plataforma del waypoint actual al siguiente waypoint
    }
}
