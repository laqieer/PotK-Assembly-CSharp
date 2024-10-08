﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZMA.Encoder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;
using System;
using System.IO;

#nullable disable
namespace SevenZip.Compression.LZMA
{
  public class Encoder : ICoder, ISetCoderProperties, IWriteCoderProperties
  {
    private const uint kIfinityPrice = 268435455;
    private const int kDefaultDictionaryLogSize = 22;
    private const uint kNumFastBytesDefault = 32;
    private const uint kNumLenSpecSymbols = 16;
    private const uint kNumOpts = 4096;
    private const int kPropSize = 5;
    private static byte[] g_FastPos = new byte[2048];
    private Base.State _state = new Base.State();
    private byte _previousByte;
    private uint[] _repDistances = new uint[new IntPtr(4)];
    private Encoder.Optimal[] _optimum = new Encoder.Optimal[new IntPtr(4096)];
    private IMatchFinder _matchFinder;
    private SevenZip.Compression.RangeCoder.Encoder _rangeEncoder = new SevenZip.Compression.RangeCoder.Encoder();
    private BitEncoder[] _isMatch = new BitEncoder[new IntPtr(192)];
    private BitEncoder[] _isRep = new BitEncoder[new IntPtr(12)];
    private BitEncoder[] _isRepG0 = new BitEncoder[new IntPtr(12)];
    private BitEncoder[] _isRepG1 = new BitEncoder[new IntPtr(12)];
    private BitEncoder[] _isRepG2 = new BitEncoder[new IntPtr(12)];
    private BitEncoder[] _isRep0Long = new BitEncoder[new IntPtr(192)];
    private BitTreeEncoder[] _posSlotEncoder = new BitTreeEncoder[new IntPtr(4)];
    private BitEncoder[] _posEncoders = new BitEncoder[new IntPtr(114)];
    private BitTreeEncoder _posAlignEncoder = new BitTreeEncoder(4);
    private Encoder.LenPriceTableEncoder _lenEncoder = new Encoder.LenPriceTableEncoder();
    private Encoder.LenPriceTableEncoder _repMatchLenEncoder = new Encoder.LenPriceTableEncoder();
    private Encoder.LiteralEncoder _literalEncoder = new Encoder.LiteralEncoder();
    private uint[] _matchDistances = new uint[new IntPtr(548)];
    private uint _numFastBytes = 32;
    private uint _longestMatchLength;
    private uint _numDistancePairs;
    private uint _additionalOffset;
    private uint _optimumEndIndex;
    private uint _optimumCurrentIndex;
    private bool _longestMatchWasFound;
    private uint[] _posSlotPrices = new uint[256];
    private uint[] _distancesPrices = new uint[new IntPtr(512)];
    private uint[] _alignPrices = new uint[new IntPtr(16)];
    private uint _alignPriceCount;
    private uint _distTableSize = 44;
    private int _posStateBits = 2;
    private uint _posStateMask = 3;
    private int _numLiteralPosStateBits;
    private int _numLiteralContextBits = 3;
    private uint _dictionarySize = 4194304;
    private uint _dictionarySizePrev = uint.MaxValue;
    private uint _numFastBytesPrev = uint.MaxValue;
    private long nowPos64;
    private bool _finished;
    private Stream _inStream;
    private Encoder.EMatchFinderType _matchFinderType = Encoder.EMatchFinderType.BT4;
    private bool _writeEndMark;
    private bool _needReleaseMFStream;
    private uint[] reps = new uint[new IntPtr(4)];
    private uint[] repLens = new uint[new IntPtr(4)];
    private byte[] properties = new byte[5];
    private uint[] tempPrices = new uint[new IntPtr(128)];
    private uint _matchPriceCount;
    private static string[] kMatchFinderIDs = new string[2]
    {
      "BT2",
      "BT4"
    };
    private uint _trainSize;

    public Encoder()
    {
      for (int index = 0; index < 4096; ++index)
        this._optimum[index] = new Encoder.Optimal();
      for (int index = 0; index < 4; ++index)
        this._posSlotEncoder[index] = new BitTreeEncoder(6);
    }

    static Encoder()
    {
      int index1 = 2;
      Encoder.g_FastPos[0] = (byte) 0;
      Encoder.g_FastPos[1] = (byte) 1;
      for (byte index2 = 2; index2 < (byte) 22; ++index2)
      {
        uint num1 = (uint) (1 << ((int) index2 >> 1) - 1);
        uint num2 = 0;
        while (num2 < num1)
        {
          Encoder.g_FastPos[index1] = index2;
          ++num2;
          ++index1;
        }
      }
    }

    private static uint GetPosSlot(uint pos)
    {
      if (pos < 2048U)
        return (uint) Encoder.g_FastPos[(IntPtr) pos];
      return pos < 2097152U ? (uint) Encoder.g_FastPos[(IntPtr) (pos >> 10)] + 20U : (uint) Encoder.g_FastPos[(IntPtr) (pos >> 20)] + 40U;
    }

    private static uint GetPosSlot2(uint pos)
    {
      if (pos < 131072U)
        return (uint) Encoder.g_FastPos[(IntPtr) (pos >> 6)] + 12U;
      return pos < 134217728U ? (uint) Encoder.g_FastPos[(IntPtr) (pos >> 16)] + 32U : (uint) Encoder.g_FastPos[(IntPtr) (pos >> 26)] + 52U;
    }

    private void BaseInit()
    {
      this._state.Init();
      this._previousByte = (byte) 0;
      for (uint index = 0; index < 4U; ++index)
        this._repDistances[(IntPtr) index] = 0U;
    }

    private void Create()
    {
      if (this._matchFinder == null)
      {
        BinTree binTree = new BinTree();
        int numHashBytes = 4;
        if (this._matchFinderType == Encoder.EMatchFinderType.BT2)
          numHashBytes = 2;
        binTree.SetType(numHashBytes);
        this._matchFinder = (IMatchFinder) binTree;
      }
      this._literalEncoder.Create(this._numLiteralPosStateBits, this._numLiteralContextBits);
      if ((int) this._dictionarySize == (int) this._dictionarySizePrev && (int) this._numFastBytesPrev == (int) this._numFastBytes)
        return;
      this._matchFinder.Create(this._dictionarySize, 4096U, this._numFastBytes, 274U);
      this._dictionarySizePrev = this._dictionarySize;
      this._numFastBytesPrev = this._numFastBytes;
    }

    private void SetWriteEndMarkerMode(bool writeEndMarker) => this._writeEndMark = writeEndMarker;

