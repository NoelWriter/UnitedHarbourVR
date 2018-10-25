using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapReader))]

abstract class InfrastructureBehaviour
{

    protected MapReader map;

    public InfrastructureBehaviour(MapReader mapReader)
    {
        map = mapReader;
    }

    //public abstract IEnumerable<int> Process();

    protected Vector3 GetCentre(OsmWay way)
    {
        Vector3 total = Vector3.zero;

        foreach(var id in way.NodeIDs)
        {
            total += map.nodes[id];
        }

        return total / way.NodeIDs.Count;
    }

}
