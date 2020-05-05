using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Location livingRoom = new Location("livingroom", 500, new Vector3(0,0,1));
    public static Location bedroomOne = new Location("bedroom1", 600, new Vector3(0, 0, 1));
    public static Location hallway = new Location("hallway", 600, new Vector3(0, 0, 1));
    public static Location kitchen = new Location("kitchen", 600, new Vector3(0, 0, 1));
    public static Location bedroomTwo = new Location("bedroom2", 500, new Vector3(0, 0, 1));
    public static Location bedroomThree = new Location("bedroom3", 500, new Vector3(0, 0, 1));
    public static List<Location> allLocations = new List<Location>();

    public static NetworkGraph graph = new NetworkGraph();

    // Start is called before the first frame update
    void Start()
    {
        // Living Room Adjacents:
        livingRoom.addAdjacentLocation(hallway);

        // Hallway Adjacents:
        hallway.addAdjacentLocation(livingRoom);
        hallway.addAdjacentLocation(bedroomOne);
        hallway.addAdjacentLocation(kitchen);
        hallway.addAdjacentLocation(bedroomTwo);
        hallway.addAdjacentLocation(bedroomThree);

        // Bedroom One Adjacents:
        bedroomOne.addAdjacentLocation(hallway);
        bedroomOne.addAdjacentLocation(bedroomTwo);

        // Kitchen Adjacents:
        kitchen.addAdjacentLocation(hallway);
        kitchen.addAdjacentLocation(bedroomThree);

        // Bedroom Two Adjacents:
        bedroomTwo.addAdjacentLocation(hallway);
        bedroomTwo.addAdjacentLocation(bedroomOne);
        bedroomTwo.addAdjacentLocation(bedroomThree);

        // Bedroom Three Adjacents:
        bedroomThree.addAdjacentLocation(hallway);
        bedroomThree.addAdjacentLocation(kitchen);
        bedroomThree.addAdjacentLocation(bedroomTwo);

        // Add Locations to List:
        allLocations.Add(livingRoom);
        allLocations.Add(hallway);
        allLocations.Add(kitchen);
        allLocations.Add(bedroomOne);
        allLocations.Add(bedroomTwo);
        allLocations.Add(bedroomThree);

        //NetworkNode startNode = new NetworkNode("router", bedroomThree);
        //NetworkNode endNode = new NetworkNode("television", livingRoom);
        //NetworkNode thirdNode = new NetworkNode("xbox", bedroomOne);
        //graph.addNode(startNode);
        //graph.addNode(endNode);
        //graph.addNode(thirdNode);
        DrawLine(new Vector3(-1, 2, 5), new Vector3(-7, 2, 5), new Color(255, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 20.0f)
    {
        GameObject myLine = new GameObject();
        
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
