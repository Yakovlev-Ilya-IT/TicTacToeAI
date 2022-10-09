using UnityEngine;


public class CellBaseView : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;

    public float Size => _meshFilter.sharedMesh.bounds.size.z;
}
