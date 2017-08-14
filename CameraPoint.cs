// Decompiled with JetBrains decompiler
// Type: SimpleCamera.CameraPoint
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;

namespace SimpleCamera
{
  internal class CameraPoint
  {
    private CameraMode m_Mode;
    private CameraOrigin m_Origin;
    private Point3D eye;
    private Point3D target;
    private float yaw;
    private float pitch;
    private float roll;
    private float distance;

    public CameraMode mode
    {
      get
      {
        return this.m_Mode;
      }
      set
      {
        this.m_Mode = value;
      }
    }

    public CameraOrigin origin
    {
      get
      {
        return this.m_Origin;
      }
      set
      {
        this.m_Origin = value;
      }
    }

    private CameraPoint(CameraPoint copy)
    {
      this.mode = copy.mode;
      this.origin = copy.origin;
      this.eye = copy.eye.copy();
      this.target = copy.target.copy();
      this.yaw = copy.yaw;
      this.pitch = copy.pitch;
      this.roll = copy.roll;
      this.distance = copy.distance;
    }

    public CameraPoint(CameraManager manager)
    {
      this.mode = CameraMode.Default;
      this.origin = CameraOrigin.Target;
      this.target = new Point3D(manager.targetX, manager.targetY, manager.zOffset / 32f);
      this.yaw = manager.yaw;
      this.pitch = manager.pitch;
      this.roll = manager.roll;
      this.distance = manager.distance / 32f;
      this.eye = new Point3D(manager.cameraX, manager.cameraY, this.target.z - this.distance * (float) Math.Sin((double) this.pitch));
    }

    public CameraPoint(string str)
    {
      string[] strArray = str.Split(' ');
      this.mode = (CameraMode) int.Parse(strArray[0]);
      this.origin = (CameraOrigin) int.Parse(strArray[1]);
      this.eye = Point3D.Parse(strArray[2]);
      this.target = Point3D.Parse(strArray[3]);
      this.yaw = float.Parse(strArray[4]);
      this.pitch = float.Parse(strArray[5]);
      this.roll = float.Parse(strArray[6]);
      this.distance = float.Parse(strArray[7]);
    }

    public CameraPoint copy()
    {
      return new CameraPoint(this);
    }

    public string StoreToString()
    {
      return "" + (object) this.mode + " " + (object) this.origin + " " + this.eye.StoreToString() + " " + this.target.StoreToString() + " " + (object) this.yaw + " " + (object) this.pitch + " " + (object) this.roll + " " + (object) this.distance;
    }

    public float getYaw()
    {
      return this.yaw;
    }

    public float getPitch()
    {
      return this.pitch;
    }

    public float getRoll()
    {
      return this.roll;
    }

    public float getDistance()
    {
      return this.distance;
    }

    public void setDistance(float distance)
    {
      this.distance = distance;
    }

    public void rotate(CameraAxis axis, float amount)
    {
      this.rotate(axis, amount, this.origin);
    }

