// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.HashExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace GameCore.Serialization
{
  internal static class HashExtension
  {
    public static int Combine(this int a, int b) => (a << 5) - a + b;
  }
}
