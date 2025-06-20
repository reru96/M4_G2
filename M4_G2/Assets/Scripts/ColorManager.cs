using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    public Color selectedColor { get; private set; }

    public void SetColor(Color color)
    {
        selectedColor = color;
        if (_renderer != null)
        {
            _renderer.material.color = selectedColor;
        }
    }

    void Start()
    {
        if (_renderer == null)
        {
            _renderer = GetComponent<Renderer>();
        }
    }
}
