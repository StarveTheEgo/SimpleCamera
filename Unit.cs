// Decompiled with JetBrains decompiler
// Type: SimpleCamera.Unit
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using ReplaySeeker;

namespace SimpleCamera
{
  public class Unit
  {
    public int memoryPosition;
    private IProcessMemory pMemory;

    public float x
    {
      get
      {
        return this.pMemory.ReadFloat32(this.memoryPosition + 640);
      }
    }

    public float y
    {
      get
      {
        return this.pMemory.ReadFloat32(this.memoryPosition + 644);
      }
    }

    public float z
    {
      get
      {
        return this.pMemory.ReadFloat32(this.memoryPosition + 648);
      }
    }

    public float face
    {
      get
      {
        return this.pMemory.ReadFloat32(this.memoryPosition + 652);
      }
    }

    public Unit(int memoryPosition, IProcessMemory pMemory)
    {
      this.memoryPosition = memoryPosition;
      this.pMemory = pMemory;
    }

    public static bool operator ==(Unit a, Unit b)
    {
      if ((object) a == null || (object) b == null)
        return (object) a == (object) b;
      return a.memoryPosition == b.memoryPosition;
    }

    public static bool operator !=(Unit a, Unit b)
    {
      if ((object) a == null || (object) b == null)
        return (object) a != (object) b;
      return a.memoryPosition != b.memoryPosition;
    }

    public int getAddress()
    {
      return this.memoryPosition;
    }

    public string getType()
    {
      int num = this.pMemory.ReadInt32(this.memoryPosition + 48);
      return "" + (object) (char) (num >> 24 & (int) byte.MaxValue) + (object) (char) (num >> 16 & (int) byte.MaxValue) + (object) (char) (num >> 8 & (int) byte.MaxValue) + (object) (char) (num & (int) byte.MaxValue);
    }

    public bool isHero()
    {
      string str = this.getType().Substring(0, 1);
      return str.ToUpperInvariant().Equals(str);
    }

    public override bool Equals(object o)
    {
      if ((object) (o as Unit) == null)
        return false;
      return ((Unit) o).memoryPosition == this.memoryPosition;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return this.getType() + " - " + this.getAddress().ToString("X");
    }
  }
}
