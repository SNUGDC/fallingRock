using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	[SerializeField]
	private ComponentContainer cContainer;
	[SerializeField]
	private PrefabContainer pPrefabContainer;

	private RockSpawner roRockSpawner;
	// Use this for initialization
	void Start () {
		cContainer = ComponentContainer.Create();
		roRockSpawner = new RockSpawner(pPrefabContainer.rock1, pPrefabContainer.rock2, cContainer.sSpawnPoints);

		StartCoroutine(roRockSpawner.SpawnCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
