using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioPause : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Color32[] _color; //0 green, 1 red


    private static bool MusOn = true;


    void Start()
    {
        
        if(MusOn)
        {
            _image.sprite = _sprite[0];
            _image.color = _color[0];
        }

        else if(!MusOn)
        {
            _image.sprite = _sprite[1];
            _image.color = _color[1];
        }



    }

    public void MusButton ()
    {
        if(MusOn)
        {
            _image.sprite = _sprite[1];
            _image.color = _color[1];
            _mixer.audioMixer.SetFloat("volume", -80);
            MusOn = false;
        }
        else
        {
            _image.sprite = _sprite[0];
            _image.color = _color[0];
            _mixer.audioMixer.SetFloat("volume", 0);
            MusOn = true;
        }
    }
}
