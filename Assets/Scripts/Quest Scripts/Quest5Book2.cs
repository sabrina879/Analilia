using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest5Book2 : MonoBehaviour
{
    public Light colorLight;
    public GameObject orbColor;
    public ParticleSystem signifier;

    public Material []colors; //6 colors [Red, Blue, Yellow, Purple, Green, Orange]
    private bool red;
    private bool blue;
    private bool yellow;



    void Start()
    {
        GameObject.Find("Light Magic 2").GetComponent<ParticleSystem>().Stop();
      
    }

    public void playSignifier()
    {
        signifier.Play();
    }

    public void setUnactive()
    {
        gameObject.tag = "Untagged";
    }

    

    public void changeToRed()
    {
        orbColor.GetComponent<MeshRenderer>().material = colors[0];
        colorLight.GetComponent<Light>().color = Color.red;
        red = true;

        if (red == true && blue == true)
        {
            changeToPurple();
            red = false;
            blue = false;
            yellow = false;
        }

        else if (red == true && yellow == true)
        {
            changeToOrange();
            red = false;
            blue = false;
            yellow = false;
        }
    }

    public void changeToBlue()
    {
        orbColor.GetComponent<MeshRenderer>().material = colors[1];
        colorLight.GetComponent<Light>().color = Color.blue;

        blue = true;
        if (blue == true && red == true)
        {
            changeToPurple();
            red = false;
            blue = false;
            yellow = false;
        }
        else if (blue == true && yellow == true)
        {
            changeToGreen();
            red = false;
            blue = false;
            yellow = false;
        }
    }

    public void changeToYellow()
    {
        orbColor.GetComponent<MeshRenderer>().material = colors[2];
        colorLight.GetComponent<Light>().color = Color.yellow;

        yellow = true;

        if (yellow == true && red == true)
        {
            changeToOrange();
            red = false;
            blue = false;
            yellow = false;
        }
        else if (yellow == true && blue == true)
        {
            changeToGreen();
            red = false;
            blue = false;
            yellow = false;
        }
    }

    private void changeToPurple()
    {
        colorLight.GetComponent<Light>().color = Color.magenta;

        orbColor.GetComponent<MeshRenderer>().material = colors[3];
    }

    private void changeToGreen()
    {
        colorLight.GetComponent<Light>().color = Color.green;

        orbColor.GetComponent<MeshRenderer>().material = colors[4];
    }
    private void changeToOrange()
    {
        colorLight.GetComponent<Light>().color = new Color(1f,.5395f,0f);
        orbColor.GetComponent<MeshRenderer>().material = colors[5];
    }

    public bool OrangeChecker()
    {
        return (colorLight.GetComponent<Light>().color == new Color(1f, .5395f, 0f));
    }
    public bool PurpleChecker()
    {
        return (colorLight.GetComponent<Light>().color == Color.magenta);
    }
    public bool GreenChecker()
    {
        return (colorLight.GetComponent<Light>().color == Color.green);
    }

    public void unsealBook()
    {
        GameObject.Find("Light Magic 2").GetComponent<ParticleSystem>().Play();
        GameObject.Find("Dark Magic 2").SetActive(false);
        GameObject.Find("Book2").tag = "Interactable";

        GameObject.Find("Color Orb").tag = "Untagged";

    }




}
