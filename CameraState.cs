// Decompiled with JetBrains decompiler
// Type: SimpleCamera.CameraState
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;

namespace SimpleCamera
{
  public class CameraState
  {
    public double tarx;
    public double tary;
    public double yaw;
    public double pitch;
    public double roll;
    public double distance;

    public double camx
    {
      get
      {
        return this.tarx + Math.Cos(this.pitch) * -Math.Cos(this.yaw) * this.distance / 32.0;
      }
      set
      {
        this.tarx += value - this.camx;
      }
    }

    public double camy
    {
      get
      {
        return this.tary + Math.Cos(this.pitch) * -Math.Sin(this.yaw) * this.distance / 32.0;
      }
      set
      {
        this.tary += value - this.camy;
      }
    }

    public CameraState(double tarx, double tary, double yaw, double pitch, double roll, double distance)
    {
      this.tarx = tarx;
      this.tary = tary;
      this.yaw = yaw;
      this.pitch = pitch;
      this.roll = roll;
      this.distance = distance;
    }

    public CameraState()
    {
    }

    public void apply(CameraManager cam)
    {
      cam.targetX = (float) this.tarx;
      cam.targetY = (float) this.tary;
      cam.yaw = (float) this.yaw;
      cam.pitch = (float) this.pitch;
      cam.roll = (float) this.roll;
      cam.distance = (float) this.distance;
    }

    public override string ToString()
    {
      return "CameraState{" + (object) this.tarx + "," + (object) this.tary + "}";
    }
  }
}
