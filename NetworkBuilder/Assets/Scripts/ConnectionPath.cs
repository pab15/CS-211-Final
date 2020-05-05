using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPath : IComparable<ConnectionPath>, IEnumerable<Location>
{
    private List<Location> locations = new List<Location>();
    private int pathWeight;
    public ConnectionPath()
    {

    }
    public ConnectionPath(List<Location> locations, int weight)
    {
        this.pathWeight = weight;
        this.locations = locations;
    }
    public ConnectionPath(ConnectionPath toCopy)
    {
        this.pathWeight = toCopy.getPathWeight();
        foreach (var item in toCopy.getPath())
        {
            this.locations.Add(item);
        }
    }
    public void addLocation(Location newLocation)
    {
        this.locations.Add(newLocation);
        this.pathWeight += newLocation.getLocationLength();
    }
    public void setPathWeight(int pathWeight)
    {
        this.pathWeight = pathWeight;
    }
    public List<Location> getPath()
    {
        return this.locations;
    }
    public void setPath(List<Location> path)
    {
        this.locations = path;
    }
    public int getPathWeight()
    {
        return this.pathWeight;
    }
    public Location GetMostRecentLocation()
    {
        return this.locations[this.locations.Count - 1];
    }
    public int CompareTo(object obj)
    {
        return CompareTo(obj as ConnectionPath);
    }
    public int CompareTo(ConnectionPath other)
    {
        if (other == null)
        {
            throw new Exception("Incompatable compare types.");
        }
        return pathWeight.CompareTo(other.pathWeight);
    }
    public List<Location> GetPath()
    {
        return locations;
    }
    public IEnumerator<Location> GetEnumerator()
    {
        return ((IEnumerable<Location>)locations).GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Location>)locations).GetEnumerator();
    }
}

