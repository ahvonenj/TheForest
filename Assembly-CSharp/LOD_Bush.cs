using PathologicalGames;
using System;

public class LOD_Bush : LOD_Base
{
	private static SpawnPool _spawnPool;

	public override LOD_Settings LodSettings
	{
		get
		{
			return LOD_Manager.Instance.Bush;
		}
	}

	public override SpawnPool Pool
	{
		get
		{
			if (!LOD_Bush._spawnPool)
			{
				LOD_Bush._spawnPool = PoolManager.Pools["Bushes"];
			}
			return LOD_Bush._spawnPool;
		}
	}

	public override bool DestroyInsteadOfDisable
	{
		get
		{
			return true;
		}
	}
}
