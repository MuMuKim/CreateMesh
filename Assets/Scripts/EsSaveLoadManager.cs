using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES3Internal;
public class EsSaveLoadManager : MonoBehaviour
{
    public float test;

    void Start()
    {
        if(ES3.KeyExists("Transform"))
        {
            test = (float)ES3.Load("Transform");

            Debug.Log(ES3.Load("Transform"));
        }
    }
}
