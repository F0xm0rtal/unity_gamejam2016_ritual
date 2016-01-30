using UnityEngine;
using System.Collections;

/// <summary>
/// This script is used for UI Button handler
/// </summary>
public class UIPanelManager : MonoBehaviour {

    public static bool ButtonBackActif = true;

    public void UIAdd(GameObject UIToAdd)
    {
        PanelManager.Instance.UIAdd(UIToAdd);
    }

    public void UIReplace(GameObject newUI)
    {
        PanelManager.Instance.UIReplace(newUI);
    }

    public void UIBack()
    {
        PanelManager.Instance.UIBack();
    }

    void Update()
    {
        if (ButtonBackActif && Input.GetButtonDown("Cancel"))
        {
            if (PanelManager.Instance.mCurrentUI.Count <= 1)
            {
                return;
            }

            UIBack();
        }
    }
}
