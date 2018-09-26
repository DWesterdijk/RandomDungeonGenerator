using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I wanted a random start room, so I made this little script here.
/// It works easy, not alot of code required. and works fine.
/// </summary>
public class StartRoomSpawner : MonoBehaviour {
    private RoomTemplates _roomTemplates;

    private int _r;

    //The reason for an Awake is because it goes as first, even before "void Start"
    //The main reason for that is that Awake gets called at the start of the game.
    //And start only if the script(s) get called.
    private void Awake()
    {
        _roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        _r = Random.Range(0, _roomTemplates.startRoom.Length);
        Instantiate(_roomTemplates.startRoom[_r], transform.position, Quaternion.identity);
    }
}
