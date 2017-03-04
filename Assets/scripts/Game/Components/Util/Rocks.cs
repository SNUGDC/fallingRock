using System.Linq;
using System.Collections.Generic;

public interface RocksOutput
{
    void OnAfterAdd(Rock rRock, List<Rock> allRocks);
    void OnAfterBoom(Rock rRock, List<Rock> allRocks);
}

public class Rocks : RockOutput
{
    public RocksOutput output;
	private List<Rock> rocks = new List<Rock>();
	public List<Rock> list { get { return rocks; } }

    internal void Add(Rock rock)
    {
        rocks.Add(rock);
		rock.output = this;
        output.OnAfterAdd(rock, allRocks: rocks);
    }

    internal Rock FindNearest(int pos)
    {
        return rocks.Where(r => r.sSpawnPoint.positionIndex == pos).FirstOrDefault();
    }

    void RockOutput.OnBoom(Rock target)
    {
        rocks.RemoveAll(r => r == target);
        output.OnAfterAdd(target, rocks);
    }
}
