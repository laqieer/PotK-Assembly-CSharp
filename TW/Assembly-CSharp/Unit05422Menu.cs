// Decompiled with JetBrains decompiler
// Type: Unit05422Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