    private void Init()
    {
      this.BaseInit();
      this._rangeEncoder.Init();
      for (uint index1 = 0; index1 < 12U; ++index1)
      {
        for (uint index2 = 0; index2 <= this._posStateMask; ++index2)
        {
          uint index3 = (index1 << 4) + index2;
          this._isMatch[(IntPtr) index3].Init();
          this._isRep0Long[(IntPtr) index3].Init();
        }
        this._isRep[(IntPtr) index1].Init();
        this._isRepG0[(IntPtr) index1].Init();
        this._isRepG1[(IntPtr) index1].Init();
        this._isRepG2[(IntPtr) index1].Init();
      }
      this._literalEncoder.Init();
      for (uint index = 0; index < 4U; ++index)
        this._posSlotEncoder[(IntPtr) index].Init();
      for (uint index = 0; index < 114U; ++index)
        this._posEncoders[(IntPtr) index].Init();
      this._lenEncoder.Init((uint) (1 << this._posStateBits));
      this._repMatchLenEncoder.Init((uint) (1 << this._posStateBits));
      this._posAlignEncoder.Init();
      this._longestMatchWasFound = false;
      this._optimumEndIndex = 0U;
      this._optimumCurrentIndex = 0U;
      this._additionalOffset = 0U;
    }

    private void ReadMatchDistances(out uint lenRes, out uint numDistancePairs)
    {
      lenRes = 0U;
      numDistancePairs = this._matchFinder.GetMatches(this._matchDistances);
      if (numDistancePairs > 0U)
      {
        lenRes = this._matchDistances[(IntPtr) (numDistancePairs - 2U)];
        if ((int) lenRes == (int) this._numFastBytes)
          lenRes += this._matchFinder.GetMatchLen((int) lenRes - 1, this._matchDistances[(IntPtr) (numDistancePairs - 1U)], 273U - lenRes);
      }
      ++this._additionalOffset;
    }

    private void MovePos(uint num)
    {
      if (num <= 0U)
        return;
      this._matchFinder.Skip(num);
      this._additionalOffset += num;
    }

    private uint GetRepLen1Price(Base.State state, uint posState)
    {
      return this._isRepG0[(IntPtr) state.Index].GetPrice0() + this._isRep0Long[(IntPtr) ((state.Index << 4) + posState)].GetPrice0();
    }

    private uint GetPureRepPrice(uint repIndex, Base.State state, uint posState)
    {
      uint pureRepPrice;
      if (repIndex == 0U)
      {
        pureRepPrice = this._isRepG0[(IntPtr) state.Index].GetPrice0() + this._isRep0Long[(IntPtr) ((state.Index << 4) + posState)].GetPrice1();
      }
      else
      {
        uint price1 = this._isRepG0[(IntPtr) state.Index].GetPrice1();
        pureRepPrice = repIndex != 1U ? price1 + this._isRepG1[(IntPtr) state.Index].GetPrice1() + this._isRepG2[(IntPtr) state.Index].GetPrice(repIndex - 2U) : price1 + this._isRepG1[(IntPtr) state.Index].GetPrice0();
      }
      return pureRepPrice;
    }

    private uint GetRepPrice(uint repIndex, uint len, Base.State state, uint posState)
    {
      return this._repMatchLenEncoder.GetPrice(len - 2U, posState) + this.GetPureRepPrice(repIndex, state, posState);
    }

    private uint GetPosLenPrice(uint pos, uint len, uint posState)
    {
      uint lenToPosState = Base.GetLenToPosState(len);
      return (pos >= 128U ? this._posSlotPrices[(IntPtr) ((lenToPosState << 6) + Encoder.GetPosSlot2(pos))] + this._alignPrices[(IntPtr) (pos & 15U)] : this._distancesPrices[(IntPtr) (lenToPosState * 128U + pos)]) + this._lenEncoder.GetPrice(len - 2U, posState);
    }

    private uint Backward(out uint backRes, uint cur)
    {
      this._optimumEndIndex = cur;
      uint posPrev = this._optimum[(IntPtr) cur].PosPrev;
      uint backPrev = this._optimum[(IntPtr) cur].BackPrev;
      do
      {
        if (this._optimum[(IntPtr) cur].Prev1IsChar)
        {
          this._optimum[(IntPtr) posPrev].MakeAsChar();
          this._optimum[(IntPtr) posPrev].PosPrev = posPrev - 1U;
          if (this._optimum[(IntPtr) cur].Prev2)
          {
            this._optimum[(IntPtr) (posPrev - 1U)].Prev1IsChar = false;
            this._optimum[(IntPtr) (posPrev - 1U)].PosPrev = this._optimum[(IntPtr) cur].PosPrev2;
            this._optimum[(IntPtr) (posPrev - 1U)].BackPrev = this._optimum[(IntPtr) cur].BackPrev2;
          }
        }
        uint index = posPrev;
        uint num = backPrev;
        backPrev = this._optimum[(IntPtr) index].BackPrev;
        posPrev = this._optimum[(IntPtr) index].PosPrev;
        this._optimum[(IntPtr) index].BackPrev = num;
        this._optimum[(IntPtr) index].PosPrev = cur;
        cur = index;
      }
      while (cur > 0U);
      backRes = this._optimum[0].BackPrev;
      this._optimumCurrentIndex = this._optimum[0].PosPrev;
      return this._optimumCurrentIndex;
    }

