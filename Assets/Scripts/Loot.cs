using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

    public int spawnedItemId;

    private bool lootable;

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && lootable)
        {
            GetComponent<Shake>().StartShaking();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            lootable = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            lootable = false;
    }
}
