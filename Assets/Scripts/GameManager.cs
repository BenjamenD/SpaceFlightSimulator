using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;


    ///All Sound Stuff
    [SerializeField][Range(-80, 20)] private float masterVolume;
    [SerializeField][Range(-80, 20)] private float musicVolume;
    [SerializeField][Range(-80, 20)] private float uiVolume;

    [SerializeField] private string masterGroup;
    [SerializeField] private string uiGroup;
    [SerializeField] private string musicGroup;

    [SerializeField] private GameObject music;
    [SerializeField] private GameObject button;
    [SerializeField] private AudioMixer audioMixer;



    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        musicVolume = 1;
        masterVolume = 1;
        uiVolume = 1;
    }

    private void Update()
    {
        audioMixer.SetFloat(masterGroup, masterVolume);
        audioMixer.SetFloat(uiGroup, uiVolume);
        audioMixer.SetFloat(musicGroup, musicVolume);
    }

    ///Volume Update Functions
    
    public void setMasterVolume(Slider slider)
    {
        masterVolume = slider.value;
    }

    public void setMusicVolume(Slider slider)
    {
        musicVolume = slider.value; 
    }

    public void setUIButtonVolume(Slider slider)
    {
        uiVolume = slider.value;
    }
}
