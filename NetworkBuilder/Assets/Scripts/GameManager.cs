using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Location livingRoom = new Location("livingroom", 500);
    Location bedroomOne = new Location("bedroom1", 600);
    Location hallway = new Location("hallway", 600);
    Location kitchen = new Location("kitchen", 600);
    Location bedroomTwo = new Location("bedroom2", 500);
    Location bedroomThree = new Location("bedroom3", 500);

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
        bedroomTwo.addAdjacentLocation(kitchen);
        bedroomTwo.addAdjacentLocation(bedroomTwo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
