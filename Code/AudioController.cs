using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] audioClip; //array to contain audio clips
    private AudioSource sound; //this is to reduce GetComponent calls

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    void PlaySound(int clip) //plays audio clip from audioClip array
    {
        sound.clip = audioClip[clip];
        sound.Play();
    }
}