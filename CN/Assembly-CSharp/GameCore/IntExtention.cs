// Decompiled with JetBrains decompiler
// Type: GameCore.IntExtention
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public static class IntExtention
  {
    public static string ToLocalizeNumberText(this int number) => number.ToString().ToConverter();
  }
}
