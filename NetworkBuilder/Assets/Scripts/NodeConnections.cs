using System;
using System.Collections.Generic;
using System.Linq;

public class NodeConnections
{
    private NetworkNode startNode;
    private NetworkNode endNode;
    private int connectionLength;

    public NodeConnections()
    {
        this.startNode = null;
        this.endNode = null;
        this.connectionLength = -1;
    }
    public NodeConnections(NetworkNode startNode, NetworkNode endNode)
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }
    private void computeConnectionLength()
    {
        if (startNode == null && endNode == null)
        {
            this.connectionLength = -1;
        }
        else if (startNode.getNodeLocation() == endNode.getNodeLocation())
        {
            this.connectionLength = 1;
        }
        
    }
}
