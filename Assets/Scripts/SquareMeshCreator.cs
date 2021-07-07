using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMeshCreator : MeshCreator
{
    CsvReader csv = new CsvReader();
    // Start is called before the first frame update
    void Start()
    {
        CreateVertex();
        CreateTriangle();
        CreateMesh();
        CreateUV();
        CreateMaterial();
    }

    void CreateVertex()
    {
        Vector3[] verRander = csv.MakeVerticles();
        vertices = new Vector3[]
        {
            //front
            verRander[0], verRander[1],
            verRander[2], verRander[3],
            //back
            verRander[4], verRander[5],
            verRander[6], verRander[7],
            //up
            verRander[8], verRander[9],
            verRander[10], verRander[11],
            //down
            verRander[12], verRander[13],
            verRander[14], verRander[15],
            //Left
            verRander[16], verRander[17],
            verRander[18], verRander[19],
            //Right
            verRander[20], verRander[21],
            verRander[22], verRander[23]
        };
    }

    void CreateTriangle()
    {
        int[] triRender = csv.MakeTriangle();
        triangles = new int[]
        {
            //버텍스 순서대로 폴리곤을 연결하여 만듬
            
            //front
            //좌상,우상,좌하 = 삼각형
            triRender[0], triRender[1], triRender[2],
            //좌상,좌하,우하 = 삼각형
            triRender[3], triRender[4], triRender[5],
            
            //back
            triRender[6], triRender[7], triRender[8],
            triRender[9], triRender[10], triRender[11],

            //up
            triRender[12], triRender[13], triRender[14],
            triRender[15], triRender[16], triRender[17],

            //Down
            triRender[18], triRender[19], triRender[20],
            triRender[21], triRender[22], triRender[23],

            //Left
            triRender[24], triRender[25], triRender[26],
            triRender[27], triRender[28], triRender[29],

            //Right
            triRender[30], triRender[31], triRender[32],
            triRender[33], triRender[34], triRender[35]
        };
    }

    void CreateMesh()
    {
        mesh = new Mesh();
        //메쉬데이터에 버텍스 정보와, 폴리곤 정보를 넣고
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //->MeshFilter을 받아와 메쉬정보를 넣어줌
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void CreateUV()
    {
        Vector2[] uvRender = csv.MakeUV();
        uvs = new Vector2[]
        {
            uvRender[0], 
            uvRender[1], 
            uvRender[2], 
            uvRender[3],

            uvRender[4],
            uvRender[5],
            uvRender[6],
            uvRender[7],

            uvRender[8],
            uvRender[9],
            uvRender[10],
            uvRender[11],

            uvRender[12],
            uvRender[13],
            uvRender[14],
            uvRender[15],

            uvRender[16],
            uvRender[17],
            uvRender[18],
            uvRender[19],
            
            uvRender[20],
            uvRender[21],
            uvRender[22],
            uvRender[23],

        };
    }

    void CreateMaterial()
    {
        Material material;
        //메터리얼 변수에 재로운 매터리얼 클래스를 만들 때
        //->인자값으로 쉐이더 이름을 정해줘야함
        material = new Material(Shader.Find("Standard"));
        //MeshRenderer를 받아와 메터리얼 정보를 넣어줌
        GetComponent<MeshRenderer>().material = material;

        //Mesh데이터에 만든 uv정보를 넣고
        mesh.uv = uvs;
        //메쉬데이터의 Bound(경계), Normal(방향)을 재계산해주는 함수실행
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        //Main Texture로 지정해준 후, Texture의 변수를 넣어준다.
        //material.SetTexture("_MainTex", image);
        material.color = Color.black;
    }
}
