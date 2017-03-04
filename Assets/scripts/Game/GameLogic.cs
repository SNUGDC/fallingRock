using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class GameLogic : RockSpawnerOutput
{
    public PlayerOutputEventHandler player1OutputEvent;
    public PlayerOutputEventHandler player2OutputEvent;
    private readonly Lights lights;
    private readonly Player player1;
    private readonly Player player2;
	private Rocks rocks;

    public GameLogic(Lights lights, Player player1, Player player2)
    {
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
		player1OutputEvent.shoot = () => Shoot(player1, rocks);
		player2OutputEvent.shoot = () => Shoot(player2, rocks);
    }

	private static void MoveLeft(Player player, Player otherPlayer, Lights lights) {
		if (lights.IsFirst(player.currentLight)) {
			return;
		}

		var nextIndex = player.currentLight.positionIndex - 1;
		if (otherPlayer.currentLight.positionIndex == nextIndex) {
			return;
		}

		player.currentLight = lights.Get(nextIndex);
	}

	private static void MoveRight(Player player, Player otherPlayer, Lights lights) {
		if (lights.IsLast(player.currentLight)) {
			return;
		}

		var nextIndex = player.currentLight.positionIndex + 1;
		if (otherPlayer.currentLight.positionIndex == nextIndex) {
			return;
		}

		player.currentLight = lights.Get(nextIndex);
	}

	private static void Shoot(Player pPlayer, Rocks rRocks) {
		var pos = pPlayer.currentLight.positionIndex;
		Rock rock = rRocks.FindNearest(pos);
		if (rock != null) {
			rock.Boom();
		}
		Debug.Log("Shoot");
	}

    void RockSpawnerOutput.OnSpawn(Rock rock)
    {
		rocks.Add(rock);
    }
}
