﻿// Decompiled with JetBrains decompiler
// Type: SevenZip.LzmaAlone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SevenZip.CommandLineParser;
using SevenZip.Compression.LZMA;
using System;
using System.Collections;
using System.IO;

#nullable disable
namespace SevenZip
{
  internal class LzmaAlone
  {
    private static void PrintHelp()
    {
      Console.WriteLine("\nUsage:  LZMA <e|d> [<switches>...] inputFile outputFile\n  e: encode file\n  d: decode file\n  b: Benchmark\n<Switches>\n  -d{N}:  set dictionary - [0, 29], default: 23 (8MB)\n  -fb{N}: set number of fast bytes - [5, 273], default: 128\n  -lc{N}: set number of literal context bits - [0, 8], default: 3\n  -lp{N}: set number of literal pos bits - [0, 4], default: 0\n  -pb{N}: set number of pos bits - [0, 4], default: 2\n  -mf{MF_ID}: set Match Finder: [bt2, bt4], default: bt4\n  -eos:   write End Of Stream marker\n");
    }

    private static bool GetNumber(string s, out int v)
    {
      v = 0;
      for (int index = 0; index < s.Length; ++index)
      {
        char ch = s[index];
        if (ch < '0' || ch > '9')
          return false;
        v *= 10;
        v += (int) ch - 48;
      }
      return true;
    }

    private static int IncorrectCommand() => throw new Exception("Command line error");

