using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaManager : MonoBehaviour
{
    [SerializeField]
    MaterialAlphaController[] materialAlphaControllers;

    [SerializeField]
    public Color baseColor;

    [Range(0f, 1f)]
    public float Alpha;
    // Start is called before the first frame update
    private void Start()
    {
        baseColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        baseColor.a = Alpha;
        for (int i = 0; i < materialAlphaControllers.Length; i++)
        {
            materialAlphaControllers[i].SetColor(baseColor);

        }

    }
}
