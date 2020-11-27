using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARinteraction : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] triggerSound;
    
    void Start()
    {
        audio.enabled = false;
    }

    AudioClip RandomClip()
    {
        return triggerSound[Random.Range(0, triggerSound.Length)];
    }

    void OnMouseDown()
    {
        audio.enabled = true;
        Debug.Log("PERSONA!");
        audio = GetComponent<AudioSource>();

        if(triggerSound != null)
        {
            audio.PlayOneShot(RandomClip());
        }
    }
}
