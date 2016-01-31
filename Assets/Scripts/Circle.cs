using UnityEngine;
using System.Collections;



public class Circle : MonoBehaviour {
    public bool ritualReady = false;
    public int fail;
    public int[] cult = new int[3] { 0, 0, 0 };

    static public int book = 0;

    // Use this for initialization
    void Start () {
	    //Alea-Spawn
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && transform.childCount == 2)
        {
            transform.Rotate(Vector3.right);
            Item i1 = transform.GetChild(0).gameObject.GetComponent<Item>();
            Item i2 = transform.GetChild(1).gameObject.GetComponent<Item>();

            if (book != i1.cult && book != i2.cult)
            {
                fail += i1.power + i2.power;
            }
            else
            {
                int t0 = (book == i1.cult) ? i1.power * 2 : i1.power;
                int t1 = (book == i2.cult) ? i2.power * 2 : i2.power;

                if (i1.cult == i2.cult)
                {
                    cult[i1.cult] += System.Math.Abs(t0 - t1);
                }
                else if ((i1.cult == 1 && i2.cult == 2)
                    || (i1.cult == 2 && i2.cult == 0)
                    || (i1.cult == 0 && i2.cult == 1))
                {
                    cult[i1.cult] += System.Math.Abs(t0 - t1);
                }
                else
                {
                    fail += System.Math.Abs(t0 - t1);
                }
            }

            float r, v, b;

            if (cult[0] + cult[1] + cult[2] != 0)
            {
                r = (cult[0] == 0) ? 0 : 1.0f - ((float)cult[0] / 300.0f);
                v = (cult[1] == 0) ? 0 : 1.0f - ((float)cult[1] / 300.0f);
                b = (cult[2] == 0) ? 0 : 1.0f - ((float)cult[2] / 300.0f);
            }
            else
                r = b = v = 1.0f;


            GetComponent<SpriteRenderer>().color = new Color(r, v, b, 1.0f - ((float)fail / 100.0f));

            if (fail >= 100)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");//GameOver();
            }
            else if(cult[0] + cult[1] + cult[2] >= 300)
            {
                if (cult[0] > cult[1] && cult[0] > cult[2])
                    UnityEngine.SceneManagement.SceneManager.LoadScene("End1");//Win(0);
                else if (cult[1] > cult[0] && cult[1] > cult[2])
                    UnityEngine.SceneManagement.SceneManager.LoadScene("End2");//Win(1);
                else
                    UnityEngine.SceneManagement.SceneManager.LoadScene("End3");//Win(2);
            }
            else
            {
                Start();
            }
        }
	}

    void GameOver()
    { }

    void Win(int cult)
    { }
    /*
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
    }*/
}
