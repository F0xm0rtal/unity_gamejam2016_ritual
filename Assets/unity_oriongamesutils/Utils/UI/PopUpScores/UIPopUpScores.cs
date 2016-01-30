using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPopUpScores : MonoBehaviour {

    [SerializeField]
    private Text _text;
    [SerializeField]
    private Animator _animator;


    public void AddPoints(int pointsToAdd)
    {
        _text.text = (pointsToAdd > 0 ? "+" : "") + pointsToAdd;
        _animator.SetTrigger((pointsToAdd > 0 ? "Up" : "Down"));
    }
}
