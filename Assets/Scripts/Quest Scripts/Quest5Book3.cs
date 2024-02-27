using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Quest5Book3 : MonoBehaviour
{
    public GameObject memoryScene;
    public GameObject playerScene;
    public GameObject []Cards;
    public GameObject[] CardPoints;
    private int []arr;
    private IEnumerator moveCards;
    private Cards cards;
    public AudioSource shuffleSound;
    public GameObject book3;




    // Start is called before the first frame update
    void Start()
    {
        arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        GameObject.Find("QuestSignifier - Galliard").GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToMemoryScene()
    {
        GameObject.Find("QuestSignifier - Galliard").GetComponent<ParticleSystem>().Stop();

        memoryScene.SetActive(false);
        memoryScene.SetActive(true); // memory scene reset for OnEnable function
        memoryScene.GetComponent<Camera>().enabled = true;


        randomizeCards();
    }

    public void playShuffleSound()
    {
        shuffleSound.Play();
    }


    public void randomizeCards()
    {
        book3.SetActive(true);
        Random rnd = new Random();
        randomizeArray(arr);
        int randomPoint = rnd.Next(CardPoints.Length);

        for (int i = 0; i < CardPoints.Length; i++)
        {
            Cards[i].SetActive(false);
            Cards[i].SetActive(true);



            Cards[i].transform.position = CardPoints[arr[i]].transform.position;
            Cards[i].tag = "Card";
           
            //moveCards = MovetoPoint(i,arr[i]);
            //StartCoroutine(moveCards);
        }

    }


    public IEnumerator MovetoPoint(int index,int i)
    {

        while (Vector3.Distance(CardPoints[arr[i]].transform.position, Cards[index].transform.position) >= 0.001f)
        {
            Cards[index].transform.position = Vector3.MoveTowards(Cards[index].transform.position, CardPoints[i].transform.position, Time.deltaTime * 1);

            yield return new WaitForEndOfFrame();
        }
    }


    private void randomizeArray(int [] arr)
    {
        

        for (int i = 0; i < arr.Length; i++)
        {
            Random rnd = new Random();
            swap(arr, i, rnd.Next(i, CardPoints.Length));
        }
    }

    private void swap(int[] arr, int id1, int id2)
    {
        var temp = arr[id1];
        arr[id1] = arr[id2];
        arr[id2] = temp;
    }

    public void removeGalliardCollider() //bug fix (cards were unclickable)
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

 
}
