using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
    public int culte;
    public bool ok = false;
    public Component halo;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Book();
    }

    void Book()
    {
        if (Input.GetButtonDown("Fire3") && ok)
            Circle.book = this.culte;

        if (Circle.book == this.culte)
        {
            //appel Highlight
            /*
            halo = this.gameObject.GetComponent("Halo");

            halo.GetComponent<Renderer>().sortingLayerName = "2nd Foreground";
            halo.GetComponent<Renderer>().sortingOrder = 12;
            halo.GetComponent<Renderer>().enabled = true;
            */
            //this.transform.Rotate(Vector3.right);
            this.transform.localScale += new Vector3(1.0f, 0, 0);

            this.transform.localScale -= new Vector3(2.0f, 0, 0);

            this.transform.localScale += new Vector3(1.0f, 0, 0);
        }
    }

    IEnumerator StartLoader()
    {
        Book();
        yield return new WaitForSeconds(3);
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
