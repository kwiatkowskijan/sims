using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBehaviour : MonoBehaviour
{
    public GameObject player;
    public float triggerDistance = 2f;
    private AudioSource audioSource;
    private bool isAudioPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (distance < triggerDistance && !isAudioPlaying) 
        {
            if(!isAudioPlaying)
            {
                audioSource.Play();
            }
            
            isAudioPlaying = true;
        }
        else if(distance >= triggerDistance && isAudioPlaying) 
        {
            if(!audioSource.isPlaying) 
            {
                isAudioPlaying = false;
            }
        }
    }
}