    private uint GetOptimum(uint position, out uint backRes)
    {
      if ((int) this._optimumEndIndex != (int) this._optimumCurrentIndex)
      {
        uint optimum = this._optimum[(IntPtr) this._optimumCurrentIndex].PosPrev - this._optimumCurrentIndex;
        backRes = this._optimum[(IntPtr) this._optimumCurrentIndex].BackPrev;
        this._optimumCurrentIndex = this._optimum[(IntPtr) this._optimumCurrentIndex].PosPrev;
        return optimum;
      }
      this._optimumCurrentIndex = this._optimumEndIndex = 0U;
      uint lenRes1;
      uint numDistancePairs;
      if (!this._longestMatchWasFound)
      {
        this.ReadMatchDistances(out lenRes1, out numDistancePairs);
      }
      else
      {
        lenRes1 = this._longestMatchLength;
        numDistancePairs = this._numDistancePairs;
        this._longestMatchWasFound = false;
      }
      uint num1 = this._matchFinder.GetNumAvailableBytes() + 1U;
      if (num1 < 2U)
      {
        backRes = uint.MaxValue;
        return 1;
      }
      if (num1 > 273U)
        ;
      uint index1 = 0;
      for (uint index2 = 0; index2 < 4U; ++index2)
      {
        this.reps[(IntPtr) index2] = this._repDistances[(IntPtr) index2];
        this.repLens[(IntPtr) index2] = this._matchFinder.GetMatchLen(-1, this.reps[(IntPtr) index2], 273U);
        if (this.repLens[(IntPtr) index2] > this.repLens[(IntPtr) index1])
          index1 = index2;
      }
      if (this.repLens[(IntPtr) index1] >= this._numFastBytes)
      {
        backRes = index1;
        uint repLen = this.repLens[(IntPtr) index1];
        this.MovePos(repLen - 1U);
        return repLen;
      }
      if (lenRes1 >= this._numFastBytes)
      {
        backRes = this._matchDistances[(IntPtr) (numDistancePairs - 1U)] + 4U;
        this.MovePos(lenRes1 - 1U);
        return lenRes1;
      }
      byte indexByte1 = this._matchFinder.GetIndexByte(-1);
      byte indexByte2 = this._matchFinder.GetIndexByte(-(int) this._repDistances[0] - 1 - 1);
      if (lenRes1 < 2U && (int) indexByte1 != (int) indexByte2 && this.repLens[(IntPtr) index1] < 2U)
      {
        backRes = uint.MaxValue;
        return 1;
      }
      this._optimum[0].State = this._state;
      uint posState1 = position & this._posStateMask;
      this._optimum[1].Price = this._isMatch[(IntPtr) ((this._state.Index << 4) + posState1)].GetPrice0() + this._literalEncoder.GetSubCoder(position, this._previousByte).GetPrice(!this._state.IsCharState(), indexByte2, indexByte1);
      this._optimum[1].MakeAsChar();
      uint price1 = this._isMatch[(IntPtr) ((this._state.Index << 4) + posState1)].GetPrice1();
      uint num2 = price1 + this._isRep[(IntPtr) this._state.Index].GetPrice1();
      if ((int) indexByte2 == (int) indexByte1)
      {
        uint num3 = num2 + this.GetRepLen1Price(this._state, posState1);
        if (num3 < this._optimum[1].Price)
        {
          this._optimum[1].Price = num3;
          this._optimum[1].MakeAsShortRep();
        }
      }
      uint num4 = lenRes1 < this.repLens[(IntPtr) index1] ? this.repLens[(IntPtr) index1] : lenRes1;
      if (num4 < 2U)
      {
        backRes = this._optimum[1].BackPrev;
        return 1;
      }
      this._optimum[1].PosPrev = 0U;
      this._optimum[0].Backs0 = this.reps[0];
      this._optimum[0].Backs1 = this.reps[1];
      this._optimum[0].Backs2 = this.reps[2];
      this._optimum[0].Backs3 = this.reps[3];
      uint num5 = num4;
      do
      {
        this._optimum[(IntPtr) num5--].Price = 268435455U;
      }
      while (num5 >= 2U);
      for (uint repIndex = 0; repIndex < 4U; ++repIndex)
      {
        uint repLen = this.repLens[(IntPtr) repIndex];
        if (repLen >= 2U)
        {
          uint num6 = num2 + this.GetPureRepPrice(repIndex, this._state, posState1);
          do
          {
            uint num7 = num6 + this._repMatchLenEncoder.GetPrice(repLen - 2U, posState1);
            Encoder.Optimal optimal = this._optimum[(IntPtr) repLen];
            if (num7 < optimal.Price)
            {
              optimal.Price = num7;
              optimal.PosPrev = 0U;
              optimal.BackPrev = repIndex;
              optimal.Prev1IsChar = false;
            }
          }
          while (--repLen >= 2U);
        }
      }
      uint num8 = price1 + this._isRep[(IntPtr) this._state.Index].GetPrice0();
      uint len = this.repLens[0] < 2U ? 2U : this.repLens[0] + 1U;
      if (len <= lenRes1)
      {
        uint index3 = 0;
        while (len > this._matchDistances[(IntPtr) index3])
          index3 += 2U;
        while (true)
        {
          uint matchDistance = this._matchDistances[(IntPtr) (index3 + 1U)];
          uint num9 = num8 + this.GetPosLenPrice(matchDistance, len, posState1);
          Encoder.Optimal optimal = this._optimum[(IntPtr) len];
          if (num9 < optimal.Price)
          {
            optimal.Price = num9;
            optimal.PosPrev = 0U;
            optimal.BackPrev = matchDistance + 4U;
            optimal.Prev1IsChar = false;
          }
          if ((int) len == (int) this._matchDistances[(IntPtr) index3])
          {
            index3 += 2U;
            if ((int) index3 == (int) numDistancePairs)
              break;
          }
          ++len;
        }
      }
      uint cur = 0;
label_45:
      uint lenRes2;
      Base.State state1;
      uint posState2;
      uint num10;
      uint num11;
      uint num12;
      do
      {
        byte indexByte3;
        byte indexByte4;
        uint num13;
        bool flag;
        uint num14;
        uint limit1;
        do
        {
          ++cur;
          if ((int) cur == (int) num4)
            return this.Backward(out backRes, cur);
          this.ReadMatchDistances(out lenRes2, out numDistancePairs);
          if (lenRes2 >= this._numFastBytes)
          {
            this._numDistancePairs = numDistancePairs;
            this._longestMatchLength = lenRes2;
            this._longestMatchWasFound = true;
            return this.Backward(out backRes, cur);
          }
          ++position;
          uint index4 = this._optimum[(IntPtr) cur].PosPrev;
          if (this._optimum[(IntPtr) cur].Prev1IsChar)
          {
            --index4;
            if (this._optimum[(IntPtr) cur].Prev2)
            {
              state1 = this._optimum[(IntPtr) this._optimum[(IntPtr) cur].PosPrev2].State;
              if (this._optimum[(IntPtr) cur].BackPrev2 < 4U)
                state1.UpdateRep();
              else
                state1.UpdateMatch();
            }
            else
              state1 = this._optimum[(IntPtr) index4].State;
            state1.UpdateChar();
          }
          else
            state1 = this._optimum[(IntPtr) index4].State;
          if ((int) index4 == (int) cur - 1)
          {
            if (this._optimum[(IntPtr) cur].IsShortRep())
              state1.UpdateShortRep();
            else
              state1.UpdateChar();
          }
          else
          {
            uint num15;
            if (this._optimum[(IntPtr) cur].Prev1IsChar && this._optimum[(IntPtr) cur].Prev2)
            {
              index4 = this._optimum[(IntPtr) cur].PosPrev2;
              num15 = this._optimum[(IntPtr) cur].BackPrev2;
              state1.UpdateRep();
            }
            else
            {
              num15 = this._optimum[(IntPtr) cur].BackPrev;
              if (num15 < 4U)
                state1.UpdateRep();
              else
                state1.UpdateMatch();
            }
            Encoder.Optimal optimal = this._optimum[(IntPtr) index4];
            if (num15 < 4U)
            {
              switch (num15)
              {
                case 0:
                  this.reps[0] = optimal.Backs0;
                  this.reps[1] = optimal.Backs1;
                  this.reps[2] = optimal.Backs2;
                  this.reps[3] = optimal.Backs3;
                  break;
                case 1:
                  this.reps[0] = optimal.Backs1;
                  this.reps[1] = optimal.Backs0;
                  this.reps[2] = optimal.Backs2;
                  this.reps[3] = optimal.Backs3;
                  break;
                case 2:
                  this.reps[0] = optimal.Backs2;
                  this.reps[1] = optimal.Backs0;
                  this.reps[2] = optimal.Backs1;
                  this.reps[3] = optimal.Backs3;
                  break;
                default:
                  this.reps[0] = optimal.Backs3;
                  this.reps[1] = optimal.Backs0;
                  this.reps[2] = optimal.Backs1;
                  this.reps[3] = optimal.Backs2;
                  break;
              }
            }
            else
            {
              this.reps[0] = num15 - 4U;
              this.reps[1] = optimal.Backs0;
              this.reps[2] = optimal.Backs1;
              this.reps[3] = optimal.Backs2;
            }
          }
          this._optimum[(IntPtr) cur].State = state1;
          this._optimum[(IntPtr) cur].Backs0 = this.reps[0];
          this._optimum[(IntPtr) cur].Backs1 = this.reps[1];
          this._optimum[(IntPtr) cur].Backs2 = this.reps[2];
          this._optimum[(IntPtr) cur].Backs3 = this.reps[3];
          uint price = this._optimum[(IntPtr) cur].Price;
          indexByte3 = this._matchFinder.GetIndexByte(-1);
          indexByte4 = this._matchFinder.GetIndexByte(-(int) this.reps[0] - 1 - 1);
          posState2 = position & this._posStateMask;
          num13 = price + this._isMatch[(IntPtr) ((state1.Index << 4) + posState2)].GetPrice0() + this._literalEncoder.GetSubCoder(position, this._matchFinder.GetIndexByte(-2)).GetPrice(!state1.IsCharState(), indexByte4, indexByte3);
          Encoder.Optimal optimal1 = this._optimum[(IntPtr) (cur + 1U)];
          flag = false;
          if (num13 < optimal1.Price)
          {
            optimal1.Price = num13;
            optimal1.PosPrev = cur;
            optimal1.MakeAsChar();
            flag = true;
          }
          num10 = price + this._isMatch[(IntPtr) ((state1.Index << 4) + posState2)].GetPrice1();
          num14 = num10 + this._isRep[(IntPtr) state1.Index].GetPrice1();
          if ((int) indexByte4 == (int) indexByte3 && (optimal1.PosPrev >= cur || optimal1.BackPrev != 0U))
          {
            uint num16 = num14 + this.GetRepLen1Price(state1, posState2);
            if (num16 <= optimal1.Price)
            {
              optimal1.Price = num16;
              optimal1.PosPrev = cur;
              optimal1.MakeAsShortRep();
              flag = true;
            }
          }
          uint val2 = this._matchFinder.GetNumAvailableBytes() + 1U;
          num11 = Math.Min(4095U - cur, val2);
          limit1 = num11;
        }
        while (limit1 < 2U);
        if (limit1 > this._numFastBytes)
          limit1 = this._numFastBytes;
        if (!flag && (int) indexByte4 != (int) indexByte3)
        {
          uint matchLen = this._matchFinder.GetMatchLen(0, this.reps[0], Math.Min(num11 - 1U, this._numFastBytes));
          if (matchLen >= 2U)
          {
            Base.State state2 = state1;
            state2.UpdateChar();
            uint posState3 = position + 1U & this._posStateMask;
            uint num17 = num13 + this._isMatch[(IntPtr) ((state2.Index << 4) + posState3)].GetPrice1() + this._isRep[(IntPtr) state2.Index].GetPrice1();
            uint index5 = cur + 1U + matchLen;
            while (num4 < index5)
              this._optimum[(IntPtr) ++num4].Price = 268435455U;
            uint num18 = num17 + this.GetRepPrice(0U, matchLen, state2, posState3);
            Encoder.Optimal optimal = this._optimum[(IntPtr) index5];
            if (num18 < optimal.Price)
            {
              optimal.Price = num18;
              optimal.PosPrev = cur + 1U;
              optimal.BackPrev = 0U;
              optimal.Prev1IsChar = true;
              optimal.Prev2 = false;
            }
          }
        }
        num12 = 2U;
        for (uint repIndex = 0; repIndex < 4U; ++repIndex)
        {
          uint matchLen1 = this._matchFinder.GetMatchLen(-1, this.reps[(IntPtr) repIndex], limit1);
          if (matchLen1 >= 2U)
          {
            uint num19 = matchLen1;
            do
            {
              while (num4 < cur + matchLen1)
                this._optimum[(IntPtr) ++num4].Price = 268435455U;
              uint num20 = num14 + this.GetRepPrice(repIndex, matchLen1, state1, posState2);
              Encoder.Optimal optimal = this._optimum[(IntPtr) (cur + matchLen1)];
              if (num20 < optimal.Price)
              {
                optimal.Price = num20;
                optimal.PosPrev = cur;
                optimal.BackPrev = repIndex;
                optimal.Prev1IsChar = false;
              }
            }
            while (--matchLen1 >= 2U);
            uint num21 = num19;
            if (repIndex == 0U)
              num12 = num21 + 1U;
            if (num21 < num11)
            {
              uint limit2 = Math.Min(num11 - 1U - num21, this._numFastBytes);
              uint matchLen2 = this._matchFinder.GetMatchLen((int) num21, this.reps[(IntPtr) repIndex], limit2);
              if (matchLen2 >= 2U)
              {
                Base.State state3 = state1;
                state3.UpdateRep();
                uint num22 = position + num21 & this._posStateMask;
                uint num23 = num14 + this.GetRepPrice(repIndex, num21, state1, posState2) + this._isMatch[(IntPtr) ((state3.Index << 4) + num22)].GetPrice0() + this._literalEncoder.GetSubCoder(position + num21, this._matchFinder.GetIndexByte((int) num21 - 1 - 1)).GetPrice(true, this._matchFinder.GetIndexByte((int) num21 - 1 - ((int) this.reps[(IntPtr) repIndex] + 1)), this._matchFinder.GetIndexByte((int) num21 - 1));
                state3.UpdateChar();
                uint posState4 = (uint) ((int) position + (int) num21 + 1) & this._posStateMask;
                uint num24 = num23 + this._isMatch[(IntPtr) ((state3.Index << 4) + posState4)].GetPrice1() + this._isRep[(IntPtr) state3.Index].GetPrice1();
                uint num25 = num21 + 1U + matchLen2;
                while (num4 < cur + num25)
                  this._optimum[(IntPtr) ++num4].Price = 268435455U;
                uint num26 = num24 + this.GetRepPrice(0U, matchLen2, state3, posState4);
                Encoder.Optimal optimal = this._optimum[(IntPtr) (cur + num25)];
                if (num26 < optimal.Price)
                {
                  optimal.Price = num26;
                  optimal.PosPrev = (uint) ((int) cur + (int) num21 + 1);
                  optimal.BackPrev = 0U;
                  optimal.Prev1IsChar = true;
                  optimal.Prev2 = true;
                  optimal.PosPrev2 = cur;
                  optimal.BackPrev2 = repIndex;
                }
              }
            }
          }
        }
        if (lenRes2 > limit1)
        {
          lenRes2 = limit1;
          uint index6 = 0;
          while (lenRes2 > this._matchDistances[(IntPtr) index6])
            index6 += 2U;
          this._matchDistances[(IntPtr) index6] = lenRes2;
          numDistancePairs = index6 + 2U;
        }
      }
      while (lenRes2 < num12);
      uint num27 = num10 + this._isRep[(IntPtr) state1.Index].GetPrice0();
      while (num4 < cur + lenRes2)
        this._optimum[(IntPtr) ++num4].Price = 268435455U;
      uint index7 = 0;
      while (num12 > this._matchDistances[(IntPtr) index7])
        index7 += 2U;
      uint num28 = num12;
      while (true)
      {
        uint matchDistance = this._matchDistances[(IntPtr) (index7 + 1U)];
        uint num29 = num27 + this.GetPosLenPrice(matchDistance, num28, posState2);
        Encoder.Optimal optimal2 = this._optimum[(IntPtr) (cur + num28)];
        if (num29 < optimal2.Price)
        {
          optimal2.Price = num29;
          optimal2.PosPrev = cur;
          optimal2.BackPrev = matchDistance + 4U;
          optimal2.Prev1IsChar = false;
        }
        if ((int) num28 == (int) this._matchDistances[(IntPtr) index7])
        {
          if (num28 < num11)
          {
            uint limit = Math.Min(num11 - 1U - num28, this._numFastBytes);
            uint matchLen = this._matchFinder.GetMatchLen((int) num28, matchDistance, limit);
            if (matchLen >= 2U)
            {
              Base.State state4 = state1;
              state4.UpdateMatch();
              uint num30 = position + num28 & this._posStateMask;
              uint num31 = num29 + this._isMatch[(IntPtr) ((state4.Index << 4) + num30)].GetPrice0() + this._literalEncoder.GetSubCoder(position + num28, this._matchFinder.GetIndexByte((int) num28 - 1 - 1)).GetPrice(true, this._matchFinder.GetIndexByte((int) num28 - ((int) matchDistance + 1) - 1), this._matchFinder.GetIndexByte((int) num28 - 1));
              state4.UpdateChar();
              uint posState5 = (uint) ((int) position + (int) num28 + 1) & this._posStateMask;
              uint num32 = num31 + this._isMatch[(IntPtr) ((state4.Index << 4) + posState5)].GetPrice1() + this._isRep[(IntPtr) state4.Index].GetPrice1();
              uint num33 = num28 + 1U + matchLen;
              while (num4 < cur + num33)
                this._optimum[(IntPtr) ++num4].Price = 268435455U;
              uint num34 = num32 + this.GetRepPrice(0U, matchLen, state4, posState5);
              Encoder.Optimal optimal3 = this._optimum[(IntPtr) (cur + num33)];
              if (num34 < optimal3.Price)
              {
                optimal3.Price = num34;
                optimal3.PosPrev = (uint) ((int) cur + (int) num28 + 1);
                optimal3.BackPrev = 0U;
                optimal3.Prev1IsChar = true;
                optimal3.Prev2 = true;
                optimal3.PosPrev2 = cur;
                optimal3.BackPrev2 = matchDistance + 4U;
              }
            }
          }
          index7 += 2U;
          if ((int) index7 == (int) numDistancePairs)
            goto label_45;
        }
        ++num28;
      }
    }

