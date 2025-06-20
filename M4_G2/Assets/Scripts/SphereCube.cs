using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCube : MonoBehaviour
{

    public GameObject cubePrefab;
    public Transform parent;
    public int count = 500;        
    public float radius = 5f;      

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 direction = Random.onUnitSphere;
            Vector3 position = direction * radius;

            GameObject cube = Instantiate(cubePrefab, position, Quaternion.LookRotation(direction));

        
        }
    }
}


