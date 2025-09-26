using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource _aSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject); // Evitar duplicados
        _aSource = GetComponent<AudioSource>();
    }
    public void PlayAudioClip(AudioClip clip)
    {
        _aSource.PlayOneShot(clip);
    }
}
