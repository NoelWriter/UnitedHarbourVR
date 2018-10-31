using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class BuildingMaker : BaseInfrastructureMaker
{
    private Material industrialBuilding;
    private Material residentialBuilding;

    public override int NodeCount
    {
        get
        {
            return map.ways.FindAll((w) => { return w.IsBuilding && w.NodeIDs.Count > 1; }).Count;
        }
    }

    //    public Material Industrial;
    //    public Material Residential;
    //    public Material NoTag;

    public BuildingMaker(MapReader mapReader, Material industrialBuildingMaterial, Material residentialBuildingmaterial)
        : base(mapReader)
    {
        industrialBuilding = industrialBuildingMaterial;
        residentialBuilding = residentialBuildingmaterial;
    }

    public override IEnumerable<int> Process()
    {
        int count = 0;
        foreach (var way in map.ways.FindAll((w) => { return w.IsBuilding && w.NodeIDs.Count > 1; }))
        {
            if (way.IsIndustrial)
            {
                CreateObject(way, industrialBuilding, ("Building" + count.ToString()));
            }
            else if(way.IsResidential)
            {
                CreateObject(way, residentialBuilding, ("Building" + count.ToString()));
            }

            count++;
            yield return count;
        }
    }

    protected override void OnObjectCreated(OsmWay way, Vector3 origin, List<Vector3> vectors, List<Vector3> normals, List<Vector2> uvs, List<int> indices)
    {
        Vector3 oTop = new Vector3(0, way.Height, 0);

        vectors.Add(oTop);
        normals.Add(Vector3.up);
        uvs.Add(new Vector2(0.5f, 0.5f));

        for (int i = 1; i < way.NodeIDs.Count; i++)
        {
            OsmNode p1 = map.nodes[way.NodeIDs[i - 1]];
            OsmNode p2 = map.nodes[way.NodeIDs[i]];

            Vector3 v1 = p1 - origin;
            Vector3 v2 = p2 - origin;
            Vector3 v3 = v1 + new Vector3(0, way.Height, 0);
            Vector3 v4 = v2 + new Vector3(0, way.Height, 0);

            vectors.Add(v1);
            vectors.Add(v2);
            vectors.Add(v3);
            vectors.Add(v4);

            uvs.Add(new Vector2(0, 0));
            uvs.Add(new Vector2(1, 0));
            uvs.Add(new Vector2(0, 1));
            uvs.Add(new Vector2(1, 1));

            normals.Add(-Vector3.forward);
            normals.Add(-Vector3.forward);
            normals.Add(-Vector3.forward);
            normals.Add(-Vector3.forward);

            int idx1, idx2, idx3, idx4;
            idx4 = vectors.Count - 1;
            idx3 = vectors.Count - 2;
            idx2 = vectors.Count - 3;
            idx1 = vectors.Count - 4;

            indices.Add(idx1);
            indices.Add(idx3);
            indices.Add(idx2);

            indices.Add(idx3);
            indices.Add(idx4);
            indices.Add(idx2);

            indices.Add(idx2);
            indices.Add(idx3);
            indices.Add(idx1);

            indices.Add(idx2);
            indices.Add(idx4);
            indices.Add(idx3);

            indices.Add(0);
            indices.Add(idx3);
            indices.Add(idx4);

            indices.Add(idx4);
            indices.Add(idx3);
            indices.Add(0);
        }
    }
}
