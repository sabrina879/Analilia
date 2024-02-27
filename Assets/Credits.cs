using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;

public class Credits : MonoBehaviour
{
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Screen4;
    public GameObject Screen5;
    public GameObject Screen6;
    public GameObject Screen7;

    public DialogueTreeController ending;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(credits());
    }

    IEnumerator credits()
    {
        yield return new WaitForSeconds(8);

        Screen1.SetActive(false);
        Screen2.SetActive(true);

        yield return new WaitForSeconds(4);

        Screen2.SetActive(false);
        Screen3.SetActive(true);

        yield return new WaitForSeconds(4);

        Screen3.SetActive(false);
        Screen4.SetActive(true);  

        yield return new WaitForSeconds(4);

        Screen4.SetActive(false);
        Screen5.SetActive(true);   
         
        yield return new WaitForSeconds(4);

        Screen5.SetActive(false);
        Screen6.SetActive(true);

        yield return new WaitForSeconds(4);

        Screen6.SetActive(false);
        Screen7.SetActive(true);

        yield return new WaitForSeconds(4);

        ending.StartDialogue();

    }
}
