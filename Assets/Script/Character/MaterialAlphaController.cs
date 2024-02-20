using UnityEngine;
using UnityEditor;

[DisallowMultipleComponent]
public class MaterialAlphaController : MonoBehaviour
{
    static int baseColorId = Shader.PropertyToID("_BaseColor");


    [SerializeField]
    public Color baseColor = Color.white;

    static MaterialPropertyBlock block;

    void Awake()
    {
        OnValidate();
    }

    public void SetColor(Color color)
    {

        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        baseColor = color;
        block.SetColor(baseColorId, color);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }

    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        block.SetColor(baseColorId, baseColor);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }

}