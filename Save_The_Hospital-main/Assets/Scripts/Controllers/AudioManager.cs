using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> musicList,sonds;
  
   
    public  Slider musicVolume,ambiente;
    
   

   
    
    public void Slider()
    {


        for (int i = 0; i < musicList.Count; i++)
        {
            musicList[i].volume = musicVolume.value;
        }
        for (int j = 0; j < sonds.Count; j++)
        {
            sonds[j].volume = ambiente.value;

        }


        //foreach (AudioSource som in sonds) 
        //{
        //    som.volume = ambiente.value;
        //}
        //foreach (AudioSource source in musicList)
        //{
        //    source.volume = musicVolume.value;
        //}
      //  SalvaSom();
    }
    private void Awake()
    {
        //ambiente.value = PlayerPrefs.GetFloat("VolAm");
        //musicVolume.value = PlayerPrefs.GetFloat("VolM");
    }
    public void SalvaSom()
    {
        PlayerPrefs.SetFloat("VolAm", ambiente.value);
      //  PlayerPrefs.Save();
        PlayerPrefs.SetFloat("VolM", musicVolume.value);


        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetFloat("VolAm")+"lalala");
        Debug.Log(PlayerPrefs.GetFloat("VolM")+"lalalasss");
    }
    void Start()
     {

        Cursor.lockState = CursorLockMode.Confined;

        ambiente.value = PlayerPrefs.GetFloat("VolAm");
        musicVolume.value = PlayerPrefs.GetFloat("VolM");

        if (!GameOver.startGame)
        {
            musicVolume.value = 0.5f;
            ambiente.value = 0.5f;
            GameOver.startGame = true;
        }

        //  musicVolume.value = PlayerPrefs.GetFloat("VolM");

        for (int i = 0; i <musicList.Count; i++)
        {
            musicList[i].volume=musicVolume.value;
        }
      //  ambiente.value = PlayerPrefs.GetFloat("VolAm");
        for (int j = 0; j <sonds.Count; j++)
        {
            sonds[j].volume=ambiente.value;

        }
        SalvaSom(); 

        //foreach (AudioSource som in musicList)
        //{
        //    som.volume = musicVolume.value;
        //}
        //foreach (AudioSource source in sonds)
        //{
        //    source.volume = ambiente.value;
        //}
       
        StartCoroutine(PlayMusic(musicList));
    }
   
    public IEnumerator PlayMusic(List <AudioSource> music)
    {
        int index = 0;  
      
        while(true)
        {
            music[index].Play();
            yield return new WaitForSeconds(music[index].clip.length);
         
            index = Random.Range(0, music.Count);
          
        }
    }
}
