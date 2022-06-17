using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // private Animator anim;
    private Rigidbody2D rb;
    
    public GameObject player;
    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        //für death animation
        // anim= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //die when in collision with enemy or trap
        if (collision.gameObject.CompareTag("Trap"))
        {

            deathSound.Play();
            Invoke("Die", 0.3f);

        }
        if (collision.gameObject.CompareTag("enemy"))
        {

            deathSound.Play();
            Invoke("Die", 0.4f);
        }
    }

    private void Die()
    {

        //für death animation
        //anim.SetTrigger("death");

        Debug.Log("Die");

        //no movement after death
        rb.bodyType = RigidbodyType2D.Static;

        //player disappears
        player.SetActive(false);

        //Levelrestart after 1 second
        Invoke("RestartLevel", 0.5f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("Restart");
    }

}