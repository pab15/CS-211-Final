using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NetworkGraph
{
    private Dictionary<NetworkNode, List<NodeConnections>> nodes = new Dictionary<NetworkNode, List<NodeConnections>>();
    public NetworkGraph()
    {

    }
    public void addNode(NetworkNode newNode)
    {
        if (this.nodes.Count == 0)
        {
            List<NodeConnections> toAdd = new List<NodeConnections>();
            this.nodes.Add(newNode, toAdd);
        }
        else
        {
            foreach (NetworkNode existingNode in this.nodes.Keys.ToList())
            {
                if (existingNode.testCompatibility(newNode) == true)
                {
                    NodeConnections newConnectionToOld = new NodeConnections(newNode, existingNode);
                    NodeConnections oldConnectionToNew = new NodeConnections(existingNode, newNode);
                    this.nodes[existingNode].Add(oldConnectionToNew);
                    if (this.nodes.ContainsKey(newNode) == true)
                    {
                        this.nodes[newNode].Add(newConnectionToOld);
                    }
                    else
                    {
                        List<NodeConnections> toAdd = new List<NodeConnections>();
                        toAdd.Add(newConnectionToOld);
                        this.nodes.Add(newNode, toAdd);
                    }
                }
            }
        }
    }
    public Dictionary<NetworkNode, List<NodeConnections>> getGraph()
    {
        return this.nodes;
    }
    public void setGraph(Dictionary<NetworkNode, List<NodeConnections>> newGraph)
    {
        this.nodes = newGraph;
    }
}
