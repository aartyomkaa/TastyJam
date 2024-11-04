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

    private void Start()
    {
        _music.onValueChanged.AddListener(delegate { SliderMusicChange(); });
        _volume.onValueChanged.AddListener(delegate { SliderVolumeChange(); });
    }
    public void SliderMusicChange()
    {
        _mixerGroup.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, _music.value));
    }
    public void SliderVolumeChange()
    {
        //_mixerGroup.audioMixer.SetFloat("Ambient", Mathf.Lerp(-80, 0, _volume.value));
        _mixerGroup.audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 0, _volume.value));
    }
}
