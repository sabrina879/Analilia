using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;
using UnityEngine.UI;


public class Quest6Signifiers : MonoBehaviour
{
    public ParticleSystem potionSignifier;
    public ParticleSystem potionActive;
    public DialogueTreeController dialogue;
    private GameObject potionObject;
    private Text baseText;
    private Text reactantText;
    private Text extractText;




    void Start()
    {
        potionActive.Stop();
        



    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        potionSignifier.transform.position = gameObject.transform.position;
        potionSignifier.Play();


    }

    void OnMouseDown()
    {
        dialogue.StartDialogue();

        potionActive.Clear();
        potionActive.transform.position = gameObject.transform.position;
        potionActive.Play();

        potionObject = GameObject.Find(gameObject.name + " Icon");

        //BASE

        if (gameObject.name == "Guar Gum") // || gameObject.name == "Honey" || gameObject.name == "Witch Hazel")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Honey Icon").GetComponent<Image>().enabled= false;
            GameObject.Find("Witch Hazel Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Base Name").GetComponent<Text>().text = "Guar Gum";


        }
        else if (gameObject.name == "Honey")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Guar Gum Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Witch Hazel Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Base Name").GetComponent<Text>().text = "Honey";
        }
        else if (gameObject.name == "Witch Hazel")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Guar Gum Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Honey Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Base Name").GetComponent<Text>().text = "Witch Hazel";

        }

        // REACTANTS
        if (gameObject.name == "Spider Eggs") // || gameObject.name == "Honey" || gameObject.name == "Witch Hazel")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Cave Moss Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Spotted Mushroom Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Reactant Name").GetComponent<Text>().text = "Spider Eggs";
        }
        else if (gameObject.name == "Cave Moss")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Spider Eggs Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Spotted Mushroom Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Reactant Name").GetComponent<Text>().text = "Cave Moss";
        }
        else if (gameObject.name == "Spotted Mushroom")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Cave Moss Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Spider Eggs Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Reactant Name").GetComponent<Text>().text = "Spotted Mushroom";

        }

        //EXTRACTS

        if (gameObject.name == "Elderflower") // || gameObject.name == "Honey" || gameObject.name == "Witch Hazel")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Tangleweed Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Mint Leaves Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Extract Name").GetComponent<Text>().text = "Elderflower";

        }
        else if (gameObject.name == "Tangleweed")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Elderflower Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Mint Leaves Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Extract Name").GetComponent<Text>().text = "Tangleweed";
        }
        else if (gameObject.name == "Mint Leaves")
        {
            potionObject.GetComponent<Image>().enabled = true;
            GameObject.Find("Elderflower Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Tangleweed Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Extract Name").GetComponent<Text>().text = "Mint Leaves";

        }




    }
}
