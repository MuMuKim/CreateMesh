using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var p = FindObjectOfType<UnityEventTest>();
        p.A.AddListener(OnInputSpace);
        p.b += Test;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInputSpace()
    {
        Debug.Log("스페이스");
    }
    public void Test()
    {
        Debug.Log("하이요");
    }
}
