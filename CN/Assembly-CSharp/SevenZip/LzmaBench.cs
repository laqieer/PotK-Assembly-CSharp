// Decompiled with JetBrains decompiler
// Type: SevenZip.LzmaBench
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SevenZip.Compression.LZMA;
using System;
using System.IO;

#nullable disable
namespace SevenZip
{
  internal abstract class LzmaBench
  {
    private const uint kAdditionalSize = 6291456;
    private const uint kCompressedAdditionalSize = 1024;
    private const uint kMaxLzmaPropSize = 10;
    private const int kSubBits = 8;

    private static uint GetLogSize(uint size)
    {
      for (int index1 = 8; index1 < 32; ++index1)
      {
        for (uint index2 = 0; index2 < 256U; ++index2)
        {
          if (size <= (uint) ((1 << index1) + ((int) index2 << index1 - 8)))
            return (uint) (index1 << 8) + index2;
        }
      }
      return 8192;
    }

    private static ulong MyMultDiv64(ulong value, ulong elapsedTime)
    {
      ulong num1 = 10000000;
      ulong num2 = elapsedTime;
      while (num1 > 1000000UL)
      {
        num1 >>= 1;
        num2 >>= 1;
      }
      if (num2 == 0UL)
        num2 = 1UL;
      return value * num1 / num2;
    }

    private static ulong GetCompressRating(uint dictionarySize, ulong elapsedTime, ulong size)
    {
      ulong num1 = (ulong) (LzmaBench.GetLogSize(dictionarySize) - 4608U);
      ulong num2 = 1060UL + (num1 * num1 * 10UL >> 16);
      return LzmaBench.MyMultDiv64(size * num2, elapsedTime);
    }

    private static ulong GetDecompressRating(ulong elapsedTime, ulong outSize, ulong inSize)
    {
      return LzmaBench.MyMultDiv64((ulong) ((long) inSize * 220L + (long) outSize * 20L), elapsedTime);
    }

    private static ulong GetTotalRating(
      uint dictionarySize,
      ulong elapsedTimeEn,
      ulong sizeEn,
      ulong elapsedTimeDe,
      ulong inSizeDe,
      ulong outSizeDe)
    {
      return (LzmaBench.GetCompressRating(dictionarySize, elapsedTimeEn, sizeEn) + LzmaBench.GetDecompressRating(elapsedTimeDe, inSizeDe, outSizeDe)) / 2UL;
    }

    private static void PrintValue(ulong v)
    {
      string str = v.ToString();
      for (int index = 0; index + str.Length < 6; ++index)
        Console.Write(" ");
      Console.Write(str);
    }

    private static void PrintRating(ulong rating)
    {
      LzmaBench.PrintValue(rating / 1000000UL);
      Console.Write(" MIPS");
    }

    private static void PrintResults(
      uint dictionarySize,
      ulong elapsedTime,
      ulong size,
      bool decompressMode,
      ulong secondSize)
    {
      LzmaBench.PrintValue(LzmaBench.MyMultDiv64(size, elapsedTime) / 1024UL);
      Console.Write(" KB/s  ");
      LzmaBench.PrintRating(!decompressMode ? LzmaBench.GetCompressRating(dictionarySize, elapsedTime, size) : LzmaBench.GetDecompressRating(elapsedTime, size, secondSize));
    }

