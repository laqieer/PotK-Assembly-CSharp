// Decompiled with JetBrains decompiler
// Type: PLitJson.WriterContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
