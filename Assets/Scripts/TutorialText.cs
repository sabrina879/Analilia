using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField]
    public GameObject moveText;
    public GameObject tutorialText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
      if(collider.gameObject.tag == "Player")
      {
        Debug.Log("Entered Tutorial Collider: " + tutorialText);
        moveText.SetActive(false);
        tutorialText.SetActive(true);
      }
    }
    private void OnTriggerExit(Collider collider)
    {
      if(collider.gameObject.tag == "Player")
      {
        Debug.Log("Exited Tutorial Collider");
        tutorialText.SetActive(false);
        //moveText.SetActive(true);
      }

    }
}
