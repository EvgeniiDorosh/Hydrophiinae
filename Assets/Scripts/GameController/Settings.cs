using System;

public static class Settings
{
	public const float maxStepDelay = 0.3f;
	public const float minStepDelay = 0.2f;

	public const int maxLevel = 20;

	public const int picksForOver = 10;

	public static float Duration(int level)
	{
		return maxStepDelay - level * (maxStepDelay - minStepDelay) / maxLevel;
	}

	public static int PicksForOver(int level)
	{
		return picksForOver + level / 4;
	}
}


