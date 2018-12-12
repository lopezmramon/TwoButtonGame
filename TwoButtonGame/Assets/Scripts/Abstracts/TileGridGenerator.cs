using System.Collections.Generic;
using UnityEngine;

public class TileGridGenerator
{
    public float[] timings;
    public float bpm, songLength, difficulty;
    public int lanes;

    public Tile[,] GenerateTilesWithTimings(float[] timings, int lanes, float difficulty)
    {
        int totalBeatAmount = timings.Length;
        Tile[,] tiles = new Tile[totalBeatAmount, lanes];
        for (int i = 0; i < totalBeatAmount; i++)
        {
            for (int j = 0; j < lanes; j++)
            {
                Vector2Int tileCoordinates = new Vector2Int(i, j);
                Tile[] previous5Tiles = new Tile[i + 1 > 5 ? 5 : i + 1];
                for (int p = 0; p < previous5Tiles.Length; p++)
                {
                    previous5Tiles[p] = tiles[i - p, j];
                }
                tiles[i, j] = new Tile(tileCoordinates, RandomType(previous5Tiles), 0);
            }
        }
        return tiles;
    }

    public Tile[,] GenerateTilesWithBPM(float bpm, float songLength, int lanes, float difficulty)
    {
        int totalBeatAmount = Mathf.RoundToInt(songLength / BeatFrequency(bpm, difficulty));
        Tile[,] tiles = new Tile[totalBeatAmount, lanes];
        for(int i = 0; i< totalBeatAmount; i++)
        {
            for (int j = 0; j < lanes; j++)
            {
                Vector2Int tileCoordinates = new Vector2Int(i, j);
                Tile[] previous5Tiles = new Tile[i+1>5?5:i+1];
                for(int p = 0; p < previous5Tiles.Length; p++)
                {
                    previous5Tiles[p] = tiles[i - p, j];
                }
                tiles[i, j] = new Tile(tileCoordinates, RandomType(previous5Tiles), 0);
            }
        }
        return tiles;
    }

    private float BeatFrequency(float bpm, float difficulty)
    {
        return bpm / difficulty;
    }

    private TileType RandomType(Tile[] previous5Tiles)
    {
        int randomTileType = Random.Range(0,6);
        return (TileType)randomTileType;
    }
}