    private static int Main2(string[] args)
    {
      Console.WriteLine("\nLZMA# 4.61  2008-11-23\n");
      if (args.Length == 0)
      {
        LzmaAlone.PrintHelp();
        return 0;
      }
      SwitchForm[] switchForms = new SwitchForm[13];
      int num1 = 0;
      SwitchForm[] switchFormArray1 = switchForms;
      int index1 = num1;
      int num2 = index1 + 1;
      SwitchForm switchForm1 = new SwitchForm("?", SwitchType.Simple, false);
      switchFormArray1[index1] = switchForm1;
      SwitchForm[] switchFormArray2 = switchForms;
      int index2 = num2;
      int num3 = index2 + 1;
      SwitchForm switchForm2 = new SwitchForm("H", SwitchType.Simple, false);
      switchFormArray2[index2] = switchForm2;
      SwitchForm[] switchFormArray3 = switchForms;
      int index3 = num3;
      int num4 = index3 + 1;
      SwitchForm switchForm3 = new SwitchForm("A", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray3[index3] = switchForm3;
      SwitchForm[] switchFormArray4 = switchForms;
      int index4 = num4;
      int num5 = index4 + 1;
      SwitchForm switchForm4 = new SwitchForm("D", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray4[index4] = switchForm4;
      SwitchForm[] switchFormArray5 = switchForms;
      int index5 = num5;
      int num6 = index5 + 1;
      SwitchForm switchForm5 = new SwitchForm("FB", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray5[index5] = switchForm5;
      SwitchForm[] switchFormArray6 = switchForms;
      int index6 = num6;
      int num7 = index6 + 1;
      SwitchForm switchForm6 = new SwitchForm("LC", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray6[index6] = switchForm6;
      SwitchForm[] switchFormArray7 = switchForms;
      int index7 = num7;
      int num8 = index7 + 1;
      SwitchForm switchForm7 = new SwitchForm("LP", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray7[index7] = switchForm7;
      SwitchForm[] switchFormArray8 = switchForms;
      int index8 = num8;
      int num9 = index8 + 1;
      SwitchForm switchForm8 = new SwitchForm("PB", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray8[index8] = switchForm8;
      SwitchForm[] switchFormArray9 = switchForms;
      int index9 = num9;
      int num10 = index9 + 1;
      SwitchForm switchForm9 = new SwitchForm("MF", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray9[index9] = switchForm9;
      SwitchForm[] switchFormArray10 = switchForms;
      int index10 = num10;
      int num11 = index10 + 1;
      SwitchForm switchForm10 = new SwitchForm("EOS", SwitchType.Simple, false);
      switchFormArray10[index10] = switchForm10;
      SwitchForm[] switchFormArray11 = switchForms;
      int index11 = num11;
      int num12 = index11 + 1;
      SwitchForm switchForm11 = new SwitchForm("SI", SwitchType.Simple, false);
      switchFormArray11[index11] = switchForm11;
      SwitchForm[] switchFormArray12 = switchForms;
      int index12 = num12;
      int num13 = index12 + 1;
      SwitchForm switchForm12 = new SwitchForm("SO", SwitchType.Simple, false);
      switchFormArray12[index12] = switchForm12;
      SwitchForm[] switchFormArray13 = switchForms;
      int index13 = num13;
      int numSwitches = index13 + 1;
      SwitchForm switchForm13 = new SwitchForm("T", SwitchType.UnLimitedPostString, false, 1);
      switchFormArray13[index13] = switchForm13;
      Parser parser = new Parser(numSwitches);
      try
      {
        parser.ParseStrings(switchForms, args);
      }
      catch
      {
        return LzmaAlone.IncorrectCommand();
      }
      if (parser[0].ThereIs || parser[1].ThereIs)
      {
        LzmaAlone.PrintHelp();
        return 0;
      }
      ArrayList nonSwitchStrings = parser.NonSwitchStrings;
      int num14 = 0;
      if (num14 >= nonSwitchStrings.Count)
        return LzmaAlone.IncorrectCommand();
      ArrayList arrayList1 = nonSwitchStrings;
      int index14 = num14;
      int num15 = index14 + 1;
      string lower1 = ((string) arrayList1[index14]).ToLower();
      bool flag1 = false;
      int dictionarySize = 2097152;
      if (parser[3].ThereIs)
      {
        int v;
        if (!LzmaAlone.GetNumber((string) parser[3].PostStrings[0], out v))
          LzmaAlone.IncorrectCommand();
        dictionarySize = 1 << v;
        flag1 = true;
      }
      string str = "bt4";
      if (parser[8].ThereIs)
        str = (string) parser[8].PostStrings[0];
      string lower2 = str.ToLower();
      int num16;
      if (lower1 == "b")
      {
        int v = 10;
        if (num15 < nonSwitchStrings.Count)
        {
          ArrayList arrayList2 = nonSwitchStrings;
          int index15 = num15;
          num16 = index15 + 1;
          if (!LzmaAlone.GetNumber((string) arrayList2[index15], out v))
            v = 10;
        }
        return LzmaBench.LzmaBenchmark(v, (uint) dictionarySize);
      }
      string path = string.Empty;
      if (parser[12].ThereIs)
        path = (string) parser[12].PostStrings[0];
      bool flag2 = false;
      switch (lower1)
      {
        case "e":
          flag2 = true;
          break;
        case "d":
          flag2 = false;
          break;
        default:
          LzmaAlone.IncorrectCommand();
          break;
      }
      bool thereIs1 = parser[10].ThereIs;
      bool thereIs2 = parser[11].ThereIs;
      if (thereIs1)
        throw new Exception("Not implemeted");
      if (num15 >= nonSwitchStrings.Count)
        LzmaAlone.IncorrectCommand();
      ArrayList arrayList3 = nonSwitchStrings;
      int index16 = num15;
      int num17 = index16 + 1;
      Stream inStream = (Stream) new FileStream((string) arrayList3[index16], FileMode.Open, FileAccess.Read);
      if (thereIs2)
        throw new Exception("Not implemeted");
      if (num17 >= nonSwitchStrings.Count)
        LzmaAlone.IncorrectCommand();
      ArrayList arrayList4 = nonSwitchStrings;
      int index17 = num17;
      num16 = index17 + 1;
      FileStream outStream = new FileStream((string) arrayList4[index17], FileMode.Create, FileAccess.Write);
      FileStream fileStream = (FileStream) null;
      if (path.Length != 0)
        fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      if (flag2)
      {
        if (!flag1)
          dictionarySize = 8388608;
        int v1 = 2;
        int v2 = 3;
        int v3 = 0;
        int v4 = 2;
        int v5 = 128;
        bool flag3 = parser[9].ThereIs || thereIs1;
        if (parser[2].ThereIs && !LzmaAlone.GetNumber((string) parser[2].PostStrings[0], out v4))
          LzmaAlone.IncorrectCommand();
        if (parser[4].ThereIs && !LzmaAlone.GetNumber((string) parser[4].PostStrings[0], out v5))
          LzmaAlone.IncorrectCommand();
        if (parser[5].ThereIs && !LzmaAlone.GetNumber((string) parser[5].PostStrings[0], out v2))
          LzmaAlone.IncorrectCommand();
        if (parser[6].ThereIs && !LzmaAlone.GetNumber((string) parser[6].PostStrings[0], out v3))
          LzmaAlone.IncorrectCommand();
        if (parser[7].ThereIs && !LzmaAlone.GetNumber((string) parser[7].PostStrings[0], out v1))
          LzmaAlone.IncorrectCommand();
        CoderPropID[] propIDs = new CoderPropID[8]
        {
          CoderPropID.DictionarySize,
          CoderPropID.PosStateBits,
          CoderPropID.LitContextBits,
          CoderPropID.LitPosBits,
          CoderPropID.Algorithm,
          CoderPropID.NumFastBytes,
          CoderPropID.MatchFinder,
          CoderPropID.EndMarker
        };
        object[] properties = new object[8]
        {
          (object) dictionarySize,
          (object) v1,
          (object) v2,
          (object) v3,
          (object) v4,
          (object) v5,
          (object) lower2,
          (object) flag3
        };
        Encoder encoder = new Encoder();
        encoder.SetCoderProperties(propIDs, properties);
        encoder.WriteCoderProperties((Stream) outStream);
        long num18 = flag3 || thereIs1 ? -1L : inStream.Length;
        for (int index18 = 0; index18 < 8; ++index18)
          outStream.WriteByte((byte) (num18 >> 8 * index18));
        if (fileStream != null)
        {
          CDoubleStream cdoubleStream = new CDoubleStream();
          cdoubleStream.s1 = (Stream) fileStream;
          cdoubleStream.s2 = inStream;
          cdoubleStream.fileIndex = 0;
          inStream = (Stream) cdoubleStream;
          long length = fileStream.Length;
          cdoubleStream.skipSize = 0L;
          if (length > (long) dictionarySize)
            cdoubleStream.skipSize = length - (long) dictionarySize;
          fileStream.Seek(cdoubleStream.skipSize, SeekOrigin.Begin);
          encoder.SetTrainSize((uint) (length - cdoubleStream.skipSize));
        }
        encoder.Code(inStream, (Stream) outStream, -1L, -1L, (ICodeProgress) null);
      }
      else
      {
        if (!(lower1 == "d"))
          throw new Exception("Command Error");
        byte[] numArray = new byte[5];
        if (inStream.Read(numArray, 0, 5) != 5)
          throw new Exception("input .lzma is too short");
        Decoder decoder = new Decoder();
        decoder.SetDecoderProperties(numArray);
        if (fileStream != null && !decoder.Train((Stream) fileStream))
          throw new Exception("can't train");
        long outSize = 0;
        for (int index19 = 0; index19 < 8; ++index19)
        {
          int num19 = inStream.ReadByte();
          if (num19 < 0)
            throw new Exception("Can't Read 1");
          outSize |= (long) (byte) num19 << 8 * index19;
        }
        long inSize = inStream.Length - inStream.Position;
        decoder.Code(inStream, (Stream) outStream, inSize, outSize, (ICodeProgress) null);
      }
      return 0;
    }

    [STAThread]
    private static int Main(string[] args)
    {
      try
      {
        return LzmaAlone.Main2(args);
      }
      catch (Exception ex)
      {
        Console.WriteLine("{0} Caught exception #1.", (object) ex);
        return 1;
      }
    }

    private enum Key
    {
      Help1,
      Help2,
      Mode,
      Dictionary,
      FastBytes,
      LitContext,
      LitPos,
      PosBits,
      MatchFinder,
      EOS,
      StdIn,
      StdOut,
      Train,
    }
  }
}
