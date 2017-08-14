// Decompiled with JetBrains decompiler
// Type: SimpleCamera.UnitState
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

namespace SimpleCamera
{
  public class UnitState
  {
    public float x;
    public float y;
    public float facing;
    public int time;
    public UnitTrack unittrack;

    public UnitState(float x, float y, float facing, int time, UnitTrack unittrack)
    {
      this.x = x;
      this.y = y;
      this.facing = facing;
      this.time = time;
      this.unittrack = unittrack;
    }
  }
}