    public static int LzmaBenchmark(int numIterations, uint dictionarySize)
    {
      if (numIterations <= 0)
        return 0;
      if (dictionarySize < 262144U)
      {
        Console.WriteLine("\nError: dictionary size for benchmark must be >= 19 (512 KB)");
        return 1;
      }
      Console.Write("\n       Compressing                Decompressing\n\n");
      Encoder encoder = new Encoder();
      Decoder decoder = new Decoder();
      CoderPropID[] propIDs = new CoderPropID[1]
      {
        CoderPropID.DictionarySize
      };
      object[] properties = new object[1]
      {
        (object) (int) dictionarySize
      };
      uint num = dictionarySize + 6291456U;
      uint capacity = num / 2U + 1024U;
      encoder.SetCoderProperties(propIDs, properties);
      MemoryStream outStream1 = new MemoryStream();
      encoder.WriteCoderProperties((Stream) outStream1);
      byte[] array = outStream1.ToArray();
      LzmaBench.CBenchRandomGenerator cbenchRandomGenerator = new LzmaBench.CBenchRandomGenerator();
      cbenchRandomGenerator.Set(num);
      cbenchRandomGenerator.Generate();
      CRC crc = new CRC();
      crc.Init();
      crc.Update(cbenchRandomGenerator.Buffer, 0U, cbenchRandomGenerator.BufferSize);
      LzmaBench.CProgressInfo progress = new LzmaBench.CProgressInfo();
      progress.ApprovedStart = (long) dictionarySize;
      ulong size1 = 0;
      ulong elapsedTime1 = 0;
      ulong elapsedTime2 = 0;
      ulong secondSize = 0;
      MemoryStream inStream = new MemoryStream(cbenchRandomGenerator.Buffer, 0, (int) cbenchRandomGenerator.BufferSize);
      MemoryStream memoryStream = new MemoryStream((int) capacity);
      LzmaBench.CrcOutStream outStream2 = new LzmaBench.CrcOutStream();
      for (int index1 = 0; index1 < numIterations; ++index1)
      {
        progress.Init();
        inStream.Seek(0L, SeekOrigin.Begin);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        encoder.Code((Stream) inStream, (Stream) memoryStream, -1L, -1L, (ICodeProgress) progress);
        ulong ticks = (ulong) (DateTime.UtcNow - progress.Time).Ticks;
        long position = memoryStream.Position;
        if (progress.InSize == 0L)
          throw new Exception("Internal ERROR 1282");
        ulong elapsedTime3 = 0;
        for (int index2 = 0; index2 < 2; ++index2)
        {
          memoryStream.Seek(0L, SeekOrigin.Begin);
          outStream2.Init();
          decoder.SetDecoderProperties(array);
          ulong outSize = (ulong) num;
          DateTime utcNow = DateTime.UtcNow;
          decoder.Code((Stream) memoryStream, (Stream) outStream2, 0L, (long) outSize, (ICodeProgress) null);
          elapsedTime3 = (ulong) (DateTime.UtcNow - utcNow).Ticks;
          if ((int) outStream2.GetDigest() != (int) crc.GetDigest())
            throw new Exception("CRC Error");
        }
        ulong size2 = (ulong) num - (ulong) progress.InSize;
        LzmaBench.PrintResults(dictionarySize, ticks, size2, false, 0UL);
        Console.Write("     ");
        LzmaBench.PrintResults(dictionarySize, elapsedTime3, (ulong) num, true, (ulong) position);
        Console.WriteLine();
        size1 += size2;
        elapsedTime1 += ticks;
        elapsedTime2 += elapsedTime3;
        secondSize += (ulong) position;
      }
      Console.WriteLine("---------------------------------------------------");
      LzmaBench.PrintResults(dictionarySize, elapsedTime1, size1, false, 0UL);
      Console.Write("     ");
      LzmaBench.PrintResults(dictionarySize, elapsedTime2, (ulong) num * (ulong) numIterations, true, secondSize);
      Console.WriteLine("    Average");
      return 0;
    }

    private class CRandomGenerator
    {
      private uint A1;
      private uint A2;

      public CRandomGenerator() => this.Init();

      public void Init()
      {
        this.A1 = 362436069U;
        this.A2 = 521288629U;
      }

      public uint GetRnd()
      {
        return (this.A1 = (uint) (36969 * ((int) this.A1 & (int) ushort.MaxValue)) + (this.A1 >> 16)) << 16 ^ (this.A2 = (uint) (18000 * ((int) this.A2 & (int) ushort.MaxValue)) + (this.A2 >> 16));
      }
    }

    private class CBitRandomGenerator
    {
      private LzmaBench.CRandomGenerator RG = new LzmaBench.CRandomGenerator();
      private uint Value;
      private int NumBits;

