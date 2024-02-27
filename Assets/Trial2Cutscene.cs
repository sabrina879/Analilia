using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial2Cutscene : MonoBehaviour
{
    public Camera SceneCam1;
    public Camera SceneCam2;
    
    public void StartCutScene()
    {
        SceneCam1.GetComponent<Camera>().enabled = true;
    }

    public void Wait()
    {
        StartCoroutine(WaitSecs());
    }

    public void CutScene2()
    {
        SceneCam1.GetComponent<Camera>().enabled = false;
        SceneCam2.GetComponent<Camera>().enabled = true;
    }

    public void DisableCam2()
    {
        SceneCam2.GetComponent<Camera>().enabled = false;
    }

    IEnumerator WaitSecs()
    {
        yield return new WaitForSeconds(12);
    }
}
