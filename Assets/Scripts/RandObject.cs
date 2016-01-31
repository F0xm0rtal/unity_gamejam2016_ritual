using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandObject : MonoBehaviour {
    public System.Collections.Generic.List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    public GameObject Prefab5;
    public GameObject Prefab6;
    public GameObject Prefab7;
    public GameObject Prefab8;
    public GameObject Prefab9;
    public GameObject Prefab10;
    public GameObject Prefab11;
    public GameObject Prefab12;
    public GameObject Prefab13;
    public GameObject Prefab14;
    public GameObject Prefab15;
    public GameObject Prefab16;
    public GameObject Prefab17;
    public GameObject Prefab18;
    public GameObject Prefab19;
    public GameObject Prefab20;
    public GameObject Prefab21;
    public GameObject Prefab22;
    public GameObject Prefab23;
    public GameObject Prefab24;


    void Start()
    {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        prefabList.Add(Prefab4);
        prefabList.Add(Prefab5);
        prefabList.Add(Prefab6);
        prefabList.Add(Prefab7);
        prefabList.Add(Prefab8);
        prefabList.Add(Prefab9);
        prefabList.Add(Prefab10);
        prefabList.Add(Prefab11);
        prefabList.Add(Prefab12);
        prefabList.Add(Prefab13);
        prefabList.Add(Prefab14);
        prefabList.Add(Prefab15);
        prefabList.Add(Prefab16);
        prefabList.Add(Prefab17);
        prefabList.Add(Prefab18);
        prefabList.Add(Prefab19);
        prefabList.Add(Prefab20);
        prefabList.Add(Prefab21);
        prefabList.Add(Prefab22);
        prefabList.Add(Prefab23);
        prefabList.Add(Prefab24);
        
        int prefabIndex = UnityEngine.Random.Range(0, 24);
        Instantiate(prefabList[prefabIndex]);

    }

    void Update () {
	
	}
}
