using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RockSpawnerOutput
{
    void OnSpawn(Rock rock);
}

public class RockSpawner
{
    public RockSpawnerOutput output;
    private readonly Rock rock1Prefab;
    private readonly Rock rock2Prefab;
    private readonly List<SpawnPoint> sSpawnPoints;

    public RockSpawner(Rock rock1Prefab, Rock rock2Prefab, List<SpawnPoint> sSpawnPoints)
    {
        this.sSpawnPoints = sSpawnPoints;
        this.rock2Prefab = rock2Prefab;
        this.rock1Prefab = rock1Prefab;
    }

    public IEnumerator SpawnCoroutine()
    {
        while (true)
        {
			foreach (var sSpawnPoint in sSpawnPoints)
			{
				var rock = Spawn(sSpawnPoint);
                output.OnSpawn(rock);
			}
			var spawnCool = Configurations.Instance.rockDownCool;
            yield return new WaitForSeconds(spawnCool);
        }
    }

	private Rock Spawn(SpawnPoint sSpawnPoint) {
		Rock randomPrefab;
		if (Random.Range(0f, 1f) < 0.5f) {
			randomPrefab = rock1Prefab;
		} else {
			randomPrefab = rock2Prefab;
		}

		Rock newRock = GameObject.Instantiate(randomPrefab);
		newRock.transform.SetParent(sSpawnPoint.transform, false);
        newRock.sSpawnPoint = sSpawnPoint;

		return newRock;
	}
}
