using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public int stepValue1;
    public int stepValue2;
    public int stepValue3;
    public int stepValue4;
    public int stepValue5;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;

    private AudioSource audioOutput;
    private bool checking;
    private int currentStep;
    private int lastStep;

    public void TriggerCheck()
    {
        checking = true;
    }

    void Start()
    {
        currentStep = 0;
        audioOutput = GetComponent<AudioSource>();
        audioOutput.PlayOneShot(music1);
    }

    void Update()
    {
        if (checking)
        {
            Ritual ritual = GameObject.FindGameObjectWithTag("Circle").GetComponent<Ritual>();

            lastStep = currentStep;
            if (stepValue1 <= ritual.score.fail && ritual.score.fail < stepValue2) { currentStep = 1; }
            if (stepValue2 <= ritual.score.fail && ritual.score.fail < stepValue3) { currentStep = 2; }
            if (stepValue3 <= ritual.score.fail && ritual.score.fail < stepValue4) { currentStep = 3; }
            if (stepValue4 <= ritual.score.fail && ritual.score.fail < stepValue5) { currentStep = 4; }

            if (currentStep != lastStep)
            {
                audioOutput.Stop();
                if (currentStep == 1) { audioOutput.PlayOneShot(music2); }
                if (currentStep == 2) { audioOutput.PlayOneShot(music3); }
                if (currentStep == 3) { audioOutput.PlayOneShot(music4); }
                if (currentStep == 4) { audioOutput.PlayOneShot(music5); }
            }

            checking = false;
        }

    }
}