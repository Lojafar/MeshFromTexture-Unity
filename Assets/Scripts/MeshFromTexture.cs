using System.Collections.Generic;
using UnityEngine;

public class MeshFromTexture
{
    Texture2D currentTexture;

    float scale = 1f;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Color> colors = new List<Color>();
    public Mesh Generate(Texture2D texture, float meshScale = 1f)
    {
        if (texture == null)
        {
            Debug.LogError("Texture is not setted. Empty mesh returned");
            return new Mesh();
        }
        if(meshScale < 0)
        {
            Debug.LogError("MeshScale is less than 0. Setted 0.1f");
            scale = 0.1f;
        }
        scale = meshScale;
        currentTexture = texture;
        vertices.Clear();
        triangles.Clear();
        colors.Clear();

        GenerateMeshData();

       return CreateMesh();
    }
    void GenerateMeshData()
    {
        for (int x = 0; x < currentTexture.width; x++)
        {
            for (int y = 0; y < currentTexture.height; y++)
            {
                if (currentTexture.GetPixel(x, y).a != 0)
                {
                    Vector3 pos = new Vector3(x * scale, y * scale);
                    AddForwardSide(pos);
                    AddBackSide(pos);

                    if (currentTexture.GetPixel(x + 1, y).a == 0 || x == currentTexture.width - 1) AddRightSide(pos);
                    if (currentTexture.GetPixel(x - 1, y).a == 0 || x == 0) AddLeftSide(pos);
                    if (currentTexture.GetPixel(x, y + 1).a == 0 || y == currentTexture.height - 1) AddTopSide(pos);
                    if (currentTexture.GetPixel(x, y - 1).a == 0 || y == 0) AddBottomSide(pos);
                }
            }
        }
    }
    Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.colors = colors.ToArray();

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }
    void AddForwardSide(Vector3 position)
    {
        vertices.Add(new Vector3(0, 0, scale) + position);
        vertices.Add(new Vector3(scale , 0,  scale) + position);
        vertices.Add(new Vector3(0, scale, scale) + position);
        vertices.Add(new Vector3(scale, scale, scale) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddBackSide(Vector3 position)
    {
        vertices.Add(new Vector3(0, 0, 0) + position);
        vertices.Add(new Vector3(0, scale, 0) + position);
        vertices.Add(new Vector3(scale, 0, 0) + position);
        vertices.Add(new Vector3(scale, scale, 0) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddRightSide(Vector3 position)
    {
        vertices.Add(new Vector3(scale, 0, 0) + position);
        vertices.Add(new Vector3(scale, scale, 0) + position);
        vertices.Add(new Vector3(scale, 0, scale) + position);
        vertices.Add(new Vector3(scale, scale, scale) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddLeftSide(Vector3 position)
    {
        vertices.Add(new Vector3(0, 0, 0) + position);
        vertices.Add(new Vector3(0, 0, scale) + position);
        vertices.Add(new Vector3(0, scale, 0) + position);
        vertices.Add(new Vector3(0, scale, scale) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddTopSide(Vector3 position)
    {
        vertices.Add(new Vector3(0, scale, 0) + position);
        vertices.Add(new Vector3(0, scale, scale) + position);
        vertices.Add(new Vector3(scale, scale, 0) + position);
        vertices.Add(new Vector3(scale, scale, scale) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddBottomSide(Vector3 position)
    {
        vertices.Add(new Vector3(0, 0, 0) + position);
        vertices.Add(new Vector3(scale, 0, 0) + position);
        vertices.Add(new Vector3(0, 0, scale) + position);
        vertices.Add(new Vector3(scale, 0, scale) + position);
        AddColors(position);
        AddTriangles();
    }
    void AddColors(Vector3 position)
    {
        int textureCoordX = Mathf.FloorToInt(position.x / scale);
        int textureCoordY = Mathf.FloorToInt(position.y / scale);
        colors.Add(currentTexture.GetPixel(textureCoordX, textureCoordY));
        colors.Add(currentTexture.GetPixel(textureCoordX, textureCoordY));
        colors.Add(currentTexture.GetPixel(textureCoordX, textureCoordY));
        colors.Add(currentTexture.GetPixel(textureCoordX, textureCoordY));
    }
    void AddTriangles()
    {
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 3);
    }
}
