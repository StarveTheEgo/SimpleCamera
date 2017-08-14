// Decompiled with JetBrains decompiler
// Type: SimpleCamera.UnitTrack
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;
using System.Collections.Generic;

namespace SimpleCamera
{
  public class UnitTrack
  {
    public List<UnitState> positions = new List<UnitState>(1000);
    public Unit tracking;

    public UnitTrack(Unit u)
    {
      this.tracking = u;
    }

    public override string ToString()
    {
      return this.tracking.ToString();
    }

    public void update(int time)
    {
      UnitState unitState = this.positions.Count > 0 ? this.positions[this.positions.Count - 1] : (UnitState) null;
      if (unitState != null && unitState.time >= time)
        return;
      this.positions.Add(new UnitState(this.tracking.x, this.tracking.y, this.tracking.face, time, this));
    }

    public UnitState getClosestState(int time)
    {
      int num = int.MaxValue;
      UnitState unitState = (UnitState) null;
      foreach (UnitState position in this.positions)
      {
        if (Math.Abs(time - position.time) < num)
        {
          num = Math.Abs(time - position.time);
          unitState = position;
        }
      }
      return unitState;
    }

    public int getStart()
    {
      return this.positions[0].time;
    }

    public int getEnd()
    {
      return this.positions[this.positions.Count - 1].time;
    }

    public UnitState getClosestValidState(int time)
    {
      if (time >= this.getStart() && time <= this.getEnd())
        return this.getClosestState(time);
      return (UnitState) null;
    }
  }
}
