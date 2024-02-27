using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour
{

    public GameObject portalOpenPrefab;
    public GameObject portalIdlePrefab;
    private GameObject portalOpen;
    private GameObject portalIdle;


    void OnEnable()
    {       
        portalOpen = Instantiate(portalOpenPrefab, transform.position, transform.rotation);
        portalIdle = Instantiate(portalIdlePrefab, transform.position, transform.rotation);

        portalOpen.SetActive(true);

        StartCoroutine("PortalLoop");
    }

    IEnumerator PortalLoop()
    {

            yield return new WaitForSeconds(0.8f);
            portalOpen.SetActive(false);
            portalIdle.SetActive(true);
            yield return new WaitForSeconds(0.8f);
    } 
}