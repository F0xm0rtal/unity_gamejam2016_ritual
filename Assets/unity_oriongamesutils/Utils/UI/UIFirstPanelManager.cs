using UnityEngine;
using System.Collections;

public class UIFirstPanelManager : MonoBehaviour {

    [SerializeField]
    private GameObject _firstPanel;

	// Use this for initialization
	void Start () {
        Debug.Log("Add " + _firstPanel + " as first UI pannel");
        PanelManager.Instance.UIAdd(_firstPanel);
	}
}
