using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour
{
    private bool isDown;
    public AudioSource audioSource;

    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.up) < 0.7f)
        {
            if (!isDown)
            {
                isDown = true;
                GameManager.Instance.IncreaseScore(1);
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                    Console.WriteLine("PLAYING!!!");
                }


            }
        }
        else
        {
            isDown = false;
        }
    }
}
