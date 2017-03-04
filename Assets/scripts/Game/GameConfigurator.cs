using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigurator {
	public GameConfigurator()
	{
		
	}

    internal void Setup(Game game)
    {
		var pPrefabContainer = game.pPrefabContainer;

        var cContainer = ComponentContainer.Create();
		var roRockSpawner = new RockSpawner(pPrefabContainer.rock1, pPrefabContainer.rock2, cContainer.sSpawnPoints);

		game.cContainer = cContainer;
		game.roRockSpawner = roRockSpawner;
    }
}
