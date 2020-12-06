using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip background;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    public RubyController rubyController;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = background;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (rubyController.gameWin == true)
        {
            audioSource.clip = winMusic;
            audioSource.Play();
            enabled = false;
        } else if (rubyController.gameOver == true)
        {
            audioSource.clip = loseMusic;
            audioSource.Play();
            enabled = false;
        }
    }
}
