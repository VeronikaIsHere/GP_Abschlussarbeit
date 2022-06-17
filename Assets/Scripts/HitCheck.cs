using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class HitCheck : MonoBehaviour
{
    public GameObject Frog;
    //[SerializeField] private AudioSource deathSoundFrog;

    public AudioClip impact;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

  //play sound and destroy frog on collision with HitCheck
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemycollision");

        if (collision.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(impact, Camera.main.transform.position);
            Destroy(Frog.gameObject);
        }

    }

  
}
