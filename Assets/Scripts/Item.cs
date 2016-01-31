using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    static private Transform canvas;
    public int culte, power;
    public bool ok = false;
    public bool attached = false;
    private GameObject perso;

	// Use this for initialization
	void Start () {
        canvas = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	    if(ok && Input.GetButtonDown("Fire1"))
        {
            //transform.parent = pickedUpObject.transform;
            //transform.position = pickedUpObject.transform.position - pickedUpObject.transform.forward;
            attached = true;
            perso.GetComponent<Move>().join = new DistanceJoint2D();
            perso.GetComponent<Move>().join.connectedBody = GetComponent<Rigidbody2D>();
            perso.GetComponent<Move>().join.distance = 0;
        }
        else if(attached && Input.GetButtonDown("Fire1"))
        {
            //transform.parent = canvas;
            attached = false;
            perso.GetComponent<Move>().join = null;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = true;
            perso = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = false;
            perso = null;
        }
    }
}
