using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public GameObject arrow;
    public GameObject rayPosObject;

    Vector3 hitPoint;
    Vector3 rayPos;
    private void Update()
    {
        Debug.DrawLine(rayPos, hitPoint, Color.red, 50f);
        Debug.Log("HIt.Po X: " + (int)hitPoint.x + (int)hitPoint.y + (int)hitPoint.z);

    }

    private void OnCollisionStay(Collision collision)
    {
        RaycastHit hit;

        if (collision.transform.eulerAngles.x >0f && collision.transform.eulerAngles.x <5)
        {
            rayPos = transform.position - collision.transform.forward * 10;


            if(Physics.Raycast(rayPos,collision.transform.forward, out hit, Mathf.Infinity, 1<<8))
            {
                hitPoint = hit.point;
            }
            rayPosObject.transform.position = rayPos;

            arrow.transform.position = hitPoint;
        }
        else if (collision.transform.eulerAngles.x == 90f || collision.transform.eulerAngles.x == 270f)
        {
            rayPos = transform.position - collision.transform.forward * 10f;

            if (Physics.Raycast(rayPos, collision.transform.forward, out hit, Mathf.Infinity, 1 << 8)) hitPoint = hit.point;

            rayPosObject.transform.position = rayPos;

            arrow.transform.position = hitPoint;
            return;
        }
    }
}
