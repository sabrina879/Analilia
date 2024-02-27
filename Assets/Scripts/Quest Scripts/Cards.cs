using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using NodeCanvas.DialogueTrees;



public class Cards : MonoBehaviour
{
    private bool flipped;
    private bool unflipped;

    private bool up;
    private bool down;

    private bool NotInDeck;

    private bool firstCard;
    private bool secondCard;

    public static int cardNumber;
    public static GameObject prevCard;

    public static int score;
    public static GameObject[] cards;
    public static GameObject[] Scoredcards;


    public static int NPCscore;
    public static bool NPCturn;

    private int previouscard;

    private Quest5Book3 book3;

    private GameObject dialogue;


    private static bool Win;
    private static bool Lose;




    // Start is called before the first frame update
   

     void OnEnable()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        Win = false;
        Lose = false;



        book3 = GameObject.Find("Galliard").GetComponent<Quest5Book3>();
        NPCturn = false;
        NPCscore = 0;

        flipped = false;
        unflipped = true;

        up = false;
        down = true;

        score = 0;

        NotInDeck = true;

        gameObject.GetComponent<ParticleSystem>().Stop();

        cards = GameObject.FindGameObjectsWithTag("Card");

        dialogue = book3.Cards[0];

        Debug.Log("CardLength" + cards.Length);


    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public IEnumerator AITurn()
    {
        Disablecards();
        int card1;
        int card2;
        Random rnd = new Random();

        card1 = rnd.Next(0, cards.Length);

        card2 = rnd.Next(0, cards.Length);

        while (card1 == card2)
        {
            Random rand = new Random();

            card2 = rand.Next(0, cards.Length);
        }


            cards[card1].GetComponent<ParticleSystem>().Play();
            Debug.Log("Picked" + cards[card1].name);



            yield return StartCoroutine(cards[card1].GetComponent<Cards>().MoveCardUp());

            yield return StartCoroutine(cards[card1].GetComponent<Cards>().FlipCards());

            cards[card2].GetComponent<ParticleSystem>().Play();
            Debug.Log("Picked" + cards[card2].name);


            yield return StartCoroutine(cards[card2].GetComponent<Cards>().MoveCardUp());

            yield return StartCoroutine(cards[card2].GetComponent<Cards>().FlipCards());

            cards[card1].GetComponent<ParticleSystem>().Stop();

            yield return StartCoroutine(cards[card1].GetComponent<Cards>().UnflipCards());

            yield return StartCoroutine(cards[card1].GetComponent<Cards>().MoveCardDown());

            cards[card2].GetComponent<ParticleSystem>().Stop();

            yield return StartCoroutine(cards[card2].GetComponent<Cards>().UnflipCards());

            yield return StartCoroutine(cards[card2].GetComponent<Cards>().MoveCardDown());




        if (cards[card1].name == cards[card2].name)
        {
            NPCscore++;

            yield return StartCoroutine(cards[card1].GetComponent<Cards>().MoveCardToDeck());

            yield return StartCoroutine(cards[card2].GetComponent<Cards>().MoveCardToDeck());

            cards = GameObject.FindGameObjectsWithTag("Card");


            Debug.Log("CardLength"+cards.Length);

            Debug.Log("Player Score: " + score + "NPC Score: " + NPCscore);

            if (cards.Length == 0)
            {
                if (NPCscore > score)
                {
                    Lose = true;
                    startDialogue();
                }

                else
                {
                    Win = true;
                    startDialogue();
                }

            }
            else
            {
                Enablecards();
                NPCturn = false;

            }

          
        }

        else if (cards[card1].name != cards[card2].name)
        {

            Enablecards();
            NPCturn = false;
        }

    }


    IEnumerator OnMouseDown()
    {
        if (cardNumber != 2 && unflipped && gameObject.tag == "Card" && gameObject.GetComponent<Collider>().enabled)
        {
            Disablecards();

                yield return StartCoroutine(MoveCardUp());
            
            
                yield return StartCoroutine(FlipCards());
            
            
                yield return StartCoroutine(MoveCardDown());
            
            cardNumber++;
            Debug.Log(cardNumber);


            if (cardNumber == 2 && prevCard.name != gameObject.name)
            {
                cardNumber = 0;
                Debug.Log(prevCard.name);
                Debug.Log(gameObject.name);

                if (prevCard.GetComponent<Cards>().flipped)
                {
                   
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().MoveCardUp());
                    

                    
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().UnflipCards());
                    

                    
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().MoveCardDown());

                }

