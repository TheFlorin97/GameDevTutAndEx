using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public int MaxDepth;
    private int depth;

    public float childScale;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        if (depth < MaxDepth)
        {
            StartCoroutine(CreateChildren());
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static Vector3[] childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f,0f,-90f),
        Quaternion.Euler(0f,0f,90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    private IEnumerator CreateChildren()
    {
        for(int i =0; i<childDirections.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
        }
       
       
    }

    private void Initialize (Fractal parent, int childIndex)
    {
        mesh = parent.mesh;
        material = parent.material;
        MaxDepth = parent.MaxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition =childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }
}
