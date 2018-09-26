using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In a random dungeon generator you obviously want something that makes the random dungeons happen.
/// This script does that. Through an easy understandable way.
/// 
/// The int "DoorDirection" is exactly as the name says, it determines what direction the opening is.
/// (The best way to check this is by aligning the X axis on the right side)
/// 
/// The bool "_isSpawned" so to make sure there won't be another room on the exact same location,
/// it works together with the "OnTriggerEnter", this only counts for if a trigger hits another trigger.
/// 
/// In the "OnTriggerEnter" is also another Destroy fucntion, this one checks if a trigger enters the ground.
/// If it is in the ground. it will destroy itself, to prevent double spawning.
/// </summary>
public class RoomSpawnPoint : MonoBehaviour {

    [Header("Door Direction")]
    [Tooltip("1 for Bottom; 2 for Left; 3 for Top; 4 for Right;")]
    public int doorDirection;
    /*
     * 1 -> bottom
     * 2 -> left
     * 3 -> top
     * 4 -> right
     */

    private int _r;
    private RoomTemplates _templates;
    private bool _isSpawned = false;

    private void Start()
    {
        _templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom", 0.25f);
    }


    private void SpawnRoom()
    {
        if (!_isSpawned)
        {
            if (doorDirection == 1)
            {
                //bottom entry
                _r = Random.Range(0, _templates.bottomRooms.Length);
                Instantiate(_templates.bottomRooms[_r], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 2)
            {
                //left entry
                _r = Random.Range(0, _templates.leftRooms.Length);
                Instantiate(_templates.leftRooms[_r], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 3)
            {
                //top entry
                _r = Random.Range(0, _templates.topRooms.Length);
                Instantiate(_templates.topRooms[_r], transform.position, Quaternion.identity);
            }
            else if (doorDirection == 4)
            {
                //right entry
                _r = Random.Range(0, _templates.rightRooms.Length);
                Instantiate(_templates.rightRooms[_r], transform.position, Quaternion.identity);
            }
            _isSpawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawnpoint") && other.GetComponent<RoomSpawnPoint>()._isSpawned == true)
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
