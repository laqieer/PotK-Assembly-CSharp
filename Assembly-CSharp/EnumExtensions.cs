// Decompiled with JetBrains decompiler
// Type: EnumExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnitDetails;

public static class EnumExtensions
{
  public static bool IsOn(this Control self, Control flags) => (self & flags) == flags;

  public static bool IsAnyOn(this Control self, Control flags) => (uint) (self & flags) > 0U;

  public static bool IsOff(this Control self, Control flags) => (self & flags) == Control.Zero;

  public static Control Set(this Control self, Control flags) => self | flags;

  public static Control Clear(this Control self, Control flags) => self & ~flags;
}
