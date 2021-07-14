using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //추가

public class UnityEventTest : MonoBehaviour
{
    public UnityEvent A;
    public UnityAction b;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            A.Invoke();
            b.Invoke();
        }
    }
}