                if (flipped)
                {
                   
                        yield return StartCoroutine(MoveCardUp());
                    

                    
                        yield return StartCoroutine(UnflipCards());
                    

                   
                        yield return StartCoroutine(MoveCardDown());
                    
                }
                StartCoroutine(AITurn());
                NPCturn = false;
            }
            else if (cardNumber == 2 && prevCard.name == gameObject.name)
            {

                prevCard.tag = ("ScoredCard");
                gameObject.tag = ("ScoredCard");

                Scoredcards = GameObject.FindGameObjectsWithTag("ScoredCard");
                Debug.Log("CardLength" + cards.Length);




                cardNumber = 0;
                score++;
                Debug.Log("Score: "+score);

                if (prevCard.GetComponent<Cards>().flipped)
                {
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().MoveCardUp());
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().UnflipCards());
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().MoveCardDown());
                        yield return StartCoroutine(prevCard.GetComponent<Cards>().MoveCardToDeck());
                }

                if (flipped)
                {

                        yield return StartCoroutine(MoveCardUp());
                        yield return StartCoroutine(UnflipCards());
                        yield return StartCoroutine(MoveCardDown());
                        yield return StartCoroutine(MoveCardToDeck());
                        cards = GameObject.FindGameObjectsWithTag("Card");

                }

                NPCturn = true;

                if (cards.Length == 0)
                {
                    if (NPCscore > score)
                    {
                        Lose = true;
                        startDialogue();

                    }
                    else
                    {
                        Win = true;
                        startDialogue();

                    }
                }
                if (cards.Length != 0)
                {
                    StartCoroutine(AITurn());
                    NPCturn = false;
                }
                
            }

            else if (cardNumber == 1)
            {
                Enablecards();
                prevCard = gameObject;
            }
        }
    }
    void OnMouseOver()
    {
        if (cardNumber !=2 && gameObject.tag == "Card" && gameObject.GetComponent<Collider>().enabled)
            gameObject.GetComponent<ParticleSystem>().Play();
    }

    public void Disablecards()
    {

        cards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject card in cards)
        {
            card.GetComponent<Collider>().enabled = false;
        }
    }

    public void Enablecards()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject card in cards)
        {
            card.GetComponent<Collider>().enabled = true;
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }


    public IEnumerator FlipCards()
    {
        Disablecards();

        while (unflipped)
        {
            // The step size is equal to speed times frame time.
            var step = 300 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, new Quaternion(0, 0, 0, 1), step);

            if (gameObject.transform.rotation == new Quaternion(0, 0, 0, 1))
            {
                flipped = true;
                unflipped = false;
                yield return new WaitForSeconds(.1f);

            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveCardUp()
    {
        Disablecards();

        while (down)
        {
            // The step size is equal to speed times frame time.
            var step = 80 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, GameObject.Find("CardUP").transform.position.y, gameObject.transform.position.z), Time.deltaTime * step);

            if (gameObject.transform.position == new Vector3(gameObject.transform.position.x, GameObject.Find("CardUP").transform.position.y, gameObject.transform.position.z))
            {
                gameObject.GetComponent<AudioSource>().Play();
                up = true;
                down = false;
                yield return new WaitForSeconds(.2f);

            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveCardDown()
    {
        Disablecards();

        while (up)
        {
            // The step size is equal to speed times frame time.
            var step = 80 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, GameObject.Find("Point1").transform.position.y, gameObject.transform.position.z), Time.deltaTime * step);

            if (gameObject.transform.position == new Vector3(gameObject.transform.position.x, GameObject.Find("Point1").transform.position.y, gameObject.transform.position.z))
            {
                gameObject.GetComponent<AudioSource>().Play();
                up = false;
                down = true;
                yield return new WaitForSeconds(.05f);

            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator UnflipCards()
    {
        Disablecards();

        while (flipped)
        {
            // The step size is equal to speed times frame time.
            var step = 300 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, new Quaternion(1, 0, 0, 0), step);

            if (gameObject.transform.rotation == new Quaternion(1, 0, 0, 0))
            {
                flipped = false;
                unflipped = true;
                yield return new WaitForSeconds(.1f);

            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveCardToDeck()
    {
        Disablecards();

        while (NotInDeck)
        {
            // The step size is equal to speed times frame time.
            var step = 300 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, GameObject.Find("Deck").transform.position, Time.deltaTime * step);

            if (gameObject.transform.position == GameObject.Find("Deck").transform.position)
            {
                GameObject.Find("Deck").GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Collider>().enabled = false;
                NotInDeck = false;
                yield return new WaitForSeconds(0.1f);

            }

            gameObject.tag = ("ScoredCard");
            Scoredcards = GameObject.FindGameObjectsWithTag("ScoredCard");

            Debug.Log("CardLength" + cards.Length);


            GameObject.Find("KeyCard").GetComponent<Collider>().enabled = true;
            GameObject.Find("JewelCard").GetComponent<Collider>().enabled = true;
            GameObject.Find("BoltCard").GetComponent<Collider>().enabled = true;
            GameObject.Find("PiggyCard").GetComponent<Collider>().enabled = true;
            GameObject.Find("HamCard").GetComponent<Collider>().enabled = true;

            yield return new WaitForEndOfFrame();
        }

    }


    public void startDialogue()
    {


        changeToPlayerScene();
        dialogue.GetComponent<InteractNPC>().Interact();




    }

    public void changeToPlayerScene()
    {
        book3.playerScene.GetComponent<Camera>().enabled = true;
        book3.memoryScene.GetComponent<Camera>().enabled = false;


        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
        Camera.main.GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Analilia").GetComponent<Player>().enabled = true;
        GameObject.Find("PlayerCanvas").GetComponent<PauseMenu>().enabled = true;
    }

    public void enableGalliard()
    {
        GameObject.Find("Galliard").GetComponent<Collider>().enabled = true;
    }


    public bool returnOutcome()
    {
        if (Win == true)
        {
            return true;
        }

        else if (Lose == true)
        {
            return false;
        }

        return false;
    
    
    }

    public void book3Interactable()
    {
        GameObject.Find("Book3").tag = "Interactable";

    }


}
