using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I made this script so I don't have to make 100's of array's in all the scripts,
/// and can just use one script where every object gets stored.
/// Now I only have to call this script if I want to use one of the things in one of the array's.
/// </summary>
public class RoomTemplates : MonoBehaviour {
    public GameObject[] startRoom;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
}
