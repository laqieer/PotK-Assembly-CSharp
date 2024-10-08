﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.RangeCoder.BitTreeEncoder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace SevenZip.Compression.RangeCoder
{
  internal struct BitTreeEncoder
  {
    private BitEncoder[] Models;
    private int NumBitLevels;

    public BitTreeEncoder(int numBitLevels)
    {
      this.NumBitLevels = numBitLevels;
      this.Models = new BitEncoder[1 << numBitLevels];
    }

    public void Init()
    {
      for (uint index = 1; (long) index < (long) (1 << this.NumBitLevels); ++index)
        this.Models[(IntPtr) index].Init();
    }

    public void Encode(Encoder rangeEncoder, uint symbol)
    {
      uint index = 1;
      int numBitLevels = this.NumBitLevels;
      while (numBitLevels > 0)
      {
        --numBitLevels;
        uint symbol1 = symbol >> numBitLevels & 1U;
        this.Models[(IntPtr) index].Encode(rangeEncoder, symbol1);
        index = index << 1 | symbol1;
      }
    }

    public void ReverseEncode(Encoder rangeEncoder, uint symbol)
    {
      uint index1 = 1;
      for (uint index2 = 0; (long) index2 < (long) this.NumBitLevels; ++index2)
      {
        uint symbol1 = symbol & 1U;
        this.Models[(IntPtr) index1].Encode(rangeEncoder, symbol1);
        index1 = index1 << 1 | symbol1;
        symbol >>= 1;
      }
    }

    public uint GetPrice(uint symbol)
    {
      uint price = 0;
      uint index = 1;
      int numBitLevels = this.NumBitLevels;
      while (numBitLevels > 0)
      {
        --numBitLevels;
        uint symbol1 = symbol >> numBitLevels & 1U;
        price += this.Models[(IntPtr) index].GetPrice(symbol1);
        index = (index << 1) + symbol1;
      }
      return price;
    }

    public uint ReverseGetPrice(uint symbol)
    {
      uint price = 0;
      uint index = 1;
      for (int numBitLevels = this.NumBitLevels; numBitLevels > 0; --numBitLevels)
      {
        uint symbol1 = symbol & 1U;
        symbol >>= 1;
        price += this.Models[(IntPtr) index].GetPrice(symbol1);
        index = index << 1 | symbol1;
      }
      return price;
    }

    public static uint ReverseGetPrice(
      BitEncoder[] Models,
      uint startIndex,
      int NumBitLevels,
      uint symbol)
    {
      uint price = 0;
      uint num = 1;
      for (int index = NumBitLevels; index > 0; --index)
      {
        uint symbol1 = symbol & 1U;
        symbol >>= 1;
        price += Models[(IntPtr) (startIndex + num)].GetPrice(symbol1);
        num = num << 1 | symbol1;
      }
      return price;
    }

    public static void ReverseEncode(
      BitEncoder[] Models,
      uint startIndex,
      Encoder rangeEncoder,
      int NumBitLevels,
      uint symbol)
    {
      uint num = 1;
      for (int index = 0; index < NumBitLevels; ++index)
      {
        uint symbol1 = symbol & 1U;
        Models[(IntPtr) (startIndex + num)].Encode(rangeEncoder, symbol1);
        num = num << 1 | symbol1;
        symbol >>= 1;
      }
    }
  }
}
