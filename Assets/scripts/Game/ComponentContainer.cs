using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ComponentContainer {
	[SerializeField]
	public List<SpawnPoint> sSpawnPoints;

	// for serialization
	private ComponentContainer()
	{
	}

	public static ComponentContainer Create()
	{
		var container = new ComponentContainer();
		SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType(typeof(SpawnPoint)) as SpawnPoint[];
		container.sSpawnPoints = spawnPoints.ToList();
		return container;
	}
}
