using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HideTest : MonoBehaviour
{
    public GameObject test;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        test.hideFlags = HideFlags.HideInHierarchy;
        Selection.activeGameObject = test;
    }

}
