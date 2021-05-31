using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    private AudioSource AudioSrc;

    private float AudioVolume = 1f;


    public Slider slider;


    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("SliderVolumeLevel", 1);
    }

    void Update()
    {

    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
    }
}