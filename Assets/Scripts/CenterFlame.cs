using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CenterFlame : MonoBehaviour
{
    AudioSource MyAudio;
    bool musicStart = false;
    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                MyAudio.Play();
                musicStart = true;
            }
        }
    }
}
