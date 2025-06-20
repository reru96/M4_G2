using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class SetColor : MonoBehaviour
{

    private Material mat;
    private ColorManager colorManager;
    public Ray ray;
    private Camera main;

    void Start()
    {
        main = Camera.main;
        mat = GetComponent<Renderer>().material;
        colorManager = FindAnyObjectByType<ColorManager>();
    }



    void Update()
    {
            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit _hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Renderer rend = hit.collider.GetComponent<Renderer>();

                if (rend != null)
                {

                    rend.material.color = colorManager.selectedColor;

                }

            }
        }
        
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out _hit))
            {
                Renderer rend = _hit.collider.GetComponent<Renderer>();
                if (rend != null && _hit.collider.CompareTag("Quad"))
                {
                    Debug.Log(_hit.collider.gameObject.name);
                    rend.material.SetColor("_BaseColor", Color.white);
                    
                }
            }
        }
                
            
        

    }

}

