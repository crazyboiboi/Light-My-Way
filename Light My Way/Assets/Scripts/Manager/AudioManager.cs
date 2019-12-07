using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[System.Serializable]
public class Sound
{
    public AudioMixerGroup audioMixerGroup;

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.5f, 1.5f)]
    public float pitch;

    public bool loop;

    AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.outputAudioMixerGroup = audioMixerGroup;
    }

    public void Play()
    {

        source.Play();
    }



    
}


public class AudioManager : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicSlider", volume);
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXSlider", volume);
        audioMixer.SetFloat("SFXVolume", volume);
    }






    public static AudioManager _instance;

    [SerializeField]
    Sound[] sounds;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        //GameObject[] obj = GameObject.FindGameObjectsWithTag("AudioManager");
        //if(obj.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}
        //DontDestroyOnLoad(this.gameObject);

    }


    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlaySound("Game Music");
    }



    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }



        //No sound with that name
        Debug.LogWarning("AudioManager: Sound not found in sound list, " + _name);

    }



}
