using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest5Book1 : MonoBehaviour
{
    public GameObject ElementalMagic;
    public ParticleSystem lever2;
    public GameObject Point;
    private int Animspeed = 5;

    void Start()
    {
        Debug.Log("Stopping FX animation");
        ElementalMagic.GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Light Magic").GetComponent<ParticleSystem>().Stop();
        lever2.Stop();
        
    }

    public IEnumerator MovetoBook()
    {
        ElementalMagic.GetComponent<ParticleSystem>().Play();
        ElementalMagic.GetComponent<AudioSource>().Play();


        while (Vector3.Distance(Point.transform.position, ElementalMagic.transform.position) >= 0.1f)
        {
            ElementalMagic.transform.position = Vector3.MoveTowards(ElementalMagic.transform.position, Point.transform.position, Time.deltaTime * Animspeed);

            yield return new WaitForEndOfFrame();
        }

    }

    public void resetFX()
    {
        ElementalMagic.GetComponent<ParticleSystem>().Stop();
        ElementalMagic.GetComponent<AudioSource>().Stop();
        ElementalMagic.SetActive(false);


        
        if (ElementalMagic.name == "BubblesFX")
        {
            GameObject.Find("WaterHit").GetComponent<ParticleSystem>().Play();
            GameObject.Find("WaterHit").GetComponent<AudioSource>().Play();

            ElementalMagic.transform.position = GameObject.Find("WaterStart").transform.position;
        }
        else if (ElementalMagic.name == "FireFX")
        {
            GameObject.Find("FireHit").GetComponent<ParticleSystem>().Play();
            GameObject.Find("FireHit").GetComponent<AudioSource>().Play();
            ElementalMagic.transform.position = GameObject.Find("FireStart").transform.position;
           


        }

        else if (ElementalMagic.name == "TornadoFX")
        {
            ElementalMagic.transform.position = GameObject.Find("NatureStart").transform.position;
            GameObject.Find("NatureHit").GetComponent<ParticleSystem>().Play();
            GameObject.Find("NatureHit").GetComponent<AudioSource>().Play();

            GameObject.Find("Light Magic").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Dark Magic").SetActive(false);
            GameObject.Find("Book1").tag = "Interactable";

            GameObject.Find("Stone Vessel #1").tag = "Untagged";
            GameObject.Find("Stone Vessel #2").tag = "Untagged";
            GameObject.Find("Stone Vessel #3").tag = "Untagged";
            lever2.Play();
            GameObject.Find("Lever2").tag = "Interactable";

        }

        ElementalMagic.SetActive(true);
        ElementalMagic.GetComponent<ParticleSystem>().Stop();
        ElementalMagic.GetComponent<AudioSource>().Stop();



    }



}