    private bool ChangePair(uint smallDist, uint bigDist)
    {
      return smallDist < 33554432U && bigDist >= smallDist << 7;
    }

    private void WriteEndMarker(uint posState)
    {
      if (!this._writeEndMark)
        return;
      this._isMatch[(IntPtr) ((this._state.Index << 4) + posState)].Encode(this._rangeEncoder, 1U);
      this._isRep[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 0U);
      this._state.UpdateMatch();
      uint len = 2;
      this._lenEncoder.Encode(this._rangeEncoder, len - 2U, posState);
      uint symbol = 63;
      this._posSlotEncoder[(IntPtr) Base.GetLenToPosState(len)].Encode(this._rangeEncoder, symbol);
      int num1 = 30;
      uint num2 = (uint) ((1 << num1) - 1);
      this._rangeEncoder.EncodeDirectBits(num2 >> 4, num1 - 4);
      this._posAlignEncoder.ReverseEncode(this._rangeEncoder, num2 & 15U);
    }

    private void Flush(uint nowPos)
    {
      this.ReleaseMFStream();
      this.WriteEndMarker(nowPos & this._posStateMask);
      this._rangeEncoder.FlushData();
      this._rangeEncoder.FlushStream();
    }

    public void CodeOneBlock(out long inSize, out long outSize, out bool finished)
    {
      inSize = 0L;
      outSize = 0L;
      finished = true;
      if (this._inStream != null)
      {
        this._matchFinder.SetStream(this._inStream);
        this._matchFinder.Init();
        this._needReleaseMFStream = true;
        this._inStream = (Stream) null;
        if (this._trainSize > 0U)
          this._matchFinder.Skip(this._trainSize);
      }
      if (this._finished)
        return;
      this._finished = true;
      long nowPos64 = this.nowPos64;
      if (this.nowPos64 == 0L)
      {
        if (this._matchFinder.GetNumAvailableBytes() == 0U)
        {
          this.Flush((uint) this.nowPos64);
          return;
        }
        this.ReadMatchDistances(out uint _, out uint _);
        this._isMatch[(IntPtr) ((this._state.Index << 4) + ((uint) this.nowPos64 & this._posStateMask))].Encode(this._rangeEncoder, 0U);
        this._state.UpdateChar();
        byte indexByte = this._matchFinder.GetIndexByte(-(int) this._additionalOffset);
        this._literalEncoder.GetSubCoder((uint) this.nowPos64, this._previousByte).Encode(this._rangeEncoder, indexByte);
        this._previousByte = indexByte;
        --this._additionalOffset;
        ++this.nowPos64;
      }
      if (this._matchFinder.GetNumAvailableBytes() == 0U)
      {
        this.Flush((uint) this.nowPos64);
      }
      else
      {
        do
        {
          do
          {
            uint backRes;
            uint optimum = this.GetOptimum((uint) this.nowPos64, out backRes);
            uint posState = (uint) this.nowPos64 & this._posStateMask;
            uint index1 = (this._state.Index << 4) + posState;
            if (optimum == 1U && backRes == uint.MaxValue)
            {
              this._isMatch[(IntPtr) index1].Encode(this._rangeEncoder, 0U);
              byte indexByte1 = this._matchFinder.GetIndexByte(-(int) this._additionalOffset);
              Encoder.LiteralEncoder.Encoder2 subCoder = this._literalEncoder.GetSubCoder((uint) this.nowPos64, this._previousByte);
              if (!this._state.IsCharState())
              {
                byte indexByte2 = this._matchFinder.GetIndexByte(-(int) this._repDistances[0] - 1 - (int) this._additionalOffset);
                subCoder.EncodeMatched(this._rangeEncoder, indexByte2, indexByte1);
              }
              else
                subCoder.Encode(this._rangeEncoder, indexByte1);
              this._previousByte = indexByte1;
              this._state.UpdateChar();
            }
            else
            {
              this._isMatch[(IntPtr) index1].Encode(this._rangeEncoder, 1U);
              if (backRes < 4U)
              {
                this._isRep[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 1U);
                if (backRes == 0U)
                {
                  this._isRepG0[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 0U);
                  if (optimum == 1U)
                    this._isRep0Long[(IntPtr) index1].Encode(this._rangeEncoder, 0U);
                  else
                    this._isRep0Long[(IntPtr) index1].Encode(this._rangeEncoder, 1U);
                }
                else
                {
                  this._isRepG0[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 1U);
                  if (backRes == 1U)
                  {
                    this._isRepG1[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 0U);
                  }
                  else
                  {
                    this._isRepG1[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 1U);
                    this._isRepG2[(IntPtr) this._state.Index].Encode(this._rangeEncoder, backRes - 2U);
                  }
                }
                if (optimum == 1U)
                {
                  this._state.UpdateShortRep();
                }
                else
                {
                  this._repMatchLenEncoder.Encode(this._rangeEncoder, optimum - 2U, posState);
                  this._state.UpdateRep();
                }
                uint repDistance = this._repDistances[(IntPtr) backRes];
                if (backRes != 0U)
                {
                  for (uint index2 = backRes; index2 >= 1U; --index2)
                    this._repDistances[(IntPtr) index2] = this._repDistances[(IntPtr) (index2 - 1U)];
                  this._repDistances[0] = repDistance;
                }
              }
              else
              {
                this._isRep[(IntPtr) this._state.Index].Encode(this._rangeEncoder, 0U);
                this._state.UpdateMatch();
                this._lenEncoder.Encode(this._rangeEncoder, optimum - 2U, posState);
                backRes -= 4U;
                uint posSlot = Encoder.GetPosSlot(backRes);
                this._posSlotEncoder[(IntPtr) Base.GetLenToPosState(optimum)].Encode(this._rangeEncoder, posSlot);
                if (posSlot >= 4U)
                {
                  int NumBitLevels = (int) (posSlot >> 1) - 1;
                  uint num = (uint) ((2 | (int) posSlot & 1) << NumBitLevels);
                  uint symbol = backRes - num;
                  if (posSlot < 14U)
                  {
                    BitTreeEncoder.ReverseEncode(this._posEncoders, (uint) ((int) num - (int) posSlot - 1), this._rangeEncoder, NumBitLevels, symbol);
                  }
                  else
                  {
                    this._rangeEncoder.EncodeDirectBits(symbol >> 4, NumBitLevels - 4);
                    this._posAlignEncoder.ReverseEncode(this._rangeEncoder, symbol & 15U);
                    ++this._alignPriceCount;
                  }
                }
                uint num1 = backRes;
                for (uint index3 = 3; index3 >= 1U; --index3)
                  this._repDistances[(IntPtr) index3] = this._repDistances[(IntPtr) (index3 - 1U)];
                this._repDistances[0] = num1;
                ++this._matchPriceCount;
              }
              this._previousByte = this._matchFinder.GetIndexByte((int) optimum - 1 - (int) this._additionalOffset);
            }
            this._additionalOffset -= optimum;
            this.nowPos64 += (long) optimum;
          }
          while (this._additionalOffset != 0U);
          if (this._matchPriceCount >= 128U)
            this.FillDistancesPrices();
          if (this._alignPriceCount >= 16U)
            this.FillAlignPrices();
          inSize = this.nowPos64;
          outSize = this._rangeEncoder.GetProcessedSizeAdd();
          if (this._matchFinder.GetNumAvailableBytes() == 0U)
          {
            this.Flush((uint) this.nowPos64);
            return;
          }
        }
        while (this.nowPos64 - nowPos64 < 4096L);
        this._finished = false;
        finished = false;
      }
    }

