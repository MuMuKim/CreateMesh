using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //추가

public class UnityEventTest : MonoBehaviour
{
    public UnityEvent A;
    public UnityAction b;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            A.Invoke();
            b.Invoke();
        }
    }
}
