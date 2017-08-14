// Decompiled with JetBrains decompiler
// Type: SimpleCamera.Point3D
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System;

namespace SimpleCamera
{
  internal struct Point3D
  {
    public float x;
    public float y;
    public float z;

    public float length
    {
      get
      {
        return (float) Math.Sqrt((double) this.x * (double) this.x + (double) this.y * (double) this.y + (double) this.z * (double) this.z);
      }
      set
      {
        this.normalize();
        this.x *= value;
        this.y *= value;
        this.z *= value;
      }
    }

    public Point3D(float x, float y, float z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public static Point3D operator +(Point3D p1, Point3D p2)
    {
      return new Point3D(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
    }

    public static Point3D operator -(Point3D p1, Point3D p2)
    {
      return new Point3D(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
    }

    public Point3D copy()
    {
      return new Point3D(this.x, this.y, this.z);
    }

    public static Point3D Parse(string str)
    {
      Point3D point3D = new Point3D();
      string[] strArray = str.Split(':');
      point3D.x = float.Parse(strArray[0]);
      point3D.y = float.Parse(strArray[1]);
      point3D.z = float.Parse(strArray[2]);
      return point3D;
    }

    public string StoreToString()
    {
      return ((double) this.x).ToString() + ":" + (object) this.y + ":" + (object) this.z;
    }

    public void normalize()
    {
      float length = this.length;
      this.x /= length;
      this.y /= length;
      this.z /= length;
    }
  }
}
