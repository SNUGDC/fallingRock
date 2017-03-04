using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : GameOverOutput
{
    private readonly List<GameOverOutput> gameOverListeners;
    public GameOverHandler(List<GameOverOutput> gameOverListeners)
    {
        this.gameOverListeners = gameOverListeners;
    }
    void GameOverOutput.OnGameEnd(Player loser)
    {
        foreach (var listener in gameOverListeners)
		{
			listener.OnGameEnd(loser);
		}
    }
}
