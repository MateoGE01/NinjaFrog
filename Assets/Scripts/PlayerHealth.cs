using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class LifeOrDeath : MonoBehaviour
{
    private Animator anima;
    private Rigidbody2D Rigidb;

    // Start is called before the first frame update
    private void Start()
    {
        Rigidb = GetComponent<Rigidbody2D>();
        anima  = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        Rigidb.bodyType = RigidbodyType2D.Static;
        anima.SetTrigger("death");
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
