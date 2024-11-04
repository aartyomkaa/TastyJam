using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _volume;
    [SerializeField] private Slider _ambient;

    private void Start()
    {
        _music.onValueChanged.AddListener(delegate { SliderMusicChange(); });
        _volume.onValueChanged.AddListener(delegate { SliderVolumeChange(); });
        _ambient.onValueChanged.AddListener(delegate { SliderAmbientChange(); });
    }
    public void SliderMusicChange()
    {
        _mixerGroup.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, _music.value));
    }
    public void SliderVolumeChange()
    {
        _mixerGroup.audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 0, _volume.value));
    }
    public void SliderAmbientChange()
    {
        _mixerGroup.audioMixer.SetFloat("Ambient", Mathf.Lerp(-80, 0, _ambient.value));
    }
}
