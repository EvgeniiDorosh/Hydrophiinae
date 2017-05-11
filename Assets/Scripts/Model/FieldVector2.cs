using System;

[Serializable]
public struct FieldVector2
{
	public int x;
	public int y;

	public static FieldVector2 zero
	{
		get { return new FieldVector2 (0, 0);}
	}

	public static FieldVector2 left
	{
		get { return new FieldVector2 (0, -1);}
	}

	public static FieldVector2 right
	{
		get { return new FieldVector2 (0, 1);}
	}

	public static FieldVector2 up
	{
		get { return new FieldVector2 (-1, 0);}
	}

	public static FieldVector2 down
	{
		get { return new FieldVector2 (1, 0);}
	}

	public FieldVector2 (int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static bool operator ==(FieldVector2 v1, FieldVector2 v2) 
	{
		return (v1.x == v2.x) && (v1.y == v2.y);
	}

	public static bool operator !=(FieldVector2 v1, FieldVector2 v2) 
	{
		return (v1.x != v2.x) || (v1.y != v2.y);
	}

	public static FieldVector2 operator -(FieldVector2 v) 
	{
		return new FieldVector2(-v.x, -v.y);
	}

	public override bool Equals(object o) 
	{
		try 
		{
			return (bool) (this == (FieldVector2) o);
		}
		catch 
		{
			return false;
		}
	}

	public override int GetHashCode() 
	{
		int hash = 23;
		hash = hash * 31 + x.GetHashCode();
		hash = hash * 31 + y.GetHashCode();
		return hash;
	}

	public override string ToString ()
	{
		return string.Format ("[FieldVector2: {0}:{1}]", x, y);
	}
}
