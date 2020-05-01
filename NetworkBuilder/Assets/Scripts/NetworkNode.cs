using System;
using System.Collections.Generic;
using System.Linq;

public class NetworkNode
{
    private string nodeName;
    private Location nodeLocation;

    public NetworkNode()
    {

    }
    public NetworkNode(string nodeName, Location nodeLocation)
    {
        this.nodeName = nodeName;
        this.nodeLocation = nodeLocation;
    }

    public void setNodeName(string nodeName)
    {
        this.nodeName = nodeName;
    }
    public string getNodeName()
    {
        return this.nodeName;
    }
    public void setNodeLocation(Location nodeLocation)
    {
        this.nodeLocation = nodeLocation;
    }
    public Location getNodeLocation()
    {
        return this.nodeLocation;
    }

    public bool testCompatibility(NetworkNode testNode)
    {
        if (this.nodeName == null || testNode.getNodeName() == null)
        {
            return false;
        }
        if (this.nodeName == "router" && testNode.getNodeName() == "router")
        {
            return false;
        }
        else if (this.nodeName == "router" || testNode.getNodeName() == "router")
        {
            return true;
        }
        else if (this.nodeName == "switch" || testNode.getNodeName() == "switch")
        {
            return true;
        }
        else if (this.nodeName == "accesspoint" || testNode.getNodeName() == "accesspoint")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
