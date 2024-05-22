using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioClip[] clips = new AudioClip[12];
    private int comboCount=0;
    public AudioSource perfectTimingSound;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public AudioSource audioSource;
    private int sampleRate = 44100;
    void Start()
    {

       
        clips[0] = CreatePianoNoteClip(185.00f, 0.5f);   // Fa# (F#3)
        clips[1] = CreatePianoNoteClip(196.00f, 0.5f);   // Sol (G3)
        clips[2] = CreatePianoNoteClip(207.65f, 0.5f);   // Sol# (G#3)
        clips[3] = CreatePianoNoteClip(220.00f, 0.5f);   // La (A3)
        clips[4] = CreatePianoNoteClip(233.08f, 0.5f);   // La# (A#3)
        clips[5] = CreatePianoNoteClip(246.94f, 0.5f);   // Si (B3)
        clips[6] = CreatePianoNoteClip(261.63f, 0.5f);  // Do (C4)
        clips[7] = CreatePianoNoteClip(277.18f, 0.5f);  // Do# (C#4)

    }

    AudioClip CreatePianoNoteClip(float frequency, float duration)
    {
        int sampleLength = Mathf.FloorToInt(sampleRate * duration);
        float[] samples = new float[sampleLength];
        AudioClip audioClip = AudioClip.Create("PianoNote", sampleLength, 1, sampleRate, false);
        for (int i = 0; i < sampleLength; i++)
        {
            float t = i / (float)sampleRate;
            samples[i] = Mathf.Sin(2 * Mathf.PI * frequency * t);
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }
    public void PlayMusic(bool isCombo=true)
    {
        comboCount = isCombo ? Mathf.Min(comboCount + 1, 7) : 0;
        audioSource.PlayOneShot(clips[comboCount]);

    }
   
}
