public class TilesRequestEvent : CodeControl.Message
{
    public float[] timings;
    public float bpm, songLength, difficulty;
    public int lanes;

    public TilesRequestEvent(float[] timings, float bpm, float songLength, float difficulty, int lanes)
    {
        this.timings = timings;
        this.bpm = bpm;
        this.songLength = songLength;
        this.difficulty = difficulty;
        this.lanes = lanes;
    }
}
