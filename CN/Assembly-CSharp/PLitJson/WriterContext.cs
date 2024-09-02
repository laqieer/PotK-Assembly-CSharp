// Decompiled with JetBrains decompiler
// Type: PLitJson.WriterContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace PLitJson
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
