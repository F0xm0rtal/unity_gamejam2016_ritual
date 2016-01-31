using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public int stepValue1;
    public int stepValue2;
    public int stepValue3;
    public int stepValue4;
    public int stepValue5;

    private AudioSource[] aSources;
    private bool checking;
    private  int currentStep;

    public void TriggerCheck()
    {
        checking = true;
    }

    void Start()
    {
        aSources = GetComponents<AudioSource>();
    }

    void Update()
    {
        Circle circle = GameObject.FindGameObjectWithTag("Circle").GetComponent<Circle>();

        if (circle.fail  < stepValue1)
        {
            aSources[0].Play();
        }

        if (stepValue1 <= circle.fail && circle.fail < stepValue2)
        {
            if (aSources[0].isPlaying) { aSources[0].Stop(); }
            aSources[1].Play();
        }

        if (stepValue2 <= circle.fail && circle.fail < stepValue3)
        {
            if (aSources[0].isPlaying) { aSources[0].Stop(); }
            if (aSources[1].isPlaying) { aSources[1].Stop(); }
            aSources[2].Play();
        }

        if (stepValue3 <= circle.fail && circle.fail < stepValue4)
        {
            if (aSources[0].isPlaying) { aSources[0].Stop(); }
            if (aSources[1].isPlaying) { aSources[1].Stop(); }
            if (aSources[2].isPlaying) { aSources[2].Stop(); }
            aSources[3].Play();
        }

        if (stepValue4 <= circle.fail && circle.fail < stepValue5)
        {
            if (aSources[0].isPlaying) { aSources[0].Stop(); }
            if (aSources[1].isPlaying) { aSources[1].Stop(); }
            if (aSources[2].isPlaying) { aSources[2].Stop(); }
            if (aSources[3].isPlaying) { aSources[3].Stop(); }
            aSources[4].Play();
        }
    }
}