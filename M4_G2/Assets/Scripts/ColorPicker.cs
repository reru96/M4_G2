using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    private Material mat;
    private ColorManager colorManager;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        colorManager = FindAnyObjectByType<ColorManager>();
    }

    void OnMouseDown()
    {
        colorManager.SetColor(mat.color);
    }
}
