using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NodeConnections
{
    private NetworkNode startNode;
    private NetworkNode endNode;
    private ConnectionPath connectionPath;
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
        computeConnection();
    }
    public void setStartNode(NetworkNode startNode)
    {
        this.startNode = startNode;
    }
    public NetworkNode getStartNode()
    {
        return this.startNode;
    }
    public void setEndNode(NetworkNode endNode)
    {
        this.endNode = endNode;
    }
    public NetworkNode getEndNode()
    {
        return this.endNode;
    }
    public bool areSameConnections(NodeConnections otherConnection)
    {
        if (this.startNode == otherConnection.getStartNode() && this.endNode == otherConnection.getEndNode())
        {
            return true;
        }
        else if (this.endNode == otherConnection.getStartNode() && this.startNode == otherConnection.getEndNode())
        {
            return true;
        }
        else
        {
            return false;
        }    
    }
    public bool haveSameLocations(NodeConnections otherConnection)
    {
        if (this.startNode.getNodeLocation() == otherConnection.getStartNode().getNodeLocation() 
            && this.endNode.getNodeLocation() == otherConnection.getEndNode().getNodeLocation())
        {
            return true;
        }
        else if (this.endNode.getNodeLocation() == otherConnection.getStartNode().getNodeLocation()
            && this.startNode.getNodeLocation() == otherConnection.getEndNode().getNodeLocation())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void computeConnection()
    {
        if (this.startNode.testCompatibility(this.endNode) == false)
        {
            this.connectionLength = -1;
        }
        else
        {
            if (this.startNode.getNodeLocation() == this.endNode.getNodeLocation())
            {
                this.connectionLength = this.startNode.getNodeLocation().getLocationLength();
                List<Location> toAdd = new List<Location>();
                toAdd.Add(this.startNode.getNodeLocation());
                this.connectionPath = new ConnectionPath(toAdd, this.connectionLength);
            }
            else
            {
                ConnectionPath discoveredPath = new ConnectionPath();
                PriortyQueue<ConnectionPath> pathQueue = new PriortyQueue<ConnectionPath>();
                Dictionary<Location, int> discoveredLocations = new Dictionary<Location, int>();

                discoveredPath.addLocation(startNode.getNodeLocation());
                discoveredLocations.Add(startNode.getNodeLocation(), 1);

                pathQueue.Enqueue(discoveredPath);
                bool found = false;

                int count = 0;
                while (found == false && pathQueue.IsEmpty() == false)
                {
                    ConnectionPath current_path = new ConnectionPath(pathQueue.GetFirst());
                    pathQueue.Dequeue();
                    Location currentLocation = current_path.GetMostRecentLocation();

                    for (int i = 0; i < currentLocation.getAdjacentLocations().Count; i++)
                    {
                        ConnectionPath new_path = new ConnectionPath(current_path);
                        Location neighborLocation = currentLocation.getAdjacentLocations()[i];


                        if (neighborLocation.getLocationLength() == -1)
                        {
                            continue;
                        }
                        if (neighborLocation.getLocationName() == this.endNode.getNodeLocation().getLocationName())
                        {
                            new_path.addLocation(neighborLocation);
                            discoveredPath = new_path;
                            found = true;
                            break;
                        }
                        else if (discoveredLocations.ContainsKey(neighborLocation) == false)
                        {
                            new_path.addLocation(neighborLocation);
                            pathQueue.Enqueue(new_path);
                            discoveredLocations.Add(neighborLocation, 1);
                            count++;
                        }
                    }
                }
                this.connectionPath = discoveredPath;
                this.connectionLength = discoveredPath.getPathWeight();
            }
        }
    }
}
