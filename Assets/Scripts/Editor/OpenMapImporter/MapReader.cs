using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

internal sealed class MapReader 
{
    [HideInInspector]
    public Dictionary<ulong, OsmNode> nodes;

    [HideInInspector]
    public OsmBounds bounds;

    [HideInInspector]
    public List<OsmWay> ways;

	// Use this for initialization
	public void Read(string resourceFile)
    {
        nodes = new Dictionary<ulong, OsmNode>();
        ways = new List<OsmWay>();

        var xmlText = File.ReadAllText(resourceFile);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlText);

        SetBounds(doc.SelectSingleNode("/osm/bounds"));
        GetNodes(doc.SelectNodes("/osm/node"));
        GetWays(doc.SelectNodes("/osm/way"));
	}

    void GetWays(XmlNodeList xmlNodeList)
    {
       foreach(XmlNode node in xmlNodeList)
        {
            OsmWay way = new OsmWay(node);
            ways.Add(way);
        }
    }

    void GetNodes(XmlNodeList xmlNodeList)
    {
        foreach (XmlNode n in xmlNodeList)
        {
            OsmNode node = new OsmNode(n);
            nodes[node.ID] = node;
        }
    }

    void SetBounds(XmlNode xmlNode)
    {
        bounds = new OsmBounds(xmlNode);
    }
}
