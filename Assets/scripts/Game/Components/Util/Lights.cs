using System;
using System.Collections.Generic;
using System.Linq;

public class Lights : RocksLifeCycleOutput {
	public List<Light> lights;
	public List<Light> list { get { return lights; } }

	public Lights(List<Light> lLights) {
		this.lights = lLights;
	}
	public bool IsFirst(Light target) {
		return lights.All(l => target.positionIndex <= l.positionIndex);
	}

	public bool IsLast(Light target) {
		return lights.All(l => target.positionIndex >= l.positionIndex);
	}

    internal Light Get(int index)
    {
		return lights.First(l => l.positionIndex == index);
    }

    void RocksLifeCycleOutput.OnAfterAdd(Rock rRock, List<Rock> allRocks)
    {
        RefreshLightImages(allRocks);
    }

    void RocksLifeCycleOutput.OnAfterBoom(Rock rRock, List<Rock> allRocks)
    {
        RefreshLightImages(allRocks);
    }

	void RefreshLightImages(List<Rock> allRocks)
	{
		var nearestRocks = allRocks
			.GroupBy(r => r.sSpawnPoint.positionIndex)
			.Select(group =>
				new {
					Position = group.Key,
					Rock = group.OrderBy(rock => rock.transform.position.y).First()
				}
			).ToDictionary(elem => elem.Position, elem => elem.Rock);

		foreach (var light in lights)
		{
			var rockExist = nearestRocks.ContainsKey(light.positionIndex);
			if (!rockExist) {
				light.cColor = null;
				continue;
			}

			light.cColor = nearestRocks[light.positionIndex].color;
		}
	}
}
