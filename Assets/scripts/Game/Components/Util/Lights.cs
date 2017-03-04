
using System;
using System.Collections.Generic;
using System.Linq;

public class Lights {
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

    internal Light Get(int nextIndex)
    {
		return lights.First(l => l.positionIndex == nextIndex);
    }
}
