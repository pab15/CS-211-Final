using System;
using System.Collections.Generic;
using System.Linq;

public class Location
{
    private string locationName;
    private int locationLength;
    private List<Location> adjacentLocations = new List<Location>();
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