    private void ReleaseMFStream()
    {
      if (this._matchFinder == null || !this._needReleaseMFStream)
        return;
      this._matchFinder.ReleaseStream();
      this._needReleaseMFStream = false;
    }

    private void SetOutStream(Stream outStream) => this._rangeEncoder.SetStream(outStream);

    private void ReleaseOutStream() => this._rangeEncoder.ReleaseStream();

    private void ReleaseStreams()
    {
      this.ReleaseMFStream();
      this.ReleaseOutStream();
    }

    private void SetStreams(Stream inStream, Stream outStream, long inSize, long outSize)
    {
      this._inStream = inStream;
      this._finished = false;
      this.Create();
      this.SetOutStream(outStream);
      this.Init();
      this.FillDistancesPrices();
      this.FillAlignPrices();
      this._lenEncoder.SetTableSize((uint) ((int) this._numFastBytes + 1 - 2));
      this._lenEncoder.UpdateTables((uint) (1 << this._posStateBits));
      this._repMatchLenEncoder.SetTableSize((uint) ((int) this._numFastBytes + 1 - 2));
      this._repMatchLenEncoder.UpdateTables((uint) (1 << this._posStateBits));
      this.nowPos64 = 0L;
    }

    public void Code(
      Stream inStream,
      Stream outStream,
      long inSize,
      long outSize,
      ICodeProgress progress)
    {
      this._needReleaseMFStream = false;
      try
      {
        this.SetStreams(inStream, outStream, inSize, outSize);
        while (true)
        {
          long inSize1;
          long outSize1;
          do
          {
            bool finished;
            this.CodeOneBlock(out inSize1, out outSize1, out finished);
            if (finished)
              goto label_5;
          }
          while (progress == null);
          progress.SetProgress(inSize1, outSize1);
        }
label_5:;
      }
      finally
      {
        this.ReleaseStreams();
      }
    }

