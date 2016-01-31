using UnityEngine;
using System.Collections;

public class FurnitureLayerManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingOrder += 1;
        }
    }
}
