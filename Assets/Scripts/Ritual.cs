using UnityEngine;
using System.Collections;

public enum Cults
{
    satan, cthulhu, chaos
}

[System.Serializable]
public class Score
{
    public int satan, cthulhu, chaos, fail;
}

public class Ritual : MonoBehaviour
{
    public Score score;

    public GameObject[] ritualItems;

    [HideInInspector]
    public Cults cult;

    public ArrayList inGame = new ArrayList();
    public ArrayList itemList = new ArrayList();
    public Vector3[] positions = { new Vector3(1, 2, 3), new Vector3(1, 5, 0) }; //Add all the positions

    private bool bookReady = false;
    public void BookReady(bool b) { bookReady = b; }

    void Start()
    {
        ritualItems = Resources.LoadAll<GameObject>("Prefabs");
        SpawnItems();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && bookReady && transform.childCount == 2)
        {
            DoTheThing();
        }
    }

    void DoTheThing()
    {
        CalculateOutput();
        CheckTriggers();
        SpawnItems();
    }

    void CalculateOutput()
    {
        Item itemA = transform.GetChild(0).gameObject.GetComponent<Item>();
        Item itemB = transform.GetChild(1).gameObject.GetComponent<Item>();
        
        int[] scoreVariation = new int[4] { 0, 0, 0, 0 };

        if (cult != itemA.cult && cult != itemB.cult)
        {
            scoreVariation[3] = itemA.power + itemB.power;
        }

        else
        {
            itemA.power = (cult == itemA.cult) ? itemA.power * 2 : itemA.power;
            itemB.power = (cult == itemB.cult) ? itemB.power * 2 : itemB.power;
            
            if (itemA.cult == itemB.cult)
            {
                scoreVariation[(int)cult] = itemA.power + itemB.power;
            }

            else
            {
                Item majorItem, minorItem;

                if ((int) itemA.cult + (int) itemB.cult != 2)
                {
                    if ((int)itemA.cult < (int)itemB.cult) { majorItem = itemA; minorItem = itemB; }
                    else { majorItem = itemB; minorItem = itemA; }
                }
                else
                {
                    if ((int)itemA.cult > (int)itemB.cult) { majorItem = itemA; minorItem = itemB; }
                    else { majorItem = itemB; minorItem = itemA; }
                }

                if (majorItem.power > minorItem.power)
                    scoreVariation[(int) majorItem.cult] = majorItem.power - minorItem.power;
                else
                    scoreVariation[3] = minorItem.power - majorItem.power;
            }
        }
        score.satan += scoreVariation[0];
        score.cthulhu += scoreVariation[1];
        score.chaos += scoreVariation[2];
        score.fail += scoreVariation[3];

        inGame.Remove(itemA);
        inGame.Remove(itemB);
        //items -= 2;
    }

    void CheckTriggers()
    {
        float r, v, b;

        if (score.satan + score.cthulhu + score.chaos != 0)
        {
            r = (score.satan == 0) ? 0 : 1.0f - score.satan / 300.0f;
            v = (score.cthulhu == 0) ? 0 : 1.0f - score.cthulhu / 300.0f;
            b = (score.chaos == 0) ? 0 : 1.0f - score.chaos / 300.0f;
        }
        else
            r = b = v = 1.0f;

        AudioManager audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>(); // two lines for trigger the music
        audio.TriggerCheck();

        GetComponent<SpriteRenderer>().color = new Color(r, v, b, 1.0f - score.fail / 100.0f);

        if (score.fail >= 100)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");//GameOver();
        }
        else if (score.satan + score.cthulhu + score.chaos >= 300)
        {
            if (score.satan > score.cthulhu && score.satan > score.chaos)
                UnityEngine.SceneManagement.SceneManager.LoadScene("End1");//Win(0);
            else if (score.cthulhu > score.satan && score.cthulhu > score.chaos)
                UnityEngine.SceneManagement.SceneManager.LoadScene("End2");//Win(1);
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("End3");//Win(2);
        }
        Win();
        Lose();
    }

    void SpawnItems()
    {
        //System.Random rand = new System.Random();
        //int number = rand.Next(3, 6);

        //for (int i = 0; i < number; i++)
        //{
        //    inGame.Add(Instantiate((GameObject)itemList[rand.Next(0, 23)]));
        //    ((GameObject)inGame[items]).transform.position = positions[rand.Next(0, 1)];
        //    items++;
        //}
    }

    void Win()
    {

    }

    void Lose()
    {

    }
}