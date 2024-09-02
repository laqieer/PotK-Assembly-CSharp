// Decompiled with JetBrains decompiler
// Type: GameCore.CopyUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
