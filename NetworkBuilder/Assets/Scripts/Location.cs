using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Location
{
    private string locationName;
    private int locationLength;
    private List<Location> adjacentLocations = new List<Location>();
    private Vector3 coordinates;
    public Location()
    {

    }
    public Location(Location toCopy)
    {
        this.locationName = toCopy.getLocationName();
        this.locationLength = toCopy.getLocationLength();
        this.adjacentLocations = toCopy.getAdjacentLocations();
    }
    public Location(string locationName, int locationLength)
    {
        this.locationName = locationName;
        this.locationLength = locationLength;
    }
    public Location(string locationName, int locationLength, Vector3 coordinates)
    {
        this.locationName = locationName;
        this.locationLength = locationLength;
        this.coordinates = coordinates;
    }
    public string getLocationName()
    {
        return this.locationName;
    }
    public void setLocationName(string locationName)
    {
        this.locationName = locationName;
    }
    public int getLocationLength()
    {
        return this.locationLength;
    }
    public void setLocationLength(int locationLength)
    {
        this.locationLength = locationLength;
    }
    public Vector3 getCoordinates()
    {
        return this.coordinates;
    }
    public void setCoordinates(Vector3 coordinates)
    {
        this.coordinates = coordinates;
    }
    public List<Location> getAdjacentLocations()
    {
        return this.adjacentLocations;
    }
    public void setAdjacentLocations(List<Location> adjacentLocations)
    {
        this.adjacentLocations = adjacentLocations;
    }
    public void addAdjacentLocation(Location adjacentLocation)
    {
        this.adjacentLocations.Add(adjacentLocation);
    }
}
