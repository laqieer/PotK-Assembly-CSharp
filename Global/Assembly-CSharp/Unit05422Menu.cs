// Decompiled with JetBrains decompiler
// Type: Unit05422Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Unit05422Menu : Unit00422Menu
{
  protected override void SetBottomMode(UnitIcon icon)
  {
    icon.BottomModeValue = UnitIcon.BottomMode.FriendlyEarth;
  }

  protected override void SetFriendlyEffect(UnitIconBase icon, bool value)
  {
    icon.SetFriendlyEffect(value, true);
  }

  protected override void SetPosessionText(int value, int max)
  {
    this.TxtOwnnumber.SetTextLocalize(string.Format("{0}", (object) value));
  }
}
