using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MapReader))]
public class RoadMaker : MonoBehaviour
{
    MapReader map;

    IEnumerator Start()
    {
        map = GetComponent<MapReader>();
        while (!map.IsReady)
        {
            yield return null;
        }
    }
}
