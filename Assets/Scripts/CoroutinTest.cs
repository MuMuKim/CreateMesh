using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinTest : MonoBehaviour
{
    bool s = false;

    // 안녕하고 나서 2초의 딜레이 동안 잘가 표시하기
    void Update()
    {
        //A 키를 누르고
        if(Input.GetKeyDown(KeyCode.A))
        {
            //s가 false면
            if(!s)
            {
                //s를 true로 바꾸고 안녕을 띄우고, 코루틴을 호출한다
                s = true;
                Debug.Log("안녕");

                StartCoroutine(Test());
            }
            else
            {
                //딜레이 시간동안 잘가를 표시한다
                Debug.Log("잘가");
            }
        }
    }

    IEnumerator Test()
    {
        //2초의 딜레이를 만들고, s를 false로 변경해 안녕 조건문에 들어가게 한다
        yield return new WaitForSeconds(2f);
        s = false;
    }
}
