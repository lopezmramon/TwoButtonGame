using System;
using UnityEngine;

public class RandomGenerationManager : MonoBehaviour
{
    private TileGridGenerator gridGenerator;
    private Tile[,] tiles;

    private void Awake()
    {
        CodeControl.Message.AddListener<TilesRequestEvent>(OnTilesRequested);
        gridGenerator = new TileGridGenerator();
    }


    private void OnTilesRequested(TilesRequestEvent obj)
    {
        GenerateTiles(obj.timings, obj.bpm, obj.difficulty, obj.lanes, obj.songLength);
    }

    private void GenerateTiles(float[] timings, float bpm, float difficulty, int lanes, float songLength)
    {
        if (timings == null)
        {
            tiles = gridGenerator.GenerateTilesWithBPM(bpm, songLength, lanes, difficulty);
        }
        else
        {
            tiles = gridGenerator.GenerateTilesWithTimings(timings, lanes, difficulty);
        }
        DispatchTilesReadyEvent(timings, bpm / difficulty);
    }

    private void DispatchTilesReadyEvent(float[] timings, float frequency)
    {
        CodeControl.Message.Send(new TilesReadyEvent(tiles, timings, frequency));
    }


}
