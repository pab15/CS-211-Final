using System;
using System.Collections.Generic;
using System.Linq;

public class NetworkNode
{
    private string nodeName;
    private string nodeLocation;

    public NetworkNode()
    {

    }
    public NetworkNode(string nodeName, string nodeLocation)
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
    public void setNodeLocation(string nodeLocation)
    {
        this.nodeLocation = nodeLocation;
    }
    public string getNodeLocation()
    {
        return this.nodeName;
    }
}
