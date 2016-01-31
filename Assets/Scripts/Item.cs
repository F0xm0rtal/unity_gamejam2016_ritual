using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public int cult, power;

    public float itemOffset, itemHeight;

    private bool pickable = false;
    private bool holding = false;
    private bool onCircle = false;

    static private Transform canvas;
    private GameObject player;
    private GameObject circle;

	// Use this for initialization
	void Start () {
        canvas = transform.parent;
	}

    // Update is called once per frame
    void Update()
    {
        if (pickable && !holding && Input.GetButtonDown("Fire1"))
        {
            transform.SetParent(player.transform, false);
            holding = true;
            pickable = false;
            //player.GetComponent<DistanceJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            //player.GetComponent<DistanceJoint2D>().distance = 0;
        }
        else if (holding && Input.GetButtonDown("Fire1"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            transform.position += new Vector3(0, -itemHeight, 0);
            if (onCircle)
                transform.parent = circle.transform;
            else
                transform.parent = canvas;
            transform.localScale = new Vector3(1, 1, 1);

            holding = false;
            //player.GetComponent<DistanceJoint2D>().connectedBody = null;
        }
        else if (holding)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
            if (player.GetComponent<SpriteRenderer>().flipX)
                transform.localPosition = new Vector3(-itemOffset, itemHeight, 0.0f);
            else
                transform.localPosition = new Vector3(itemOffset, itemHeight, 0.0f);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickable = true;
            player = other.gameObject;
            player.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
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
        {
            pickable = false;
            player.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
       if (other.gameObject.tag == "Circle")
            onCircle = false;
    }
}