    public void rotate(CameraAxis axis, float amount, CameraOrigin useOrigin)
    {
      if (axis == CameraAxis.Yaw)
        this.yaw += amount;
      else if (axis == CameraAxis.Pitch)
        this.pitch += amount;
      else if (axis == CameraAxis.Roll)
        this.roll += amount;
      if (useOrigin == CameraOrigin.Eye)
      {
        this.target.x = this.eye.x + this.distance * (float) Math.Cos((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.target.y = this.eye.y + this.distance * (float) Math.Sin((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.target.z = this.eye.z + this.distance * (float) Math.Sin((double) this.pitch);
      }
      else
      {
        if (useOrigin != CameraOrigin.Target)
          return;
        this.eye.x = this.target.x - this.distance * (float) Math.Cos((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.eye.y = this.target.y - this.distance * (float) Math.Sin((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.eye.z = this.target.z - this.distance * (float) Math.Sin((double) this.pitch);
      }
    }

    public void setRotation(CameraAxis axis, float amount)
    {
      this.setRotation(axis, amount, this.origin);
    }

    public void setRotation(CameraAxis axis, float amount, CameraOrigin useOrigin)
    {
      if (axis == CameraAxis.Yaw)
        this.yaw = amount;
      else if (axis == CameraAxis.Pitch)
        this.pitch = amount;
      else if (axis == CameraAxis.Roll)
        this.roll = amount;
      if (useOrigin == CameraOrigin.Eye)
      {
        this.target.x = this.eye.x + this.distance * (float) Math.Cos((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.target.y = this.eye.y + this.distance * (float) Math.Sin((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.target.z = this.eye.z + this.distance * (float) Math.Sin((double) this.pitch);
      }
      else
      {
        if (useOrigin != CameraOrigin.Target)
          return;
        this.eye.x = this.target.x - this.distance * (float) Math.Cos((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.eye.y = this.target.y - this.distance * (float) Math.Sin((double) this.yaw) * (float) Math.Cos((double) this.pitch);
        this.eye.z = this.target.z - this.distance * (float) Math.Sin((double) this.pitch);
      }
    }

    public void move(CameraDirection direction, float amount)
    {
      if (direction == CameraDirection.Up)
      {
        this.eye.z += amount;
        this.target.z += amount;
      }
      else if (direction == CameraDirection.Forward)
      {
        if (this.mode == CameraMode.Default)
        {
          this.target.x += (float) Math.Cos((double) this.yaw) * amount;
          this.target.y += (float) Math.Sin((double) this.yaw) * amount;
          this.eye.x += (float) Math.Cos((double) this.yaw) * amount;
          this.eye.y += (float) Math.Sin((double) this.yaw) * amount;
        }
        else
        {
          if (this.mode != CameraMode.FirstPerson)
            return;
          this.eye.x += (float) (Math.Cos((double) this.yaw) * Math.Cos((double) this.pitch)) * amount;
          this.eye.y += (float) (Math.Sin((double) this.yaw) * Math.Cos((double) this.pitch)) * amount;
          this.eye.z += (float) Math.Sin((double) this.pitch) * amount;
          this.target.x += (float) (Math.Cos((double) this.yaw) * Math.Cos((double) this.pitch)) * amount;
          this.target.y += (float) (Math.Sin((double) this.yaw) * Math.Cos((double) this.pitch)) * amount;
          this.target.z += (float) Math.Sin((double) this.pitch) * amount;
        }
      }
      else
      {
        if (direction != CameraDirection.Right)
          return;
        this.eye.x += (float) Math.Cos((double) this.yaw - Math.PI / 2.0) * amount;
        this.eye.y += (float) Math.Sin((double) this.yaw - Math.PI / 2.0) * amount;
        this.target.x += (float) Math.Cos((double) this.yaw - Math.PI / 2.0) * amount;
        this.target.y += (float) Math.Sin((double) this.yaw - Math.PI / 2.0) * amount;
      }
    }

    public void setPosition(float x, float y)
    {
      this.setPosition(x, y, this.origin);
    }

    public void setPosition(float x, float y, CameraOrigin useOrigin)
    {
      Point3D point3D = this.target - this.eye;
      if (useOrigin == CameraOrigin.Target)
      {
        this.target.x = x;
        this.target.y = y;
        this.eye = this.target - point3D;
      }
      else
      {
        if (useOrigin != CameraOrigin.Eye)
          return;
        this.eye.x = x;
        this.eye.y = y;
        this.target = this.eye + point3D;
      }
    }

    public void setPosition(float x, float y, CameraOrigin useOrigin, int smoothAmount)
    {
      if (useOrigin == CameraOrigin.Target)
      {
        this.setPosition((this.target.x * (float) smoothAmount + x) / (float) (smoothAmount + 1), (this.target.y * (float) smoothAmount + y) / (float) (smoothAmount + 1), useOrigin);
      }
      else
      {
        if (useOrigin != CameraOrigin.Eye)
          return;
        this.setPosition((this.eye.x * (float) smoothAmount + x) / (float) (smoothAmount + 1), (this.eye.y * (float) smoothAmount + y) / (float) (smoothAmount + 1), useOrigin);
      }
    }

    public void apply(CameraManager manager)
    {
      manager.targetX = this.target.x;
      manager.targetY = this.target.y;
      manager.zOffset = this.target.z * 32f;
      manager.yaw = this.yaw;
      manager.pitch = this.pitch;
      manager.roll = this.roll;
      manager.distance = this.distance * 32f;
    }
  }
}
