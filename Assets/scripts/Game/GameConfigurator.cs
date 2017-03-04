using System.Linq;

public class GameConfigurator {
	public GameConfigurator()
	{
		
	}

    internal void Setup(Game game)
    {
		var pPrefabContainer = game.pPrefabContainer;

        var cContainer = ComponentContainer.Create();
		var roRockSpawner = new RockSpawner(pPrefabContainer.rock1, pPrefabContainer.rock2, cContainer.sSpawnPoints);
		var gameLogic = new GameLogic(cContainer.lights, cContainer.player1, cContainer.player2);

		game.cContainer = cContainer;
		game.roRockSpawner = roRockSpawner;

		cContainer.player1.input = new Player1InputHandler();
		cContainer.player2.input = new Player2InputHandler();

		cContainer.player1.output = gameLogic.player1OutputEvent;
		cContainer.player2.output = gameLogic.player2OutputEvent;

		cContainer.player1.currentLight = cContainer.lights.list.Where(l => l.positionIndex == 0).First();
		cContainer.player2.currentLight = cContainer.lights.list.Where(l => l.positionIndex == 1).First();
    }
}
