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
        {
            //appel Highlight
            this.transform.Rotate(Vector3.right);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = false;
        }
    }
}
