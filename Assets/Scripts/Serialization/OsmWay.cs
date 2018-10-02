﻿using System.Collections.Generic;
using System.Xml;

public class OsmWay : BaseOsm
{
    public ulong ID { get; private set; }
    public bool Visible { get; private set; }
    public List<ulong> NodeIDs { get; private set; }
    public bool IsBoundary { get; private set; }
    public bool IsRoad { get; private set; }
    public bool IsBuilding { get; private set; }
    public float Height { get; private set; }
    public bool IsIndustrial { get; private set; }
    public bool IsResidential { get; private set; }

    public OsmWay(XmlNode node)
    {
        NodeIDs = new List<ulong>();
        Height = 3.0f;
        ID = GetAttribute<ulong>("id", node.Attributes);
        Visible = GetAttribute<bool>("visible", node.Attributes);

        XmlNodeList nds = node.SelectNodes("nd");
        foreach(XmlNode n in nds)
        {
            ulong refNo = GetAttribute<ulong>("ref", n.Attributes);
            NodeIDs.Add(refNo);
        }

        if (NodeIDs.Count > 1)
        {
            IsBoundary = NodeIDs[0] == NodeIDs[NodeIDs.Count - 1];
        }

        XmlNodeList tags = node.SelectNodes("tag");
        foreach(XmlNode t in tags)
        {
            string key = GetAttribute<string>("k", t.Attributes);
            if (key == "building:levels")
            {
                Height = 3.0f * GetAttribute<float>("v", t.Attributes);
            }
            else if (key == "height")
            {
                Height = 1.0f * GetAttribute<float>("v", t.Attributes);
            }
            else if (key == "building")
            {
                IsBuilding = true;
                if (GetAttribute<string>("v", t.Attributes) == "industrial")
                {
                    Height = 20.0f;
                    IsIndustrial = true;
                } else if (GetAttribute<string>("v", t.Attributes) == "house")
                {
                    Height = 8.0f;
                    IsResidential = true;
                }
                //IsBuilding = GetAttribute<string>("v", t.Attributes) == "yes";
            }
            else if (key == "highway")
            {
                IsRoad = true;
            }
            else if (key == "waterway")
            {

            }
        }
    }
}
