using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleHandler : MonoBehaviour
{
	[Header("Hole mesh")]
	[SerializeField] private MeshFilter meshFilter;
	[SerializeField] private MeshCollider meshCollider;

	[Header("Hole vertices radius")]
	[SerializeField] private Vector2 moveLimits;

	[SerializeField] private float radius;

	private Mesh mesh;
	private List<int> holeVertices = new List<int>();

	private List<Vector3> offsets = new List<Vector3>();
	private int holeVerticesCount;

	void Start()
	{
		mesh = meshFilter.mesh;
		FindHoleVertices();
	}

	void Update()
	{
		UpdateHoleVerticesPosition();
	}

	void UpdateHoleVerticesPosition()
	{
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < holeVerticesCount; i++)
		{
			vertices[holeVertices[i]] = transform.position + offsets[i];
		}

		mesh.vertices = vertices;
		meshFilter.mesh = mesh;
		meshCollider.sharedMesh = mesh;
	}

	void FindHoleVertices()
	{
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			float distance = Vector3.Distance(transform.position, mesh.vertices[i]);

			if (distance < radius)
			{
				
				holeVertices.Add(i);
				
				offsets.Add(mesh.vertices[i] - transform.position);
			}
		}
	
		holeVerticesCount = holeVertices.Count;
	}

}
