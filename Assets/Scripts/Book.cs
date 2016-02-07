using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour
{
    public Cults cult;

    private bool activable;
    private bool activatedOnce;
    private Ritual ritual;

    void Start()
    {
        ritual = GameObject.FindGameObjectWithTag("Circle").GetComponent<Ritual>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && activable)
        {
            ritual.cult = cult;
            ritual.BookReady(true);
            activatedOnce = true;
        }

        if (activatedOnce && ritual.cult == cult)
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        else
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activable = true;
        //    transform.GetChild(1).GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activable = false;
        //    transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }
}
