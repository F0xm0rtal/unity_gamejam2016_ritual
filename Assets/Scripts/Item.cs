using UnityEngine;
using System.Collections;

[System.Serializable]
public class RelativePosition
{
    public float X, Y;
}

public class Item : MonoBehaviour
{
    public int power;
    public Cults cult;
    public RelativePosition relativePosition;

    private bool pickable;
    private bool holding;
    private bool onCircle;

    private GameObject player;
    private GameObject circle;
    private GameObject itemsGroup;

    void Start()
    {
        itemsGroup = transform.parent.gameObject;
    }

    void Update()
    {
        if (pickable && !holding && Input.GetButtonDown("Fire1"))
        {
            transform.SetParent(player.transform, false);
            holding = true;
            pickable = false;
        }

        else if (holding && Input.GetButtonDown("Fire1"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            transform.position += new Vector3(0, -relativePosition.Y, 0);
            if (onCircle)
                transform.parent = circle.transform;
            else
                transform.parent = itemsGroup.transform;
            transform.localScale = new Vector3(1, 1, 1);

            holding = false;
        }

        if (holding)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
            if (player.GetComponent<SpriteRenderer>().flipX)
                transform.localPosition = new Vector3(-relativePosition.X, relativePosition.Y, 0.0f);
            else
                transform.localPosition = new Vector3(relativePosition.X, relativePosition.Y, 0.0f);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickable = true;
            player = other.gameObject;
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
        }
       if (other.gameObject.tag == "Circle")
            onCircle = false;
    }
}