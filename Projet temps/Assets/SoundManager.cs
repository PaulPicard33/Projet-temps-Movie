using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   public AudioSource audioSource;
    public AudioClip clipEnOfRoad;
    public AudioClip clipStartWalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Play the audio when the space key is pressed
        if (GameManager.Instance.EndOfRoad == true)
        {   audioSource.clip = clipEnOfRoad;
            audioSource.Play();
        }
     if (GameManager.Instance.StartWalking == true)
        {   audioSource.clip = clipStartWalking;
            audioSource.Play();
        }
}
}
