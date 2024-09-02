// Decompiled with JetBrains decompiler
// Type: LitJson.WriterContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace LitJson
{
  internal class WriterContext
  {
    public int Count;
    public bool InArray;
    public bool InObject;
    public bool ExpectingValue;
    public int Padding;
  }
}
