// Decompiled with JetBrains decompiler
// Type: MasterDataReader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
public class MasterDataReader
{
  private byte[] buf;
  private int n;
  private int length;
  private char[] charBuf;

  public MasterDataReader(byte[] buf)
  {
    this.buf = buf;
    this.n = 0;
    this.ReadInt();
    this.length = this.ReadInt();
    this.charBuf = new char[this.ReadInt()];
  }

  public int Length => this.length;

  public bool ReadBool()
  {
    if (this.buf.Length < this.n + 1)
      throw new IndexOutOfRangeException("ReadBool buffer overflow");
    return this.buf[this.n++] != (byte) 0;
  }

  public bool? ReadBoolOrNull() => !this.ReadBool() ? new bool?() : new bool?(this.ReadBool());

  public int ReadInt()
  {
    if (this.buf.Length < this.n + 4)
      throw new IndexOutOfRangeException("ReadInt buffer overflow");
    return (int) this.buf[this.n++] | (int) this.buf[this.n++] << 8 | (int) this.buf[this.n++] << 16 | (int) this.buf[this.n++] << 24;
  }

  public int? ReadIntOrNull() => !this.ReadBool() ? new int?() : new int?(this.ReadInt());

  public string ReadString(bool intern = false)
  {
    int length = this.ReadInt();
    if (this.buf.Length < this.n + length)
      throw new IndexOutOfRangeException("ReadString buffer overflow");
    if (this.charBuf.Length < length)
      this.charBuf = new char[length];
    Buffer.BlockCopy((Array) this.buf, this.n, (Array) this.charBuf, 0, length * 2);
    this.n += length * 2;
    return intern ? string.Intern(new string(this.charBuf, 0, length)) : new string(this.charBuf, 0, length);
  }

  public string ReadStringOrNull(bool intern = false)
  {
    return !this.ReadBool() ? (string) null : this.ReadString(intern);
  }

  public float ReadFloat()
  {
    float[] dst = new float[1];
    if (this.buf.Length < this.n + 4)
      throw new IndexOutOfRangeException("ReadFloat buffer overflow");
    Buffer.BlockCopy((Array) this.buf, this.n, (Array) dst, 0, 4);
    this.n += 4;
    return dst[0];
  }

  public float? ReadFloatOrNull() => !this.ReadBool() ? new float?() : new float?(this.ReadFloat());

  public DateTime ReadDateTime() => DateTime.Parse(this.ReadString());

  public DateTime? ReadDateTimeOrNull()
  {
    string s = this.ReadStringOrNull();
    return s == null ? new DateTime?() : new DateTime?(DateTime.Parse(s));
  }
}
