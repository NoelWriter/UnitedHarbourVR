﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TerrainMaker : InfrastructureBehaviour
{
    public Material Default;

    IEnumerator Start()
    {
        while (!map.IsReady)
        {
            yield return null;
        }

        foreach (var way in map.ways.FindAll((w) => { return w.IsLand && w.NodeIDs.Count > 1; }))
        {
            GameObject go = new GameObject();
            Vector3 localOrigin = GetCentre(way);
            go.transform.position = localOrigin - map.bounds.Centre;

            MeshFilter mf = go.AddComponent<MeshFilter>();
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.material = Default;

            List<Vector2> vertices2D = new List<Vector2>();

            for (int i = 1; i < way.NodeIDs.Count; i++)
            {
                OsmNode p1 = map.nodes[way.NodeIDs[i]];

                Vector2 v1 = p1 - localOrigin;
                Vector2 rounded = new Vector2(Mathf.Floor((p1 - localOrigin).x), Mathf.Floor((p1 - localOrigin).z));

                vertices2D.Add(rounded);
            }

            // Use the triangulator to get indices for creating triangles
            Triangulator tr = new Triangulator(vertices2D.ToArray());
            int[] indices = tr.Triangulate();

            // Create the Vector3 vertices
            Vector3[] vertices = new Vector3[vertices2D.ToArray().Length];
            for (int i2 = 0; i2 < vertices.Length; i2++)
            {
                vertices[i2] = new Vector3(vertices2D[i2].x, vertices2D[i2].y, 0);
            }

            mf.mesh.vertices = vertices;
            mf.mesh.triangles = indices;
            mf.mesh.RecalculateNormals();
            mf.mesh.RecalculateBounds();

            var angle = go.transform.eulerAngles;
            angle.x = 90;
            go.transform.eulerAngles = angle;
        }
        yield return null;
    }
}
