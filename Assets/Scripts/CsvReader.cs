using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvReader : MonoBehaviour
{
    public Vector3[] MakeVerticles()
    {
        StreamReader sr = null;

        sr = new StreamReader(Application.dataPath + "/CSV/" + "PlaneTest.csv");
        //버텍스를 담을 변수를 만든다
        Vector3 vertice = new Vector3();
        //버텍스를 담아둘 배열을 만든다
        Vector3[] squareVer = new Vector3[24];
        //카운트
        int count = 0;
        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            //읽어온 데이터가 마지막이 되면 Null이 된다 (방어코드)
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }

            //->Split을 사용해 ,단위로 나누어 배열에 넣는다(X,Y,Z)
            string[] data_values = data_String.Split(',');
            //버텍스를 담는 배열의 크기를 유동성있는 data_values로 정해줌 
            //squareVer = new Vector3[data_values.Length];
            //-> 3분할로 나누어진 데이터를 만들어놓은 버텍스배열의 X,Y,Z에 넣어둔다
            vertice.x = float.Parse(data_values[0]);
            vertice.y = float.Parse(data_values[1]);
            vertice.z = float.Parse(data_values[2]);

            squareVer[count] = vertice;
            ++count;

            //Debug.Log(data_values[0] + data_values[1] + data_values[2]);
        }
        //Debug.Log(squareVer[0] + "  " + squareVer[1] + "  " + squareVer[2] + "  " + squareVer[3]);
        return squareVer;
    }

    public int[] MakeTriangle()
    {
        StreamReader sr = null;

        sr = new StreamReader(Application.dataPath + "/CSV/" + "TriTest.csv");
        //폴리곤을 담아둘 배열을 만든다
        int[] squareTri = null;
        //카운트
        int count = 0;
        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            //읽어온 데이터가 마지막이 되면 Null이 된다 (방어코드)
            if (data_String == null)
            {
                endOfFile = true;
                break;

            }
            //->Split을 사용해 ,단위로 나누어 배열에 넣는다(X,Y,Z)
            string[] data_values = data_String.Split(',');
            //폴리곤을 담는 배열의 크기를 유동성있는 data_values로 정해줌 
            squareTri = new int[data_values.Length];

            for (int i = 0; i < data_values.Length; ++i)
            {
                squareTri[i] = int.Parse(data_values[i]);
            }
        }
        //Debug.Log(squareTri[0] + "  " + squareTri[1] + "  " + squareTri[2] + "  " + squareTri[3] + "  " + squareTri[4] + "  " + squareTri[5]);

        return squareTri;
    }

    public Vector2[] MakeUV()
    {
        StreamReader sr = null;

        sr = new StreamReader(Application.dataPath + "/CSV/" + "UVTest.csv");
        // UV 넘버를 담을 변수를 만든다
        Vector2 uv = new Vector2();
        // UV를 담아둘 배열을 만든다.
        Vector2[] squareUV = new Vector2[24];
        //카운트
        int count = 0;

        for (int i = 0; i < squareUV.Length; i++)
        {
            string dataString = sr.ReadLine();
            if(dataString == null)
            {
                break;
            }
            //Split을 사용해 ,단위로 나누어 배열에 넣는다(X,Y)
            string[] data_value = dataString.Split(',');
            //UV를 담는 배열의 크기를 유동성있는 data_values로 정해줌 
            //squareUV = new Vector2[data_value.Length];
            uv.x = float.Parse(data_value[0]);
            uv.y = float.Parse(data_value[1]);

            squareUV[count] = uv;
            ++count;
        }
        //Debug.Log(squareUV[0] + "  " + squareUV[1] + "  " + squareUV[2] + "  " + squareUV[3]);
        return squareUV; 
    }
}
