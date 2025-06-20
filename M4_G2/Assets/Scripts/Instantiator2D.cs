using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator2D : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform parent;
    public int rows = 10;
    public int columns = 10;
    public float offsetRow = 0.21f;
    public float offsetColumn = 0.21f;

    void Start()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 offset = new Vector3(column * offsetColumn, -row * offsetRow);
                GameObject quad = Instantiate(cubePrefab, offset, Quaternion.identity);

                if (parent != null)
                {
                    quad.transform.SetParent(parent, false);
                }
            }

        }
    }
}
