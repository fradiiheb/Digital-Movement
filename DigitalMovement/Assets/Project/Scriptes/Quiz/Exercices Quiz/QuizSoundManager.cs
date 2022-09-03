using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSoundManager : MonoBehaviour
{
    public static AudioClip rightAnswerSound, wrongAnswerSound, endGameSound, fireworkSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        rightAnswerSound = Resources.Load<AudioClip> ("good");
        wrongAnswerSound = Resources.Load<AudioClip> ("tryagain");
        endGameSound = Resources.Load<AudioClip> ("endLevelSound");
        fireworkSound = Resources.Load<AudioClip> ("fireworksound");
        
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "right":
            audioSrc.PlayOneShot (rightAnswerSound);
            break;
            case "wrong":
            audioSrc.PlayOneShot (wrongAnswerSound);
            break;
            case "endlevel":
            audioSrc.PlayOneShot (endGameSound);
            break;
            case "firework":
            audioSrc.PlayOneShot (fireworkSound);
            break;

        }
    }

}
