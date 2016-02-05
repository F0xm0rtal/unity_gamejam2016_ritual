using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{
    public int culte;
    public bool activable = false;

   void Start () {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && activable)
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
            activable = true;
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activable = false;
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }
}
