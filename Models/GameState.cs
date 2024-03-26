namespace Models
{
    public class GameState
    {
        public Player Player { get; set; }
        public int XCoordinate { get; init; }
        public int YCoordinate { get; init; }
        public GameState(Player player, int xCoordiante, int yCoordiante)
        {
            Player = player;
            XCoordinate = xCoordiante;
            YCoordinate = yCoordiante;
        }
    }
}
