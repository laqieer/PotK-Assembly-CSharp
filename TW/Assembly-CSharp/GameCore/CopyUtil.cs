// Decompiled with JetBrains decompiler
// Type: GameCore.CopyUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore.Serialization;

#nullable disable
namespace GameCore
{
  public static class CopyUtil
  {
    public static T DeepCopy<T>(T target)
    {
      return (T) EasySerializer.DeserializeObjectFromMemory(EasySerializer.SerializeObjectToMemory((object) target));
    }
  }
}
