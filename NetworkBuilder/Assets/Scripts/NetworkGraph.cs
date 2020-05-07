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
    public Dictionary<NetworkNode, List<NodeConnections>> getGraph()
    {
        return this.nodes;
    }
    public void setGraph(Dictionary<NetworkNode, List<NodeConnections>> newGraph)
    {
        this.nodes = newGraph;
    }
    public void insertPair(NetworkNode node, List<NodeConnections> connections)
    {
        if (this.nodes.ContainsKey(node) == true)
        {
            if (this.nodes[node].Count == 0)
            {
                foreach (NodeConnections connection in connections)
                {
                    this.nodes[node].Add(connection);
                }
            }
            else
            {
                Dictionary<NodeConnections, int> activeConnections = new Dictionary<NodeConnections, int>();
                foreach (NodeConnections activeConnection in this.nodes[node])
                {
                    if (activeConnections.ContainsKey(activeConnection) == false)
                    {
                        activeConnections.Add(activeConnection, 1);
                    }
                }
                foreach (NodeConnections connection in connections)
                {
                    if (activeConnections.ContainsKey(connection) == false)
                    {
                        this.nodes[node].Add(connection);
                    }
                }
            }
        }
        else
        {
            this.nodes.Add(node, connections);
        }
    }
    public void insertConnection(NetworkNode node, NodeConnections connection)
    {
        if (this.nodes.ContainsKey(node) == true)
        {
            if (this.nodes[node].Count == 0)
            {
                this.nodes[node].Add(connection);
            }
            else
            {
                Dictionary<NodeConnections, int> activeConnections = new Dictionary<NodeConnections, int>();
                foreach (NodeConnections activeConnection in this.nodes[node])
                {
                    if (activeConnections.ContainsKey(activeConnection) == false)
                    {
                        activeConnections.Add(activeConnection, 1);
                    }
                }
                if (activeConnections.ContainsKey(connection) == false)
                {
                    this.nodes[node].Add(connection);
                }
            }
        }
        else
        {
            List<NodeConnections> connectionList = new List<NodeConnections>();
            connectionList.Add(connection);
            this.nodes.Add(node, connectionList);
        }
    }
    public void insertNode(NetworkNode node)
    {
        if (this.nodes.ContainsKey(node) == false)
        {
            this.nodes.Add(node, new List<NodeConnections>());
        }
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
                    if (existingNode.getNodeName() == "router" || existingNode.getNodeName() == "switch" || existingNode.getNodeName() == "accesspoint")
                    {
                        NodeConnections oldConnectionToNew = new NodeConnections(existingNode, newNode);
                        this.nodes[existingNode].Add(oldConnectionToNew);
                        if (this.nodes.ContainsKey(newNode) == false)
                        {
                            this.nodes.Add(newNode, new List<NodeConnections>());
                        }
                    }
                    else if (newNode.getNodeName() == "router" || newNode.getNodeName() == "switch" || newNode.getNodeName() == "accesspoint")
                    {
                        NodeConnections newConnectionToOld = new NodeConnections(newNode, existingNode);
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
    }
    public NetworkGraph findFinalGraph()
    {
        NetworkGraph returnGraph = new NetworkGraph();
        Dictionary<NetworkNode, NodeConnections> endPoints = new Dictionary<NetworkNode, NodeConnections>();
        foreach (NetworkNode existingNode in this.nodes.Keys.ToList())
        {
            returnGraph.insertNode(existingNode);
            if (this.nodes[existingNode].Count > 0)
            {
                foreach (NodeConnections connection in this.nodes[existingNode])
                {
                    if (endPoints.ContainsKey(connection.getEndNode()) == true)
                    {
                        NodeConnections test = endPoints[connection.getEndNode()];
                        if (endPoints[connection.getEndNode()].getConnectionLength() >= connection.getConnectionLength())
                        {
                            endPoints[connection.getEndNode()] = connection;
                        }
                    }
                    else
                    {
                        endPoints.Add(connection.getEndNode(), connection);
                    }
                }
            }
        }
        foreach (NetworkNode endPoint in endPoints.Keys.ToList())
        {
            returnGraph.insertConnection(endPoints[endPoint].getStartNode(), endPoints[endPoint]);
        }
        return returnGraph;
    }
}
