using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : Singleton<PanelManager> {

    public Stack<GameObject> mCurrentUI
    { private set; get; }

    void Awake()
    {
        mCurrentUI = new Stack<GameObject>();
    }

    /// <summary>
    /// Add UIToAdd to the stack
    /// Replace current UI by UIToAdd
    /// </summary>
    /// <param name="UIToAdd"></param>
    public void UIAdd(GameObject UIToAdd)
    {
        if (mCurrentUI.Count > 0 && UIToAdd == mCurrentUI.Peek())
        {
            return;
        }

        if (mCurrentUI.Count > 0)
        {
            mCurrentUI.Peek().SetActive(false);
        }

        if (UIToAdd != null)
        {
            UIToAdd.SetActive(true);
            mCurrentUI.Push(UIToAdd);
        }
    }

    /// <summary>
    /// Replace the current UI by another
    /// </summary>
    /// <param name="newUI"></param>
    public void UIReplace(GameObject newUI)
    {
        UIBack();

        if (newUI != null)
        {
            newUI.SetActive(true);
            mCurrentUI.Push(newUI);
        }
    }

    /// <summary>
    /// Display the previous UI in stack
    /// </summary>
    public void UIBack()
    {
        if (mCurrentUI.Count > 0)
        {
            mCurrentUI.Pop().SetActive(false);
        }

        if (mCurrentUI.Count > 0)
        {
            mCurrentUI.Peek().SetActive(true);
        }
    }
}
