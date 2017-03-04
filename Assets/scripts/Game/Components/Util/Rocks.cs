using System.Linq;
using System.Collections.Generic;
using System;

public class Rocks : RockOutput
{
    
	private List<Rock> rocks = new List<Rock>();
	public List<Rock> list { get { return rocks; } }

    internal void Add(Rock rock)
    {
        rocks.Add(rock);
		rock.output = this;
    }

    internal Rock FindNearest(int pos)
    {
        return rocks.Where(r => r.sSpawnPoint.positionIndex == pos).FirstOrDefault();
    }

    void RockOutput.OnBoom(Rock target)
    {
        rocks.RemoveAll(r => r == target);
    }
}
