using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]


public class Grid : MonoBehaviour
{
   
    public int xSize, ySize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
