//using UnityEngine;
//using System.Collections;

//public class Circle : MonoBehaviour
//{
//    private bool enoughItems;
//    private Ritual ritual;

//    void Start()
//    {
//        ritual = GameObject.FindGameObjectWithTag("GameController").GetComponent<Ritual>();
//    }
	
//	void Update ()
//    {
//        if (transform.childCount == 2) { enoughItems = true; ritual.ItemsReady(true); }
//        if (transform.childCount != 2 && enoughItems) { enoughItems = false; ritual.ItemsReady(false); }
//	}
//}
