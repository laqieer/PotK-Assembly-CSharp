// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.HashExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace GameCore.Serialization
{
  internal static class HashExtension
  {
    public static int Combine(this int a, int b) => (a << 5) - a + b;
  }
}
