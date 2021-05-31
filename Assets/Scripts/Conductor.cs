using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public float firstBeatOffset;
    public AudioSource audioSource;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSource.volume);

        secPerBeat = 60f / songBpm;

        dspSongTime = (float)AudioSettings.dspTime;

        audioSource.Play();


        player.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        songPositionInBeats = songPosition / secPerBeat;
    }

    
}
