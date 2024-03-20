using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    

    private void Update()
    {
        //se usa transform por convención, ya que accede al Transform del objeto al que esta asignado el script, pero también se puede crear una variable de tipo Transform y asignarle el valor de transform
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);//se actualiza la posicion de la camara en el eje x y el eje y, pero no en el eje z
    }
}
