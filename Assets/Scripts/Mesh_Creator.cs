using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_Creator : MonoBehaviour
{
    //public Texture image;
    protected Mesh mesh;
    protected Vector3[] vertices;
    protected int[] triangles;
    protected Vector2[] uvs;
    void Start()
    {
        //버텍스 위치 정하기
        vertices = new Vector3[]
        {
            //좌상, 우상
            new Vector3(-1f, 1f, 0f),new Vector3(1f, 1f, 0f),
            //좌하, 우하
            new Vector3(1f, -1f, 0f),new Vector3(-1f, -1f, 0f)
        };

        //UV 만들기
        uvs = new Vector2[]
        {
            //UV의 길이는 버텍스와 동일해야함
            //UV의 수치는 0~1까지임

            //좌상, 우상
            new Vector2(0f, 1f), new Vector2(1f, 1f),
            //우하, 좌하
            new Vector2(1f, 0f), new Vector2(0f, 0f),
        };

        //폴리곤 만들기
        triangles = new int[]
        {
            //버텍스 순서대로 폴리곤을 연결하여 만듬
            
            //좌상,우상,우하 = 삼각형
            0, 1, 2,
            //좌상,좌하,우하 = 삼각형
            0, 2, 3
        };

        mesh = new Mesh();
    }

    void Update()
    {
        Material material;
        if (Input.GetKey(KeyCode.A))
        {
            //메쉬데이터에 버텍스 정보와, 폴리곤 정보를 넣고
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            //->MeshFilter을 받아와 메쉬정보를 넣어줌
            GetComponent<MeshFilter>().mesh = mesh;
            if (Input.GetKey(KeyCode.B))
            {
                //매터리얼 변수에 새로운 매터리얼 클래스를 만드는데
                //->인자값으로 쉐이더 이름을 넣어줘야함
                material = new Material(Shader.Find("Standard"));
                //->MeshRenderer를 받아와 메터리얼 정보를 넣어줌
                GetComponent<MeshRenderer>().material = material;

                if (Input.GetKey(KeyCode.C))
                {
                    //메쉬데이터에 UV정보를 넣고
                    mesh.uv = uvs;
                    //메쉬데이터의 Bound(경계), Normal(방향)을 재계산해주는 함수실행
                    mesh.RecalculateBounds();
                    mesh.RecalculateNormals();
                    //Main Texture로 지정해준후, Texture의 변수를 넣어준다.
                    //material.SetTexture("_MainTex", image);
                }
            }
        }
    }
}
