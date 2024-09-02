// Decompiled with JetBrains decompiler
// Type: PLitJson.JsonToken
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace PLitJson
{
  public enum JsonToken
  {
    None,
    ObjectStart,
    PropertyName,
    ObjectEnd,
    ArrayStart,
    ArrayEnd,
    Int,
    Long,
    Double,
    String,
    Boolean,
    Null,
  }
}
