// Decompiled with JetBrains decompiler
// Type: GameCore.XorShift
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class XorShift
  {
    public static XorShift random = new XorShift(DateTime.Now);
    public uint x = 123456789;
    public uint y = 362436069;
    public uint z = 521288629;
    public uint w = 88675123;

    public XorShift()
    {
    }

    public XorShift(DateTime dt)
    {
      this.x = (uint) dt.Ticks;
      this.y = (uint) (dt.Ticks >> 32);
      this.z = (uint) dt.Ticks;
      this.w = (uint) (dt.Ticks >> 32);
      for (int index = 0; index < 50; ++index)
      {
        int num = (int) this.Next();
      }
    }

    public XorShift(uint x, uint y, uint z, uint w)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = w;
    }

    public XorShift(string seed)
    {
      if (seed.Length < 4)
        return;
      int length = seed.Length / 4;
      this.x = (uint) seed.Substring(length * 0, length).GetHashCode();
      this.y = (uint) seed.Substring(length * 1, length).GetHashCode();
      this.z = (uint) seed.Substring(length * 2, length).GetHashCode();
      this.w = (uint) seed.Substring(length * 3, length).GetHashCode();
    }

    public XorShift(XorShift v)
    {
      this.x = v.x;
      this.y = v.y;
      this.z = v.z;
      this.w = v.w;
    }

    public static float value => XorShift.random.NextFloat();

    public static int Range(int min, int max) => XorShift.random.RangeInt(min, max);

    public uint Next()
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ (int) num ^ (int) (num >> 8));
    }

    public float NextFloat() => (float) this.NextDouble();

    public double NextDouble() => (double) this.Next() / (double) uint.MaxValue;

    public int RangeInt(int min, int max)
    {
      return (int) (this.NextDouble() * (double) ((long) max - (long) min) + (double) min);
    }

    public float RangeFloat(float min, float max)
    {
      return (float) (this.NextDouble() * ((double) max - (double) min)) + min;
    }
  }
}
