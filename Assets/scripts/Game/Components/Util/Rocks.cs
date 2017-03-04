using System.Linq;
using System.Collections.Generic;
using System;

public interface RocksLifeCycleOutput
{
    void OnAfterAdd(Rock rRock, List<Rock> allRocks);
    void OnAfterBoom(Rock rRock, List<Rock> allRocks);
}

public interface RocksGroundCollisionOutput
{
    void OnCollideToGround(Rock collisionRock);
}

public class Rocks : RockOutput, GameOverOutput
{
    public RocksLifeCycleOutput rockLifeCycleOutput;
    public RocksGroundCollisionOutput gGroundCollisionOutput;
	private List<Rock> rocks = new List<Rock>();
	public List<Rock> list { get { return rocks; } }

    public void Add(Rock rock)
    {
        rocks.Add(rock);
		rock.output = this;
        rockLifeCycleOutput.OnAfterAdd(rock, allRocks: rocks);
    }

    public Rock FindNearest(int pos)
    {
        return rocks.Where(r => r.sSpawnPoint.positionIndex == pos).FirstOrDefault();
    }

    void RockOutput.OnBoom(Rock target)
    {
        rocks.RemoveAll(r => r == target);
        rockLifeCycleOutput.OnAfterAdd(target, rocks);
    }

    void RockOutput.OnCollideToGround(Rock collisionRock)
    {
        gGroundCollisionOutput.OnCollideToGround(collisionRock);
    }

    void GameOverOutput.OnGameEnd(Player loser)
    {
        foreach (var rock in rocks)
        {
            rock.enabled = false;
        }
    }
}
