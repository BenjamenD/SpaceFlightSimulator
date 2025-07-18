using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffectPlayer : MonoBehaviour
{
    public AudioSource buttonAudioSource;
    

    public void PlaySoundEffect(){
        buttonAudioSource.Play();
    }
}
