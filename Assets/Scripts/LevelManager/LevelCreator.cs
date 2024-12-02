using System.Collections.Generic;
using UnityEngine;

public class ContinuousRoomSpawnerWithTutorial : MonoBehaviour
{
    public GameObject initialRoom;
    public GameObject[] roomPool;
    public int roomsToKeep = 5;
    public float roomHeight = 30f;
    public Transform player;

    private Queue<GameObject> spawnedRooms = new Queue<GameObject>();
    private float nextSpawnHeight;

    private void Start()
    {
        SpawnInitialRoom();
    }

    private void Update()
    {
        if (player.position.y + (roomsToKeep * roomHeight / 2) > nextSpawnHeight - roomHeight)
        {
            SpawnRoom();
        }

        if (spawnedRooms.Count > 0 && player.position.y - (roomsToKeep * roomHeight / 2) > spawnedRooms.Peek().transform.position.y + roomHeight)
        {
            DeleteOldestRoom();
        }
    }

    private void SpawnInitialRoom()
    {
        GameObject tutorialRoom = Instantiate(initialRoom, new Vector3(20, 13, 0), Quaternion.identity);
        spawnedRooms.Enqueue(tutorialRoom);
        nextSpawnHeight = roomHeight;
    }

    private void SpawnRoom()
    {
        if (spawnedRooms.Count >= roomsToKeep)
            return;

        int randomIndex = Random.Range(0, roomPool.Length);
        GameObject roomPrefab = roomPool[randomIndex];

        GameObject newRoom = Instantiate(roomPrefab, new Vector3(20, nextSpawnHeight + 13, 0), Quaternion.identity);

        spawnedRooms.Enqueue(newRoom);

        nextSpawnHeight += roomHeight;
    }

    private void DeleteOldestRoom()
    {
        GameObject oldestRoom = spawnedRooms.Dequeue();
        Destroy(oldestRoom);
    }
}
