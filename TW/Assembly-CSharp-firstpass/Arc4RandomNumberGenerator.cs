// Decompiled with JetBrains decompiler
// Type: Arc4RandomNumberGenerator
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using System.Security.Cryptography;

#nullable disable
public class Arc4RandomNumberGenerator
{
  private const int STIR_INCREMENT_CONST = 1600000;
  private static readonly Arc4RandomNumberGenerator instance = new Arc4RandomNumberGenerator();
  private Arc4RandomNumberGenerator.Arc4Stream stream = new Arc4RandomNumberGenerator.Arc4Stream();
  private int count;

  public int RandomNumber()
  {
    this.count -= 4;
    this.StirIfNeeded();
    return this.GetWord();
  }

  public void RandomValues(List<byte> result, int offset, int length)
  {
    this.StirIfNeeded();
    while (length-- != 0)
    {
      --this.count;
      this.StirIfNeeded();
      result[offset + length] = this.GetByte();
    }
  }

  private void AddRandomData(byte[] data)
  {
    --this.stream.i;
    for (int index = 0; index < 256; ++index)
    {
      ++this.stream.i;
      byte num = this.stream.s[(int) this.stream.i];
      this.stream.j += (byte) ((uint) num + (uint) data[index % data.Length]);
      this.stream.s[(int) this.stream.i] = this.stream.s[(int) this.stream.j];
      this.stream.s[(int) this.stream.j] = num;
    }
    this.stream.j = this.stream.i;
  }

  private void Stir()
  {
    byte[] numArray = new byte[128];
    Arc4RandomNumberGenerator.CryptographicallyRandomValuesFromOS(numArray);
    this.AddRandomData(numArray);
    for (int index = 0; index < 256; ++index)
    {
      int num = (int) this.GetByte();
    }
    this.count = 1600000;
  }

  private void StirIfNeeded()
  {
    if (this.count > 0)
      return;
    this.Stir();
  }

  private byte GetByte()
  {
    ++this.stream.i;
    byte num1 = this.stream.s[(int) this.stream.i];
    this.stream.j += num1;
    byte num2 = this.stream.s[(int) this.stream.j];
    this.stream.s[(int) this.stream.i] = num2;
    this.stream.s[(int) this.stream.j] = num1;
    return this.stream.s[(int) num1 + (int) num2 & (int) byte.MaxValue];
  }

  private int GetWord()
  {
    return (int) this.GetByte() << 24 | (int) this.GetByte() << 16 | (int) this.GetByte() << 8 | (int) this.GetByte();
  }

  public static int CryptographicallyRandomNumber()
  {
    return Arc4RandomNumberGenerator.instance.RandomNumber();
  }

  public static void CryptographicallyRandomValues(List<byte> buffer, int offset, int length)
  {
    Arc4RandomNumberGenerator.instance.RandomValues(buffer, offset, length);
  }

  private static void CryptographicallyRandomValuesFromOS(byte[] buffer)
  {
    new RNGCryptoServiceProvider().GetBytes(buffer);
  }

  private class Arc4Stream
  {
    public byte i;
    public byte j;
    public byte[] s = new byte[256];

    public Arc4Stream()
    {
      for (int index = 0; index <= (int) byte.MaxValue; ++index)
        this.s[index] = (byte) index;
      this.i = (byte) 0;
      this.j = (byte) 0;
    }
  }
}
