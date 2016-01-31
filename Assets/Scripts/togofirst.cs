using UnityEngine;
using System.Collections;

public class togofirst : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        if (Input.GetButtonDown("Jump"))
        {   
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");//Level2();
        }
    }
}