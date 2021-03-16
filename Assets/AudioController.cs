using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AudioController : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource musicBg;

    public string CenaAtiva;

    public Slider Btnvolume;

    public static AudioController instance;

  
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        CenaAtiva = SceneManager.GetActiveScene().name;
        
        musicBg.volume = (float)Btnvolume.value;

        if (CenaAtiva == "HOME")
        {
            musicBg.Pause();
            musicBg.clip = clips[0];
            musicBg.Play();
            musicBg.loop = true;
        } 
        
        if(CenaAtiva == "T1")
        {
            musicBg.Pause();         
            musicBg.clip = clips[1];
            musicBg.Play();
            musicBg.loop = true;
        }
        if (CenaAtiva == "T2")
        {
            musicBg.Pause();
            musicBg.clip = clips[2];
            musicBg.Play();
            musicBg.loop = true;
        }
        if (CenaAtiva == "CONGRATULATIONS")
        {
            musicBg.Pause();
            musicBg.clip = clips[4];
            musicBg.Play();
            musicBg.loop = true;
        }


    }

    //AudioClip GetRandom()
    //{
    //    return clips[Random.Range(0, clips.Length)];
    //}


}



