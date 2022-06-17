using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    public GameObject BerriesLeftText;
    public GameObject bgText;
    //public GameObject Berries;


    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //search for berries
        if (GameObject.FindObjectOfType<Strawberry>() == null)
            LoadNewLevel(collision);
    
        else
        {
            BerriesLeftText.gameObject.SetActive(true);
            bgText.gameObject.SetActive(true);
            Invoke("TextGone", 2f);
        }
    }

    private void LoadNewLevel(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void TextGone()
    {
        BerriesLeftText.gameObject.SetActive(false);
        bgText.gameObject.SetActive(false);
    }
}
