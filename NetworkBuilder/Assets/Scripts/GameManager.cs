using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Location livingRoom = new Location("livingroom", 500);
    public static Location bedroomOne = new Location("bedroom1", 600);
    public static Location hallway = new Location("hallway", 600);
    public static Location kitchen = new Location("kitchen", 600);
    public static Location bedroomTwo = new Location("bedroom2", 500);
    public static Location bedroomThree = new Location("bedroom3", 500);

    public static List<Location> allLocations = new List<Location>();

    public static Dictionary<NodeConnections, GameObject> connectionLines = new Dictionary<NodeConnections, GameObject>();
    public static Dictionary<NodeConnections, GameObject> activeLines = new Dictionary<NodeConnections, GameObject>();

    // Living Room Connections:
    public static NodeConnections livingRoomToHallway = new NodeConnections(new NetworkNode("base", livingRoom), new NetworkNode("base", hallway));
    public static NodeConnections livingRoomToBedroomOne = new NodeConnections(new NetworkNode("base", livingRoom), new NetworkNode("base", bedroomOne));
    public static NodeConnections livingRoomToKitchen = new NodeConnections(new NetworkNode("base", livingRoom), new NetworkNode("base", kitchen));
    public static NodeConnections livingRoomToBedroomTwo = new NodeConnections(new NetworkNode("base", livingRoom), new NetworkNode("base", bedroomTwo));
    public static NodeConnections livingRoomToBedroomThree = new NodeConnections(new NetworkNode("base", livingRoom), new NetworkNode("base", bedroomThree));

    // Hallway Connections:
    public static NodeConnections hallwayToBedroomOne = new NodeConnections(new NetworkNode("base", hallway), new NetworkNode("base", bedroomOne));
    public static NodeConnections hallwayToKitchen = new NodeConnections(new NetworkNode("base", hallway), new NetworkNode("base", kitchen));
    public static NodeConnections hallwayToBedroomTwo = new NodeConnections(new NetworkNode("base", hallway), new NetworkNode("base", bedroomTwo));
    public static NodeConnections hallwayToBedroomThree = new NodeConnections(new NetworkNode("base", hallway), new NetworkNode("base", bedroomThree));

    // Kitchen Connections:
    public static NodeConnections kitchenToBedroomOne = new NodeConnections(new NetworkNode("base", kitchen), new NetworkNode("base", bedroomOne));
    public static NodeConnections kitchenToBedroomTwo = new NodeConnections(new NetworkNode("base", kitchen), new NetworkNode("base", bedroomTwo));
    public static NodeConnections kitchenToBedroomThree = new NodeConnections(new NetworkNode("base", kitchen), new NetworkNode("base", bedroomThree));

    // Bedroom Connections:
    public static NodeConnections bedroomOneToBedroomTwo = new NodeConnections(new NetworkNode("base", bedroomOne), new NetworkNode("base", bedroomTwo));
    public static NodeConnections bedroomOneToBedroomThree = new NodeConnections(new NetworkNode("base", bedroomOne), new NetworkNode("base", bedroomThree));
    public static NodeConnections bedroomTwoToBedroomThree = new NodeConnections(new NetworkNode("base", bedroomTwo), new NetworkNode("base", bedroomThree));

    // Line Game Objects:
    public static GameObject lineLivingRoomToHallway;
    public static GameObject lineLivingRoomToBedroomOne;
    public static GameObject lineLivingRoomToKitchen;
    public static GameObject lineLivingRoomToBedroomTwo;
    public static GameObject lineLivingRoomToBedroomThree;
    public static GameObject lineHallwayToBedroomOne;
    public static GameObject lineHallwayToKitchen;
    public static GameObject lineHallwayToBedroomTwo;
    public static GameObject lineHallwayToBedroomThree;
    public static GameObject lineKitchenToBedroomOne;
    public static GameObject lineKitchenToBedroomTwo;
    public static GameObject lineBedroomOneToBedroomTwo;
    public static GameObject lineBedroomOneToBedroomThree;
    public static GameObject lineBedroomTwoToBedroomThree;



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

        // Bedroom Two Adjacents:
        bedroomTwo.addAdjacentLocation(hallway);
        bedroomTwo.addAdjacentLocation(bedroomOne);
        bedroomTwo.addAdjacentLocation(bedroomThree);

        // Bedroom Three Adjacents:
        bedroomThree.addAdjacentLocation(hallway);
        bedroomThree.addAdjacentLocation(bedroomTwo);

        // Add Locations to List:
        allLocations.Add(livingRoom);
        allLocations.Add(hallway);
        allLocations.Add(kitchen);
        allLocations.Add(bedroomOne);
        allLocations.Add(bedroomTwo);
        allLocations.Add(bedroomThree);

        // Get Game Objects:
        lineLivingRoomToHallway = GameObject.Find("livingRoomToHallway");
        lineLivingRoomToBedroomOne = GameObject.Find("livingRoomToBedroomOne");
        lineLivingRoomToKitchen = GameObject.Find("livingRoomToKitchen");
        lineLivingRoomToBedroomTwo = GameObject.Find("livingRoomToBedroomTwo");
        lineLivingRoomToBedroomThree = GameObject.Find("livingRoomToBedroomThree");
        lineHallwayToBedroomOne = GameObject.Find("hallwayToBedroomOne");
        lineHallwayToKitchen = GameObject.Find("hallwayToKitchen");
        lineHallwayToBedroomTwo = GameObject.Find("hallwayToBedroomTwo");
        lineHallwayToBedroomThree = GameObject.Find("hallwayToBedroomThree");
        lineKitchenToBedroomOne = GameObject.Find("kitchenToBedroomOne");
        lineKitchenToBedroomTwo = GameObject.Find("kitchenToBedroomTwo");
        lineBedroomOneToBedroomTwo = GameObject.Find("bedroomOneToBedroomTwo");
        lineBedroomOneToBedroomThree = GameObject.Find("bedroomOneToBedroomThree");
        lineBedroomTwoToBedroomThree = GameObject.Find("bedroomTwoToBedroomThree");

        // Set Objects Inactive:
        lineLivingRoomToHallway.SetActive(false);
        lineLivingRoomToBedroomOne.SetActive(false);
        lineLivingRoomToKitchen.SetActive(false);
        lineLivingRoomToBedroomTwo.SetActive(false);
        lineLivingRoomToBedroomThree.SetActive(false);
        lineHallwayToBedroomOne.SetActive(false);
        lineHallwayToKitchen.SetActive(false);
        lineHallwayToBedroomTwo.SetActive(false);
        lineHallwayToBedroomThree.SetActive(false);
        lineKitchenToBedroomOne.SetActive(false);
        lineKitchenToBedroomTwo.SetActive(false);
        lineBedroomOneToBedroomTwo.SetActive(false);
        lineBedroomOneToBedroomThree.SetActive(false);
        lineBedroomTwoToBedroomThree.SetActive(false);

        // Create Dictionary Map:
        connectionLines.Add(livingRoomToHallway, lineLivingRoomToHallway);
        connectionLines.Add(livingRoomToBedroomOne, lineLivingRoomToBedroomOne);
        connectionLines.Add(livingRoomToKitchen, lineLivingRoomToKitchen);
        connectionLines.Add(livingRoomToBedroomTwo, lineLivingRoomToBedroomTwo);
        connectionLines.Add(livingRoomToBedroomThree, lineLivingRoomToBedroomThree);
        connectionLines.Add(hallwayToBedroomOne, lineHallwayToBedroomOne);
        connectionLines.Add(hallwayToKitchen, lineHallwayToKitchen);
        connectionLines.Add(hallwayToBedroomTwo, lineHallwayToBedroomTwo);
        connectionLines.Add(hallwayToBedroomThree, lineHallwayToBedroomThree);
        connectionLines.Add(kitchenToBedroomOne, lineKitchenToBedroomOne);
        connectionLines.Add(kitchenToBedroomTwo, lineKitchenToBedroomTwo);
        connectionLines.Add(bedroomOneToBedroomTwo, lineBedroomOneToBedroomTwo);
        connectionLines.Add(bedroomOneToBedroomThree, lineBedroomOneToBedroomThree);
        connectionLines.Add(bedroomTwoToBedroomThree, lineBedroomTwoToBedroomThree);
    }

    public static void exposeLine(Dictionary<NodeConnections, GameObject> connectionLineVals, NodeConnections connectionVal)
    {
        foreach (NodeConnections connection in connectionLineVals.Keys.ToList())
        {
            if (connection.haveSameLocations(connectionVal) == true)
            {
                connectionLineVals[connection].SetActive(true);
                if (activeLines.ContainsKey(connection) == false)
                {
                    activeLines.Add(connection, connectionLineVals[connection]);
                }
                break;
            }
        }
    }
}


