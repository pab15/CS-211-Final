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
            }
            else
            {
                ConnectionPath discoveredPath = new ConnectionPath();
                PriortyQueue<ConnectionPath> pathQueue = new PriortyQueue<ConnectionPath>();
                Dictionary<Location, int> discoveredLocations = new Dictionary<Location, int>();

                discoveredPath.addLocation(startNode.getNodeLocation());

                pathQueue.Enqueue(discoveredPath);
                bool found = false;

                int count = 0;
                while (found == false && pathQueue.IsEmpty() == false)
                {
                    ConnectionPath current_path = new ConnectionPath(pathQueue.GetFirst());
                    pathQueue.Dequeue();
                    Location currentLocation = new Location(current_path.GetMostRecentLocation());

                    for (int i = 0; i < currentLocation.getAdjacentLocations().Count; i++)
                    {
                        ConnectionPath new_path = new ConnectionPath(current_path);
                        Location neighborLocation = new Location(currentLocation.getAdjacentLocations()[i]);

                        var visitedLocation = neighborLocation;

                        if (visitedLocation.getLocationLength() == -1)
                        {
                            continue;
                        }
                        if (visitedLocation == this.endNode.getNodeLocation())
                        {
                            new_path.addLocation(visitedLocation);
                            discoveredPath = new_path;
                            found = true;
                            break;
                        }
                        else if (discoveredLocations.ContainsKey(visitedLocation) == false)
                        {
                            new_path.addLocation(visitedLocation);
                            pathQueue.Enqueue(new_path);
                            discoveredLocations.Add(visitedLocation, 1);
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
