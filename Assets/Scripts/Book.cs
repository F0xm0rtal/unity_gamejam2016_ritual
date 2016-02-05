using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
    public int culte;
    public bool ok = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3") && ok)
            Circle.book = this.culte;

        if (Circle.book == this.culte)
            transform.GetChild(1).GetComponent<Renderer>().enabled = true;
        else
            transform.GetChild(1).GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Circle.book != this.culte)
        {
            ok = true;
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = false;
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }
}
