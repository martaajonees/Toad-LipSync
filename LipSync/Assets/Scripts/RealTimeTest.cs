using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeTest : MonoBehaviour
{
    public GameObject lipSyncComp;
    private AudioClip clip2;
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = lipSyncComp.GetComponent<AudioSource>();

        myAudio.Play();

        clip2 = Resources.Load("Audio/clip1") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(!myAudio.isPlaying)
        {
            myAudio.clip = clip2;
            myAudio.Play();
        }
    }
}