    public void WriteCoderProperties(Stream outStream)
    {
      this.properties[0] = (byte) ((this._posStateBits * 5 + this._numLiteralPosStateBits) * 9 + this._numLiteralContextBits);
      for (int index = 0; index < 4; ++index)
        this.properties[1 + index] = (byte) (this._dictionarySize >> 8 * index & (uint) byte.MaxValue);
      outStream.Write(this.properties, 0, 5);
    }

    private void FillDistancesPrices()
    {
      for (uint pos = 4; pos < 128U; ++pos)
      {
        uint posSlot = Encoder.GetPosSlot(pos);
        int NumBitLevels = (int) (posSlot >> 1) - 1;
        uint num = (uint) ((2 | (int) posSlot & 1) << NumBitLevels);
        this.tempPrices[(IntPtr) pos] = BitTreeEncoder.ReverseGetPrice(this._posEncoders, (uint) ((int) num - (int) posSlot - 1), NumBitLevels, pos - num);
      }
      for (uint index1 = 0; index1 < 4U; ++index1)
      {
        BitTreeEncoder bitTreeEncoder = this._posSlotEncoder[(IntPtr) index1];
        uint num1 = index1 << 6;
        for (uint symbol = 0; symbol < this._distTableSize; ++symbol)
          this._posSlotPrices[(IntPtr) (num1 + symbol)] = bitTreeEncoder.GetPrice(symbol);
        for (uint index2 = 14; index2 < this._distTableSize; ++index2)
          this._posSlotPrices[(IntPtr) (num1 + index2)] += (uint) ((int) (index2 >> 1) - 1 - 4 << 6);
        uint num2 = index1 * 128U;
        uint pos;
        for (pos = 0U; pos < 4U; ++pos)
          this._distancesPrices[(IntPtr) (num2 + pos)] = this._posSlotPrices[(IntPtr) (num1 + pos)];
        for (; pos < 128U; ++pos)
          this._distancesPrices[(IntPtr) (num2 + pos)] = this._posSlotPrices[(IntPtr) (num1 + Encoder.GetPosSlot(pos))] + this.tempPrices[(IntPtr) pos];
      }
      this._matchPriceCount = 0U;
    }

