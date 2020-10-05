using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class Clickable : MonoBehaviour
{
    public GameObject Gate;
    public AudioSource Lever;
    public AudioSource Chain;

    public GameObject Handle;

    bool Inrange = false;

    public bool isOpen = false;

    private void Update()
    {
        if (Inrange)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2"))
            {
                if (isOpen == false)
                {
                    Gate.SetActive(false);
                    Lever.Play();
                    Chain.Play();
                    Flip();
                }
                else if (isOpen == true)
                {
                    Gate.SetActive(true);
                    Lever.Play();
                    Chain.Play();
                    Flip();
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inrange = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Inrange = false;
    }
    void Flip()
    {
        isOpen = !isOpen;
        Vector3 Scaler = Handle.transform.localScale;
        Scaler.x *= -1;
        Handle.transform.localScale = Scaler;
    }

}