      public void Init()
      {
        this.Value = 0U;
        this.NumBits = 0;
      }

      public uint GetRnd(int numBits)
      {
        if (this.NumBits > numBits)
        {
          uint rnd = this.Value & (uint) ((1 << numBits) - 1);
          this.Value >>= numBits;
          this.NumBits -= numBits;
          return rnd;
        }
        numBits -= this.NumBits;
        uint num = this.Value << numBits;
        this.Value = this.RG.GetRnd();
        uint rnd1 = num | this.Value & (uint) ((1 << numBits) - 1);
        this.Value >>= numBits;
        this.NumBits = 32 - numBits;
        return rnd1;
      }
    }

    private class CBenchRandomGenerator
    {
      private LzmaBench.CBitRandomGenerator RG = new LzmaBench.CBitRandomGenerator();
      private uint Pos;
      private uint Rep0;
      public uint BufferSize;
      public byte[] Buffer;

      public void Set(uint bufferSize)
      {
        this.Buffer = new byte[(IntPtr) bufferSize];
        this.Pos = 0U;
        this.BufferSize = bufferSize;
      }

      private uint GetRndBit() => this.RG.GetRnd(1);

      private uint GetLogRandBits(int numBits) => this.RG.GetRnd((int) this.RG.GetRnd(numBits));

      private uint GetOffset()
      {
        return this.GetRndBit() == 0U ? this.GetLogRandBits(4) : this.GetLogRandBits(4) << 10 | this.RG.GetRnd(10);
      }

      private uint GetLen1() => this.RG.GetRnd(1 + (int) this.RG.GetRnd(2));

      private uint GetLen2() => this.RG.GetRnd(2 + (int) this.RG.GetRnd(2));

      public void Generate()
      {
        this.RG.Init();
        this.Rep0 = 1U;
label_10:
        while (this.Pos < this.BufferSize)
        {
          if (this.GetRndBit() == 0U || this.Pos < 1U)
          {
            this.Buffer[(IntPtr) this.Pos++] = (byte) this.RG.GetRnd(8);
          }
          else
          {
            uint num1;
            if (this.RG.GetRnd(3) == 0U)
            {
              num1 = 1U + this.GetLen1();
            }
            else
            {
              do
              {
                this.Rep0 = this.GetOffset();
              }
              while (this.Rep0 >= this.Pos);
              ++this.Rep0;
              num1 = 2U + this.GetLen2();
            }
            uint num2 = 0;
            while (true)
            {
              if (num2 < num1 && this.Pos < this.BufferSize)
              {
                this.Buffer[(IntPtr) this.Pos] = this.Buffer[(IntPtr) (this.Pos - this.Rep0)];
                ++num2;
                ++this.Pos;
              }
              else
                goto label_10;
            }
          }
        }
      }
    }

    private class CrcOutStream : Stream
    {
      public CRC CRC = new CRC();

      public void Init() => this.CRC.Init();

      public uint GetDigest() => this.CRC.GetDigest();

      public override bool CanRead => false;

      public override bool CanSeek => false;

      public override bool CanWrite => true;

      public override long Length => 0;

      public override long Position
      {
        get => 0;
        set
        {
        }
      }

      public override void Flush()
      {
      }

      public override long Seek(long offset, SeekOrigin origin) => 0;

      public override void SetLength(long value)
      {
      }

      public override int Read(byte[] buffer, int offset, int count) => 0;

      public override void WriteByte(byte b) => this.CRC.UpdateByte(b);

      public override void Write(byte[] buffer, int offset, int count)
      {
        this.CRC.Update(buffer, (uint) offset, (uint) count);
      }
    }

    private class CProgressInfo : ICodeProgress
    {
      public long ApprovedStart;
      public long InSize;
      public DateTime Time;

      public void Init() => this.InSize = 0L;

      public void SetProgress(long inSize, long outSize)
      {
        if (inSize < this.ApprovedStart || this.InSize != 0L)
          return;
        this.Time = DateTime.UtcNow;
        this.InSize = inSize;
      }
    }
  }
}
