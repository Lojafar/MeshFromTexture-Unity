using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Example : MonoBehaviour
{
    [SerializeField] Texture2D textureeForMesh;
    [SerializeField] float meshScale;

    MeshFromTexture meshFromTexture;
    MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFromTexture = new MeshFromTexture();
    }
    void Start()
    {
        Regenerate();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Regenerate();
        }
    }
    void Regenerate()
    {
        // for sprite use meshFromTexture.Generate(sprite.texture)
        meshFilter.mesh = meshFromTexture.Generate(textureeForMesh, meshScale);
    }

}
