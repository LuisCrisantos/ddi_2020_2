using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARinteraction : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] triggerSound;
    public Collider tag;
    public GameObject persona;

    void Start()
    {
        audio.enabled = false;
        if(tag.CompareTag("Persona"))
        {
            persona.SetActive(false);
        }
    }
    
    AudioClip RandomClip()
    {
        return triggerSound[Random.Range(0, triggerSound.Length)];
    }

    void OnMouseDown()
    {
        if(tag.CompareTag("Persona"))
        {
            persona.SetActive(true);
        }

        audio.enabled = true;
        Debug.Log("PERSONA!");
        audio = GetComponent<AudioSource>();

        if(triggerSound != null)
        {
            audio.PlayOneShot(RandomClip());
        }
    }
}
