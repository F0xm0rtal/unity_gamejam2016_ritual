using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
    public bool ritualReady = false;
    public int fail;
    public int items = 0;
    public int[] cult = new int[3] { 0, 0, 0 };

    public GameObject<>() spawnableItems;

    public ArrayList inGame = new ArrayList();
    public ArrayList itemList = new ArrayList();
    public Vector3[] positions = { new Vector3(1, 2, 3), new Vector3( 1, 5, 0) }; //Add all the positions

    static public int book = 0;

    // Use this for initialization
    void Start () {

        itemList.Add((GameObject)Resources.Load("Cat"));
        itemList.Add((GameObject)Resources.Load("Chose Informe"));
        itemList.Add((GameObject)Resources.Load("Citron Vert"));
        itemList.Add((GameObject)Resources.Load("Clous"));
        itemList.Add((GameObject)Resources.Load("Corbeau"));
        itemList.Add((GameObject)Resources.Load("Coussin Chaos"));
        itemList.Add((GameObject)Resources.Load("Coussin Cthulu"));
        itemList.Add((GameObject)Resources.Load("Coussin Etoile"));
        itemList.Add((GameObject)Resources.Load("Crane Bleu"));
        itemList.Add((GameObject)Resources.Load("Crane Rouge"));
        itemList.Add((GameObject)Resources.Load("Crane Vert"));
        itemList.Add((GameObject)Resources.Load("Cristal Bleu"));
        itemList.Add((GameObject)Resources.Load("Cristal Rouge"));
        itemList.Add((GameObject)Resources.Load("Cristal Vert"));
        itemList.Add((GameObject)Resources.Load("Idole Chaos"));
        itemList.Add((GameObject)Resources.Load("Idole Cthulu"));
        itemList.Add((GameObject)Resources.Load("Idole Satan"));
        itemList.Add((GameObject)Resources.Load("Nyarly"));
        itemList.Add((GameObject)Resources.Load("Peluche Zeentch"));
        itemList.Add((GameObject)Resources.Load("Poisson"));
        itemList.Add((GameObject)Resources.Load("Poupee"));
        itemList.Add((GameObject)Resources.Load("Sel"));
        itemList.Add((GameObject)Resources.Load("Tentacle Plastic"));
        itemList.Add((GameObject)Resources.Load("Truc Serpent"));
        //Alea-Spawn
        Spawn();

	}
	
	void Update ()
    {
        //if (transform.childCount == 3)
        //    transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        //else
        //    transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        if (Input.GetButtonDown("Jump") && transform.childCount == 3)
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

            inGame.Remove(i1);
            inGame.Remove(i2);
            items -= 2;

            float r, v, b;

            if (cult[0] + cult[1] + cult[2] != 0)
            {
                r = (cult[0] == 0) ? 0 : 1.0f - ((float)cult[0] / 300.0f);
                v = (cult[1] == 0) ? 0 : 1.0f - ((float)cult[1] / 300.0f);
                b = (cult[2] == 0) ? 0 : 1.0f - ((float)cult[2] / 300.0f);
            }
            else
                r = b = v = 1.0f;

            AudioManager audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>(); // two lines for trigger the music
            audio.TriggerCheck();

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
                Spawn();
            }
        }
	}

    void Spawn()
    {
        System.Random rand = new System.Random();
        int number = rand.Next(3, 6);

        for (int i = 0; i < number; i++)
        {
            inGame.Add(Instantiate((GameObject)itemList[rand.Next(0, 23)]));
            ((GameObject)inGame[items]).transform.position = positions[rand.Next(0, 1)];
            items++;
        }
    }

    void GameOver()
    { }

    void Win(int cult)
    { }
}
