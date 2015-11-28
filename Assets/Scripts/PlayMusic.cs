using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayMusic : MonoBehaviour
{

    public AudioClip[] musicClips;                 


    private AudioSource musicSource;                

    void Awake()
    {
       
        musicSource = GetComponent<AudioSource>();
    }

    //Used if running the game in a single scene, takes an integer music source allowing you to choose a clip by number and play.
    public void PlaySelectedMusic(int musicChoice)
    {
        //Play the music clip at the array index musicChoice
        musicSource.clip = musicClips[musicChoice];
    }
}
