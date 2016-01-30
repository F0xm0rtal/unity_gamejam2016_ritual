using UnityEngine;
using System.Collections;

/// <summary>
/// Auto destroy this game object when the default animation clip is over
/// </summary>
public class AutoDestroyAnimation : MonoBehaviour {

    [SerializeField]
    private Animation _animation;


    void Start()
    {
        StartCoroutine("Die");
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(_animation.clip.length);
        Destroy(gameObject);
    }
}
