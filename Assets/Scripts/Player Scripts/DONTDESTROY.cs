using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONTDESTROY : MonoBehaviour
{
    public string ID;

    private void Awake()
    {
        ID = name + transform.position.ToString();
    }

    void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < FindObjectsOfType<DONTDESTROY>().Length; i++)
        {
            DontDestroyOnLoad(gameObject);
            FindObjectsOfType<DONTDESTROY>()[i] = this;

            if (FindObjectsOfType<DONTDESTROY>()[i] != this)
            {
                if (FindObjectsOfType<DONTDESTROY>()[i].ID == ID)
                {
                    Destroy(gameObject);
                }
            }

        }
    }

    void Update()
    {

    }
}

