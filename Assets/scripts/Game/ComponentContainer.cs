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
	[SerializeField]
    private List<Light> _lights;
	public Lights lights;
	public PlayerScore player1Score;
	public PlayerScore player2Score;
	public EndingUI player1Ending;
	public EndingUI player2Ending;

    // 유니티 시리얼라이져를 위해서 빈 컨스트럭터가 필요.
	// 실제 코드에선 사용하면 안되므로 private으로 만듦.
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

		Light[] lights = GameObject.FindObjectsOfType(typeof(Light)) as Light[];
		container._lights = lights.ToList();
		container.lights = new Lights(container._lights);

		PlayerScore[] playerScores = GameObject.FindObjectsOfType(typeof(PlayerScore)) as PlayerScore[];
		container.player1Score = playerScores.Where(s => s.color == PlayerColor.Red).First();
		container.player2Score = playerScores.Where(s => s.color == PlayerColor.Blue).First();

		EndingUI[] endingUIs = GameObject.FindObjectsOfType(typeof(EndingUI)) as EndingUI[];
		container.player1Ending = endingUIs.Where(s => s.color == PlayerColor.Red).First();
		container.player2Ending = endingUIs.Where(s => s.color == PlayerColor.Blue).First();

		return container;
	}
}
