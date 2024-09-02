// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.HashExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GameCore.Serialization
{
  internal static class HashExtension
  {
    public static int Combine(this int a, int b) => (a << 5) - a + b;
  }
}
