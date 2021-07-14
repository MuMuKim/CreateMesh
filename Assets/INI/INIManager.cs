using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class INIManager : MonoBehaviour
{
    INIParser ini = new INIParser();
    public Color[] colorInfo;
    // Start is called before the first frame update
    void Start()
    {
        LoadColorINI(Application.dataPath + "/INI/" + "Color.ini");

        //Debug.Log("INI" + ini.FileName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadColorINI(string path)
    {
        ini.Open(path);
        //Value : 카운트 41개
        int colorCount = int.Parse(ini.ReadValue("Color Count", "count", "0"));

        //컬러 배열의 크기를 카운트(41)로 초기화
        colorInfo = new Color[colorCount];

        for (int i = 0; i < colorCount; i++)
        {
            //string 배열 Type으로 Value(RGB)값을 Split으로 , 로 나눠서 담아준
            string[] sp = ini.ReadValue("Color", (i + 1).ToString(), "0").Split(',');

            float R = float.Parse(sp[0]);
            float G = float.Parse(sp[1]);
            float B = float.Parse(sp[2]);

            Color color = new Color(R, G, B, 1f);
            colorInfo[i] = color;

            //Debug.Log("INIColor : " + colorInfo[i]);
        }

        ini.Close();
    }
}
