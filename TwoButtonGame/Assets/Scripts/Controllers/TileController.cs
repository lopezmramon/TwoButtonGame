using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Tile tile;
    public Transform obstaclePosition;
    public Material[] materials;
    public GameObject[] enemies, obstacles;
    private new Renderer renderer;
    private float timeToFinishMovement, lerpStartTime, currentLerpTime;
    private Vector3 startPosition, endPosition;
    private bool lerping;
    private BoxCollider boxCollider;

    public void Initialize(Tile tile, float timeToFinishMovement, Vector3 endPosition)
    {
        this.tile = tile;
        this.timeToFinishMovement = timeToFinishMovement;
        this.endPosition = endPosition;
        boxCollider = GetComponent<BoxCollider>();
        startPosition = transform.position;
        renderer = GetComponent<Renderer>();
        AssignMaterial();
        CreateObstacle();
        lerpStartTime = Time.time;
        lerping = true;
    }

    private void AssignMaterial()
    {
        renderer.material = Instantiate(materials[(int)tile.biome]);
    }

    private void CreateObstacle()
    {
        switch (tile.type)
        {
            case TileType.Enemy:
                if (tile.inhabitantIndex >= enemies.Length) return;
                GameObject enemy = Instantiate(enemies[tile.inhabitantIndex], obstaclePosition);
                enemy.transform.localPosition = Vector3.zero;
                break;
            case TileType.Pit:
                renderer.enabled = false;
                boxCollider.isTrigger = true;
                break;
            case TileType.Obstacle:
                if (tile.inhabitantIndex >= obstacles.Length) return;
                GameObject obstacle = Instantiate(obstacles[tile.inhabitantIndex], obstaclePosition);
                obstacle.transform.localPosition = Vector3.zero;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (lerping)
        {
            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted / timeToFinishMovement;         
            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            if (percentageComplete >= 1.0f)
            {
                FinalizeTileExistence();
            }
        }
    }

    private void FinalizeTileExistence()
    {
        Destroy(gameObject);
    }
}
