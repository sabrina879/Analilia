using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;

public class Quest4Chest : MonoBehaviour
{
    public Camera ChestCamera;
    private DialogueTreeController dialogue;
    private Material originalColor;
    public Material interactColor;
    private AudioSource jewelClick;
    public AudioSource wrongClick;
    private GameObject ChestLid;
    private GameObject JEWELS;
    private GameObject APPLE;
    private GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = gameObject.GetComponent<DialogueTreeController>();
        originalColor = gameObject.GetComponent<MeshRenderer>().material;
        jewelClick = gameObject.GetComponent<AudioSource>();
        ChestLid = GameObject.Find("ChestLid");
        JEWELS = GameObject.Find("ChestLock");
        APPLE = GameObject.Find("Quest Apple");
        APPLE.GetComponent<Collider>().enabled = false;
        chest = GameObject.Find("AppleChest");
    }

    void OnMouseOver()
    {
        gameObject.GetComponent<MeshRenderer>().material = interactColor;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = originalColor;
    }

    void OnMouseDown()
    {
        dialogue.StartDialogue();
    }

    public void playJewel()
    {
        jewelClick.Play();
    }

    public void disableJewels()
    {
        JEWELS.SetActive(false);
        APPLE.GetComponent<Collider>().enabled = true;
        APPLE.tag = "Interactable";
        chest.tag = "Untagged";
    }

    public void playWrong()
    {
        wrongClick.Play();
    }

    public string nameCheck()
    {
        return gameObject.name;
    }

    public void disableCamera()
    {
        ChestCamera.enabled = false;
    }

    public IEnumerator OpenChest()
    {
        while (ChestLid.transform.rotation != new Quaternion(-0.270598054f, 0.65328151f, 0.270598054f, 0.65328151f))
        {
            // The step size is equal to speed times frame time.
            var step = 50 * Time.deltaTime;

            // Rotate our transform a step closer to the target's.
            ChestLid.transform.rotation = Quaternion.RotateTowards(ChestLid.transform.rotation, new Quaternion(-0.270598054f, 0.65328151f, 0.270598054f, 0.65328151f), step);


            yield return new WaitForEndOfFrame();
        }
    }
}
