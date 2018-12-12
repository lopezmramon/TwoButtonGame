using System;
using UnityEngine;

public class RandomGenerationManager : MonoBehaviour
{
    private TileGridGenerator gridGenerator;
    private Tile[,] tiles;

    private void Awake()
    {
        CodeControl.Message.AddListener<TilesRequestEvent>(OnTilesRequested);
    }

    private void OnTilesRequested(TilesRequestEvent obj)
    {
        GenerateTiles(obj.timings, obj.bpm, obj.difficulty, obj.lanes, obj.songLength);
    }

    private void GenerateTiles(float[] timings, float bpm, float difficulty, int lanes, float songLength)
    {
        if(timings == null)
        {
            gridGenerator.GenerateTilesWithBPM(bpm, songLength, lanes, difficulty);
        }
        else
        {
            gridGenerator.GenerateTilesWithTimings(timings, lanes, difficulty);
        }
    }
}
