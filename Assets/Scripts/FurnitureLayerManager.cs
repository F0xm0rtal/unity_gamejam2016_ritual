using UnityEngine;
using System.Collections;

public class FurnitureLayerManager : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingOrder += 1;
        }
    }
}
