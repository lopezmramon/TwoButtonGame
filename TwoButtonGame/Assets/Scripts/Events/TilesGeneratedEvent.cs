public class TilesGeneratedEvent : CodeControl.Message
{
    public Tile[,] tiles;

    public TilesGeneratedEvent(Tile[,] tiles)
    {
        this.tiles = tiles;
    }
}
