﻿// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.ReadWrite7BitEncodingExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.IO;

#nullable disable
namespace GameCore.Serialization
{
  public static class ReadWrite7BitEncodingExtension
  {
    public static void Write7BitInt(this BinaryWriter self, int value)
    {
      uint num;
      for (num = (uint) value; num >= 128U; num >>= 7)
        self.Write((byte) (num | 128U));
      self.Write((byte) num);
    }

    public static int Read7BitInt(this BinaryReader self)
    {
      int num1 = 0;
      int num2 = 0;
      while (num2 != 35)
      {
        byte num3 = self.ReadByte();
        num1 |= ((int) num3 & (int) sbyte.MaxValue) << num2;
        num2 += 7;
        if (((int) num3 & 128) == 0)
          return num1;
      }
      throw new FormatException("Bad7BitInt32");
    }
  }
}
