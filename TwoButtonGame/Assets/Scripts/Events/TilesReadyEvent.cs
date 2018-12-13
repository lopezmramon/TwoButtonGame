public class TilesReadyEvent : CodeControl.Message
{
    public Tile[,] tiles;
    public float[] timings;
    public float tileFrequency;

    public TilesReadyEvent(Tile[,] tiles, float[] timings, float tileFrequency)
    {
        this.tiles = tiles;
        this.timings = timings;
        this.tileFrequency = tileFrequency;
    }
}