    private void FillAlignPrices()
    {
      for (uint symbol = 0; symbol < 16U; ++symbol)
        this._alignPrices[(IntPtr) symbol] = this._posAlignEncoder.ReverseGetPrice(symbol);
      this._alignPriceCount = 0U;
    }

    private static int FindMatchFinder(string s)
    {
      for (int matchFinder = 0; matchFinder < Encoder.kMatchFinderIDs.Length; ++matchFinder)
      {
        if (s == Encoder.kMatchFinderIDs[matchFinder])
          return matchFinder;
      }
      return -1;
    }

    public void SetCoderProperties(CoderPropID[] propIDs, object[] properties)
    {
      for (uint index = 0; (long) index < (long) properties.Length; ++index)
      {
        object property = properties[(IntPtr) index];
        switch (propIDs[(IntPtr) index])
        {
          case CoderPropID.DictionarySize:
            if (!(property is int num1))
              throw new InvalidParamException();
            this._dictionarySize = num1 >= 1 && num1 <= 1073741824 ? (uint) num1 : throw new InvalidParamException();
            int num2 = 0;
            while (num2 < 30 && (long) num1 > (long) (uint) (1 << num2))
              ++num2;
            this._distTableSize = (uint) (num2 * 2);
            continue;
          case CoderPropID.PosStateBits:
            if (!(property is int num3))
              throw new InvalidParamException();
            this._posStateBits = num3 >= 0 && num3 <= 4 ? num3 : throw new InvalidParamException();
            this._posStateMask = (uint) ((1 << this._posStateBits) - 1);
            continue;
          case CoderPropID.LitContextBits:
            if (!(property is int num4))
              throw new InvalidParamException();
            this._numLiteralContextBits = num4 >= 0 && num4 <= 8 ? num4 : throw new InvalidParamException();
            continue;
          case CoderPropID.LitPosBits:
            if (!(property is int num5))
              throw new InvalidParamException();
            this._numLiteralPosStateBits = num5 >= 0 && num5 <= 4 ? num5 : throw new InvalidParamException();
            continue;
          case CoderPropID.NumFastBytes:
            if (!(property is int num6))
              throw new InvalidParamException();
            this._numFastBytes = num6 >= 5 && num6 <= 273 ? (uint) num6 : throw new InvalidParamException();
            continue;
          case CoderPropID.MatchFinder:
            if (!(property is string))
              throw new InvalidParamException();
            Encoder.EMatchFinderType matchFinderType = this._matchFinderType;
            int matchFinder = Encoder.FindMatchFinder(((string) property).ToUpper());
            this._matchFinderType = matchFinder >= 0 ? (Encoder.EMatchFinderType) matchFinder : throw new InvalidParamException();
            if (this._matchFinder != null && matchFinderType != this._matchFinderType)
            {
              this._dictionarySizePrev = uint.MaxValue;
              this._matchFinder = (IMatchFinder) null;
              continue;
            }
            continue;
          case CoderPropID.Algorithm:
            continue;
          case CoderPropID.EndMarker:
            if (!(property is bool writeEndMarker))
              throw new InvalidParamException();
            this.SetWriteEndMarkerMode(writeEndMarker);
            continue;
          default:
            throw new InvalidParamException();
        }
      }
    }

    public void SetTrainSize(uint trainSize) => this._trainSize = trainSize;

    private enum EMatchFinderType
    {
      BT2,
      BT4,
    }

    private class LiteralEncoder
    {
      private Encoder.LiteralEncoder.Encoder2[] m_Coders;
      private int m_NumPrevBits;
      private int m_NumPosBits;
      private uint m_PosMask;

      public void Create(int numPosBits, int numPrevBits)
      {
        if (this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits)
          return;
        this.m_NumPosBits = numPosBits;
        this.m_PosMask = (uint) ((1 << numPosBits) - 1);
        this.m_NumPrevBits = numPrevBits;
        uint length = (uint) (1 << this.m_NumPrevBits + this.m_NumPosBits);
        this.m_Coders = new Encoder.LiteralEncoder.Encoder2[(IntPtr) length];
        for (uint index = 0; index < length; ++index)
          this.m_Coders[(IntPtr) index].Create();
      }

      public void Init()
      {
        uint num = (uint) (1 << this.m_NumPrevBits + this.m_NumPosBits);
        for (uint index = 0; index < num; ++index)
          this.m_Coders[(IntPtr) index].Init();
      }

      public Encoder.LiteralEncoder.Encoder2 GetSubCoder(uint pos, byte prevByte)
      {
        return this.m_Coders[(IntPtr) (uint) ((((int) pos & (int) this.m_PosMask) << this.m_NumPrevBits) + ((int) prevByte >> 8 - this.m_NumPrevBits))];
      }

