using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    static private Transform canvas;
    public int culte, power;
    public bool ok = false;
    public bool attached = false;
    public bool onCircle = false;
    private GameObject perso;
    private GameObject circle;

	// Use this for initialization
	void Start () {
        canvas = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	    if(ok && Input.GetButtonDown("Fire1"))
        {
            //transform.parent = perso.transform;
            transform.position = perso.transform.position;
            attached = true;
            ok = false;
            //perso.GetComponent<DistanceJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            //perso.GetComponent<DistanceJoint2D>().distance = 0;
        }
        else if(attached && Input.GetButtonDown("Fire1"))
        {
            if (onCircle)
                transform.parent = circle.transform;
            else
                transform.parent = canvas;
            attached = false;
            //perso.GetComponent<DistanceJoint2D>().connectedBody = null;
        }
        else if (attached)
            transform.position = perso.transform.position;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = true;
            perso = other.gameObject;
        }
        if (other.gameObject.tag == "Circle")
        {
            onCircle = true;
            circle = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            ok = false;
        if (other.gameObject.tag == "Circle")
            onCircle = false;
    }
}
