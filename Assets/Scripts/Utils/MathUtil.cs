public static class MathUtil
{
	public static int Repeat(int t, int lenght)
	{
		return (lenght + t % lenght) % lenght;
	}
}

