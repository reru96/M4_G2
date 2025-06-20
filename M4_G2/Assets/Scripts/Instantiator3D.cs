using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator3D : MonoBehaviour
{
    public GameObject quadPrefab;
    public Transform parent;
    public int rows = 10;
    public int columns = 10;
    public float offsetRow = 0.21f;
    public float offsetColumn = 0.21f;
    public float offsetLayers = 0.21f;
    public int layers = 10;

    void Start()
    {
        for (int layer = 0; layer < layers; layer++)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Vector3 offset = new Vector3(column * offsetColumn, -row * offsetRow, -layer * offsetLayers);
                    GameObject quad = Instantiate(quadPrefab, offset, Quaternion.identity);

                    if (parent != null)
                    {
                        quad.transform.SetParent(parent, false);
                    }
                }
            }
        }
    }
}
