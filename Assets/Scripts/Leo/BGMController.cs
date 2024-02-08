using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioClip titleBGM;
    public AudioClip gameBGM;
    [SerializeField] private AudioSource currentBGM;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<BGMController>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            currentBGM = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeTitleBGM()
    {
        currentBGM.clip = titleBGM;
        currentBGM.Play();
    }

    public void ChangeGameBGM()
    {
        currentBGM.clip = gameBGM;
        currentBGM.Play();
    }

    public void StopBGM()
    {
        currentBGM.Stop();
    }
}
