using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   public AudioSource audioSource;
    public AudioClip clipEndOfRoad;
    public AudioClip clipStartWalking;
    public AudioClip clipincentives;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
     public void playstop()
    {
        audioSource.clip = clipEndOfRoad;
        audioSource.Play();
    }
    public void playstart()
    {
        audioSource.clip = clipStartWalking;
        audioSource.Play();
    }
    public void playincentives()
    {
        audioSource.clip = clipincentives;
        audioSource.Play();
    }
}