      public struct Encoder2
      {
        private BitEncoder[] m_Encoders;

        public void Create() => this.m_Encoders = new BitEncoder[768];

        public void Init()
        {
          for (int index = 0; index < 768; ++index)
            this.m_Encoders[index].Init();
        }

        public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte symbol)
        {
          uint index1 = 1;
          for (int index2 = 7; index2 >= 0; --index2)
          {
            uint symbol1 = (uint) ((int) symbol >> index2 & 1);
            this.m_Encoders[(IntPtr) index1].Encode(rangeEncoder, symbol1);
            index1 = index1 << 1 | symbol1;
          }
        }

        public void EncodeMatched(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte matchByte, byte symbol)
        {
          uint num1 = 1;
          bool flag = true;
          for (int index1 = 7; index1 >= 0; --index1)
          {
            uint symbol1 = (uint) ((int) symbol >> index1 & 1);
            uint index2 = num1;
            if (flag)
            {
              uint num2 = (uint) ((int) matchByte >> index1 & 1);
              index2 += (uint) (1 + (int) num2 << 8);
              flag = (int) num2 == (int) symbol1;
            }
            this.m_Encoders[(IntPtr) index2].Encode(rangeEncoder, symbol1);
            num1 = num1 << 1 | symbol1;
          }
        }

        public uint GetPrice(bool matchMode, byte matchByte, byte symbol)
        {
          uint price = 0;
          uint index = 1;
          int num1 = 7;
          if (matchMode)
          {
            for (; num1 >= 0; --num1)
            {
              uint num2 = (uint) ((int) matchByte >> num1 & 1);
              uint symbol1 = (uint) ((int) symbol >> num1 & 1);
              price += this.m_Encoders[(IntPtr) ((uint) (1 + (int) num2 << 8) + index)].GetPrice(symbol1);
              index = index << 1 | symbol1;
              if ((int) num2 != (int) symbol1)
              {
                --num1;
                break;
              }
            }
          }
          for (; num1 >= 0; --num1)
          {
            uint symbol2 = (uint) ((int) symbol >> num1 & 1);
            price += this.m_Encoders[(IntPtr) index].GetPrice(symbol2);
            index = index << 1 | symbol2;
          }
          return price;
        }
      }
    }

    private class LenEncoder
    {
      private BitEncoder _choice = new BitEncoder();
      private BitEncoder _choice2 = new BitEncoder();
      private BitTreeEncoder[] _lowCoder = new BitTreeEncoder[new IntPtr(16)];
      private BitTreeEncoder[] _midCoder = new BitTreeEncoder[new IntPtr(16)];
      private BitTreeEncoder _highCoder = new BitTreeEncoder(8);

      public LenEncoder()
      {
        for (uint index = 0; index < 16U; ++index)
        {
          this._lowCoder[(IntPtr) index] = new BitTreeEncoder(3);
          this._midCoder[(IntPtr) index] = new BitTreeEncoder(3);
        }
      }

      public void Init(uint numPosStates)
      {
        this._choice.Init();
        this._choice2.Init();
        for (uint index = 0; index < numPosStates; ++index)
        {
          this._lowCoder[(IntPtr) index].Init();
          this._midCoder[(IntPtr) index].Init();
        }
        this._highCoder.Init();
      }

      public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
      {
        if (symbol < 8U)
        {
          this._choice.Encode(rangeEncoder, 0U);
          this._lowCoder[(IntPtr) posState].Encode(rangeEncoder, symbol);
        }
        else
        {
          symbol -= 8U;
          this._choice.Encode(rangeEncoder, 1U);
          if (symbol < 8U)
          {
            this._choice2.Encode(rangeEncoder, 0U);
            this._midCoder[(IntPtr) posState].Encode(rangeEncoder, symbol);
          }
          else
          {
            this._choice2.Encode(rangeEncoder, 1U);
            this._highCoder.Encode(rangeEncoder, symbol - 8U);
          }
        }
      }

      public void SetPrices(uint posState, uint numSymbols, uint[] prices, uint st)
      {
        uint price0 = this._choice.GetPrice0();
        uint price1 = this._choice.GetPrice1();
        uint num1 = price1 + this._choice2.GetPrice0();
        uint num2 = price1 + this._choice2.GetPrice1();
        uint symbol;
        for (symbol = 0U; symbol < 8U; ++symbol)
        {
          if (symbol >= numSymbols)
            return;
          prices[(IntPtr) (st + symbol)] = price0 + this._lowCoder[(IntPtr) posState].GetPrice(symbol);
        }
        for (; symbol < 16U; ++symbol)
        {
          if (symbol >= numSymbols)
            return;
          prices[(IntPtr) (st + symbol)] = num1 + this._midCoder[(IntPtr) posState].GetPrice(symbol - 8U);
        }
        for (; symbol < numSymbols; ++symbol)
          prices[(IntPtr) (st + symbol)] = num2 + this._highCoder.GetPrice((uint) ((int) symbol - 8 - 8));
      }
    }

    private class LenPriceTableEncoder : Encoder.LenEncoder
    {
      private uint[] _prices = new uint[new IntPtr(4352)];
      private uint _tableSize;
      private uint[] _counters = new uint[new IntPtr(16)];

      public void SetTableSize(uint tableSize) => this._tableSize = tableSize;

      public uint GetPrice(uint symbol, uint posState)
      {
        return this._prices[(IntPtr) (posState * 272U + symbol)];
      }

      private void UpdateTable(uint posState)
      {
        this.SetPrices(posState, this._tableSize, this._prices, posState * 272U);
        this._counters[(IntPtr) posState] = this._tableSize;
      }

      public void UpdateTables(uint numPosStates)
      {
        for (uint posState = 0; posState < numPosStates; ++posState)
          this.UpdateTable(posState);
      }

      public new void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
      {
        base.Encode(rangeEncoder, symbol, posState);
        if (--this._counters[(IntPtr) posState] != 0U)
          return;
        this.UpdateTable(posState);
      }
    }

    private class Optimal
    {
      public Base.State State;
      public bool Prev1IsChar;
      public bool Prev2;
      public uint PosPrev2;
      public uint BackPrev2;
      public uint Price;
      public uint PosPrev;
      public uint BackPrev;
      public uint Backs0;
      public uint Backs1;
      public uint Backs2;
      public uint Backs3;

      public void MakeAsChar()
      {
        this.BackPrev = uint.MaxValue;
        this.Prev1IsChar = false;
      }

      public void MakeAsShortRep()
      {
        this.BackPrev = 0U;
        this.Prev1IsChar = false;
      }

      public bool IsShortRep() => this.BackPrev == 0U;
    }
  }
}
