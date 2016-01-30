using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoPanel : Singleton<UIInfoPanel>
{
    [SerializeField]
    private Text displayText;

    [SerializeField]
    private Text yesText;
    [SerializeField]
    private Text noText;
    [SerializeField]
    private Text okText;

    [SerializeField]
    private Button buttonYes;
    [SerializeField]
    private Button buttonNo;
    [SerializeField]
    private Button buttonOk;

    private Action callbackYes, callbackNo, callbackOk;

    private GameObject _gameObjectToActive;

    bool IsPausingGame = true;

    bool IsOkMode;

    void Awake()
    {
        _gameObjectToActive = transform.GetChild(0).gameObject;

        buttonYes.onClick.AddListener(OnClicYes);
        buttonNo.onClick.AddListener(OnClicNo);
        buttonOk.onClick.AddListener(OnClicOk);
    }

    /// <summary>
    /// Display with a OK button
    /// </summary>
    /// <param name="text"></param>
    /// <param name="callback"></param>
    public void DisplayOk(string text = "Are you sure?", Action callback = null, string textOk = "Ok", bool pauseGame = true)
    {
        IsOkMode = true;

        buttonYes.gameObject.SetActive(false);
        buttonNo.gameObject.SetActive(false);
        buttonOk.gameObject.SetActive(true);
        okText.text = textOk;

        callbackOk = callback;

        Activate(text, pauseGame);
    }

    public void DisplayYesNo(string text = "Are you sure?", Action callbackYes = null, Action callbackNo = null, string textYes = "Yes", string textNo = "no", bool pauseGame = true)
    {
        IsOkMode = false;

        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
        buttonOk.gameObject.SetActive(false);
        noText.text = textNo;
        yesText.text = textYes;

        this.callbackYes = callbackYes;
        this.callbackNo = callbackNo;

        Activate(text, pauseGame);
    }

    public void DisplayLoading(string text = "Loading", bool pauseGame = true)
    {
        buttonYes.gameObject.SetActive(false);
        buttonNo.gameObject.SetActive(false);
        buttonOk.gameObject.SetActive(false);
        
        Activate(text, pauseGame);
    }

    public void HideLoading()
    {
        _gameObjectToActive.SetActive(false);

        if (IsPausingGame)
            Time.timeScale = 1;
    }

    private void Activate(string text, bool pauseGame)
    {
        UIPanelManager.ButtonBackActif = false;
        IsPausingGame = pauseGame;

        if (IsPausingGame)
            Time.timeScale = 0;

        displayText.text = text;
        _gameObjectToActive.SetActive(true);
    }

    public void OnClicYes()
    {
        UIPanelManager.ButtonBackActif = true;

        if (IsPausingGame)
            Time.timeScale = 1;

        _gameObjectToActive.SetActive(false);
        if (callbackYes != null)
            callbackYes();
    }

    public void OnClicNo()
    {
        UIPanelManager.ButtonBackActif = true;

        if (IsPausingGame)
            Time.timeScale = 1;

        _gameObjectToActive.SetActive(false);
        if (callbackNo != null)
            callbackNo();
    }

    public void OnClicOk()
    {
        UIPanelManager.ButtonBackActif = true;

        if (IsPausingGame)
            Time.timeScale = 1;

        _gameObjectToActive.SetActive(false);
        if (callbackOk != null)
            callbackOk();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (IsOkMode)
            {
                OnClicOk();
            }
            else
            {
                OnClicNo();
            }
        }
    }

    public struct DisplayMessage
    {
        public string text;
        public string ok;

        public DisplayMessage(string t, string o)
        {
            text = t;
            ok = o;
        }
    }

    /// <summary>
    /// Display multiples Ok message
    /// </summary>
    /// <param name="toDisplay"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public void DisplayMessages(DisplayMessage[] toDisplay)
    {
        DisplayMessages(toDisplay, 0)();
    }

    Action DisplayMessages(DisplayMessage[] toDisplay, int i)
    {
        if (i < toDisplay.Length)
        {
            return () => { DisplayOk(toDisplay[i].text, DisplayMessages(toDisplay, i + 1), toDisplay[i].ok); };
        }
        else
        {
            return () => { };
        }
    }

}
