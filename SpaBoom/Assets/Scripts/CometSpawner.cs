using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public GameObject spawnAreaTopLeft;
    public GameObject spawnAreaTopRight;
    public GameObject spawnAreaBottomLeft;
    public GameObject spawnAreaBottomRight;
    public Comet prefab;


    private Vector3 _spawnPoint;
    private Vector3 _destinationPoint;
    private float sec = 0f;


    void Update()
    {
        sec += Time.deltaTime;
        if (sec > 1)
        {
            // random path from 1 to 4
            int pathNumber = Random.Range(1, 5);
            if (pathNumber == 1)        // top left to bottom left
            {
                _spawnPoint = GetRandomPoint(spawnAreaTopLeft);
                _destinationPoint = GetRandomPoint(spawnAreaBottomLeft);
            }
            else if (pathNumber == 2) // bottom left to top left
            {
                _spawnPoint = GetRandomPoint(spawnAreaBottomLeft);
                _destinationPoint = GetRandomPoint(spawnAreaTopLeft);
            }
            else if (pathNumber == 3) // top right to bottom right
            {
                _spawnPoint = GetRandomPoint(spawnAreaTopRight);
                _destinationPoint = GetRandomPoint(spawnAreaBottomRight);
            }
            else if (pathNumber == 4) // bottom right to top right
            {
                _spawnPoint = GetRandomPoint(spawnAreaBottomRight);
                _destinationPoint = GetRandomPoint(spawnAreaTopRight);
            }
            Comet comet = Instantiate(prefab, _spawnPoint, Quaternion.identity);
            comet.SetTarget(_destinationPoint);
            sec = 0f;
        }
    }

    // return random point in a box
    private Vector3 GetRandomPoint(GameObject spawnArea)
    {
        // get center point and box size
        BoxCollider2D boxCollider = spawnArea.GetComponent<BoxCollider2D>();
        Vector3 spawnPoint = spawnArea.transform.position;
        float deltaX, deltaY, halfWidth, halfHeight;

        // random point in the box
        halfWidth = boxCollider.size.x / 2;
        halfHeight = boxCollider.size.y / 2;
        deltaX = Random.Range(-halfWidth / 2, halfWidth / 2);
        deltaY = Random.Range(-halfHeight / 2, halfHeight / 2);
        spawnPoint.x += deltaX;
        spawnPoint.y += deltaY;

        return spawnPoint;
    }
}
