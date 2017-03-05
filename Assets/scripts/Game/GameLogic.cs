using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameOverOutput {
	void OnGameEnd(Player loser);
}

public class PlayerOutputEventHandler : PlayerOutput
{
    private static Action notConnected = () => { Debug.LogError("Not connected"); };
    public Action moveLeft = notConnected;
    void PlayerOutput.MoveLeft()
    {
        moveLeft();
    }

    public Action moveRight = notConnected;
    void PlayerOutput.MoveRight()
    {
        moveRight();
    }

    public Action shoot = notConnected;
    void PlayerOutput.Shoot()
    {
        shoot();
    }
}

public class GameLogic : RockSpawnerOutput, RocksGroundCollisionOutput
{
	public GameOverOutput gGameOverOutput;
    public PlayerOutputEventHandler player1OutputEvent;
    public PlayerOutputEventHandler player2OutputEvent;
    public PlayerScoreInput player1ScoreInput;
    public PlayerScoreInput player2ScoreInput;

    public readonly Rocks rocks;
    private readonly Lights lights;
    private readonly Player player1;
    private readonly Player player2;
    private readonly RockSpawner rRockSpawner;
    private int _player1Score;
    private int player1Score
    {
        get
        {
            return _player1Score;
        }
        set
        {
            _player1Score = value;
            player1ScoreInput.scoreChanged(value);
        }
    }

    private int _player2Score;
    private int player2Score
    {
        get
        {
            return _player2Score;
        }
        set
        {
            _player2Score = value;
            player2ScoreInput.scoreChanged(value);
        }
    }

	private bool gameOver = false;

    public GameLogic(Lights lights, Player player1, Player player2, RockSpawner rRockSpawner)
    {
        this.rRockSpawner = rRockSpawner;
        this.rocks = new Rocks();
        this.player2 = player2;
        this.player1 = player1;
        this.lights = lights;
        player1OutputEvent = new PlayerOutputEventHandler();
        player2OutputEvent = new PlayerOutputEventHandler();

        player1OutputEvent.moveLeft = () => MoveLeft(player1, otherPlayer: player2, lights: lights);
        player2OutputEvent.moveLeft = () => MoveLeft(player2, otherPlayer: player1, lights: lights);
        player1OutputEvent.moveRight = () => MoveRight(player1, otherPlayer: player2, lights: lights);
        player2OutputEvent.moveRight = () => MoveRight(player2, otherPlayer: player1, lights: lights);
        player1OutputEvent.shoot = () => Shoot(player1, rocks, onShootSuccess: ScoreUpAction(player1.color));
        player2OutputEvent.shoot = () => Shoot(player2, rocks, onShootSuccess: ScoreUpAction(player2.color));
    }

    private static void MoveLeft(Player player, Player otherPlayer, Lights lights)
    {
        if (lights.IsFirst(player.currentLight))
        {
            return;
        }

        var nextIndex = player.currentLight.positionIndex - 1;
        // var otherPlayerIndex = otherPlayer.currentLight.positionIndex;

        // if (otherPlayerIndex == nextIndex)
        // {
        //     if (lights.IsFirst(otherPlayer.currentLight))
        //     {
        //         return;
        //     }
        //     else
        //     {
        //         nextIndex -= 1;
        //     }
        // }

        player.currentLight = lights.Get(nextIndex);
    }

    private static void MoveRight(Player player, Player otherPlayer, Lights lights)
    {
        if (lights.IsLast(player.currentLight))
        {
            return;
        }

        var nextIndex = player.currentLight.positionIndex + 1;
        // int otherPlayerIndex = otherPlayer.currentLight.positionIndex;
        // if (otherPlayerIndex == nextIndex)
        // {
        //     if (lights.IsLast(otherPlayer.currentLight))
        //     {
        //         return;
        //     }
        //     else
        //     {
        //         nextIndex += 1;
        //     }
        // }

        player.currentLight = lights.Get(nextIndex);
    }

    private static void Shoot(Player pPlayer, Rocks rRocks, Action onShootSuccess)
    {
        var pos = pPlayer.currentLight.positionIndex;
        Rock rock = rRocks.FindNearest(pos);

        if (rock == null)
        {
            return;
        }

        if (pPlayer.color != rock.color)
        {
            return;
        }

        rock.Boom();
        onShootSuccess();
        Debug.Log("Shoot");
    }

    private Action ScoreUpAction(PlayerColor color)
    {
        if (color == PlayerColor.Red)
        {
            return () => player1Score += 1;
        }
        else
        {
            return () => player2Score += 1;
        }
    }

    void RockSpawnerOutput.OnSpawn(Rock rock)
    {
        rocks.Add(rock);
    }

    void RocksGroundCollisionOutput.OnCollideToGround(Rock collisionRock)
    {
		if (gameOver) {
			return;
		}

		if (collisionRock.color == PlayerColor.Red) {
			gGameOverOutput.OnGameEnd(player1);
		} else {
			gGameOverOutput.OnGameEnd(player2);
		}

		gameOver = true;
    }
}
