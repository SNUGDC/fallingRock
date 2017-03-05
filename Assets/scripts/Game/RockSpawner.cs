using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RockSpawnerOutput
{
    void OnSpawn(Rock rock);
}

public class RockSpawner : GameOverOutput
{
    public RockSpawnerOutput output;
    private readonly Rock rock1Prefab;
    private readonly Rock rock2Prefab;
    private readonly List<SpawnPoint> sSpawnPoints;
    private bool stop = false;

    public RockSpawner(Rock rock1Prefab, Rock rock2Prefab, List<SpawnPoint> sSpawnPoints)
    {
        this.sSpawnPoints = sSpawnPoints;
        this.rock2Prefab = rock2Prefab;
        this.rock1Prefab = rock1Prefab;
    }

    public IEnumerator SpawnCoroutine()
    {
        while (!stop)
        {
            var randomPrefabs = RandomSequence();
            for (int i = 0; i < sSpawnPoints.Count; i++)
            {
                var rock = Spawn(sSpawnPoints[i], randomPrefabs[i]);
                output.OnSpawn(rock);
            }
			var spawnCool = Configurations.Instance.rockDownCool;

            Configurations.Instance.IncreaseDifficulty();

            yield return new WaitForSeconds(spawnCool);
        }
    }

	private Rock Spawn(SpawnPoint sSpawnPoint, Rock randomPrefab) {
		Rock newRock = GameObject.Instantiate(randomPrefab);
		newRock.transform.SetParent(sSpawnPoint.transform, false);
        newRock.sSpawnPoint = sSpawnPoint;

		return newRock;
	}

    private List<Rock> RandomSequence() {
        var values = new List<Rock>();
        values.Add(rock1Prefab);
        values.Add(rock1Prefab);
        values.Add(rock2Prefab);
        values.Add(rock2Prefab);
        if (UnityEngine.Random.Range(0f, 1f) < 0.5f) {
			values.Add(rock1Prefab);
		} else {
			values.Add(rock2Prefab);
		}
        if (UnityEngine.Random.Range(0f, 1f) < 0.5f) {
			values.Add(rock1Prefab);
		} else {
			values.Add(rock2Prefab);
		}
        return Shuffle(values);
    }

    private List<Rock> Shuffle(List<Rock> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            var otherI = UnityEngine.Random.Range(0, values.Count);
            Rock tmp = values[i];
            values[i] = values[otherI];
            values[otherI] = tmp;
        }

        return values;
    }

    void GameOverOutput.OnGameEnd(Player loser)
    {
        stop = true;
    }
}
