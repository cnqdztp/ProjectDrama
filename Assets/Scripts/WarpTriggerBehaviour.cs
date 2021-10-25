using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpTriggerBehaviour : MonoBehaviour
{
    private TextBehaviour text;

    public Vector3 destination;
    public bool switchScene;
    public int sceneDestination;
    private bool isWarping;
    private AudioSource Audio;
    private void Awake()
    {
        text = transform.GetChild(0).gameObject.GetComponent<TextBehaviour>();
        Audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.ShowText();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && !isWarping)
        {
            Audio.Play();
            isWarping = true;
            if (switchScene)
            {
                //TODO ADD CUTSCENE
                SceneManager.LoadScene(sceneDestination);
            }
            else
            {
                other.GetComponent<CharacterWarp>().Warp(destination);
            }
        }
    }
}
