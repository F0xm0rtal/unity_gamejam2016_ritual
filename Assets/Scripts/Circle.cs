using UnityEngine;
using System.Collections;



public class Circle : MonoBehaviour {
    public bool ritualReady = false;
    public GameObject[] items = new GameObject[2];
    public int collidedWith = 0;
    public int fail;
    public int[] culte = new int[3] { 0, 0, 0 };

    static public int book = 0;

    // Use this for initialization
    void Start () {
	    //Alea-Spawn
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && ritualReady)
        {
            transform.Rotate(Vector3.right);
            Item i1 = items[0].GetComponent<Item>();
            Item i2 = items[1].GetComponent<Item>();

            if (book != i1.culte && book != i2.culte)
            {
                fail += i1.power + i2.power;
            }
            else
            {
                int t0 = (book == i1.culte) ? i1.power * 2 : i1.power;
                int t1 = (book == i2.culte) ? i2.power * 2 : i2.power;

                if (i1.culte == i2.culte)
                {
                    culte[i1.culte] += System.Math.Abs(t0 - t1);
                }
                else if ((i1.culte == 1 && i2.culte == 2)
                    || (i1.culte == 2 && i2.culte == 0)
                    || (i1.culte == 0 && i2.culte == 1))
                {
                    culte[i1.culte] += System.Math.Abs(t0 - t1);
                }
                else
                {
                    fail += System.Math.Abs(t0 - t1);
                }
            }
            
            if(fail >= 100)
            {
                GameOver();
            }
            else if(culte[0] + culte[1] + culte[2] >= 300)
            {
                if (culte[0] > culte[1] && culte[0] > culte[2])
                    Win(0);
                else if (culte[1] > culte[0] && culte[1] > culte[2])
                    Win(1);
                else
                    Win(2);
            }
            else
            {
                Start();
            }
        }
	}

    void GameOver()
    { }

    void Win(int culte)
    { }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Item")
        {
            items[collidedWith] = other.gameObject;
            collidedWith++;

            ritualReady = (collidedWith == 2) ? true : false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Item")
        {
            collidedWith--;
            items[collidedWith] = null;

            ritualReady = (collidedWith == 2) ? true : false;
        }
    }
}
