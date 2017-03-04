using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ComponentContainer {
	[SerializeField]
	public List<SpawnPoint> sSpawnPoints;

	public Player player1;
	public Player player2;

	// for serialization
	private ComponentContainer()
	{
	}

	public static ComponentContainer Create()
	{
		var container = new ComponentContainer();

		SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType(typeof(SpawnPoint)) as SpawnPoint[];
		container.sSpawnPoints = spawnPoints.ToList();

		Player[] pPlayers = GameObject.FindObjectsOfType(typeof(Player)) as Player[];
		container.player1 = pPlayers.Where(p => p.playerIndex == 0).First();
		container.player2 = pPlayers.Where(p => p.playerIndex == 1).First();
		
		return container;
	}
}
