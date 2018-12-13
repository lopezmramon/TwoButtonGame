using UnityEngine;

public class Tile
{
    public Vector2Int coordinates;
    public TileType type;
    public int inhabitantIndex;
    public Biome biome;
    
    public Tile(Vector2Int coordinates, TileType type, int inhabitantIndex, Biome biome)
    {
        this.coordinates = coordinates;
        this.type = type;
        this.inhabitantIndex = inhabitantIndex;
        this.biome = biome;
    }
}
