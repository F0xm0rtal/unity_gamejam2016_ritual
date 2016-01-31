using UnityEngine;
using System.Collections;

public class FurnitureLayerManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpriteRenderer sub = GetComponentInChildren<SpriteRenderer>();
            other.GetComponent<SpriteRenderer>().sortingOrder = sub.sortingOrder - 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }
}
