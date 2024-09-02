// Decompiled with JetBrains decompiler
// Type: GameCore.LongExtention
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  public static class LongExtention
  {
    public static string ToLocalizeNumberText(this long number) => number.ToString().ToConverter();
  }
}
