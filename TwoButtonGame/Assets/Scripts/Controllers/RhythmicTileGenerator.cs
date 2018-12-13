using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmicTileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    private bool gameActive = true;
    private float timeElapsed = 0, previousFrameTime = 0, songLength, lastReportedPlayheadPosition, lastTimeTileSpawned;
    private float tileFrequency, lastTileSpawnTime;
    private float[] timings;
    public AudioSource audioSource;
    public AudioClip[] songs;
    private Tile[,] tiles;
    private int previousXPosition = 0;
    public Transform tilesParent, tilesEndPositionMarker;

    private void Awake()
    {
        CodeControl.Message.AddListener<TilesReadyEvent>(OnTilesReady);
        CodeControl.Message.AddListener<GameStartedEvent>(OnGameStarted);
        timings = null;
    }

    private void OnTilesReady(TilesReadyEvent obj)
    {
        tiles = obj.tiles;
        timings = obj.timings;
        tileFrequency = obj.tileFrequency;
        previousXPosition = 0;
        StartTileSpawns();
    }

    private void OnGameStarted(GameStartedEvent obj)
    {
        StartTileSpawns();
    }

    private void StartTileSpawns()
    {
        gameActive = true;
        previousFrameTime = Time.time;
        lastTileSpawnTime = 0;
        audioSource.PlayOneShot(songs[0]);
        lastReportedPlayheadPosition = 0;
    }

    private void SpawnVisualTile()
    {
        for (int i = 0; i < tiles.GetLength(1); i++)
        {
            GameObject visualTile = Instantiate(tilePrefab, tilesParent);
            visualTile.transform.localPosition = new Vector3(i, 0, 0);
            Vector3 endPosition = new Vector3(tilesEndPositionMarker.position.x + i, tilesEndPositionMarker.position.y, tilesEndPositionMarker.position.z);
            visualTile.GetComponent<TileController>().Initialize(tiles[previousXPosition, i], 3, endPosition);
        }
        lastTileSpawnTime = Time.time;
        previousXPosition++;
    }

    private void Update()
    {
        if (gameActive)
        {
            timeElapsed += Time.time - previousFrameTime;
            previousFrameTime = Time.time;
            if (audioSource.time != lastReportedPlayheadPosition)
            {
                timeElapsed = (timeElapsed + audioSource.time / 2);
                lastReportedPlayheadPosition = audioSource.time;
            }
            if (timings != null)
            {
                if (Mathf.Approximately(timings[previousXPosition], timeElapsed))
                {
                    SpawnVisualTile();
                }
            }
            else
            {
                if (timeElapsed - lastTileSpawnTime >= tileFrequency)
                {
                    SpawnVisualTile();
                }
            }
        }
    }
}
