// Decompiled with JetBrains decompiler
// Type: UnitDetailGroupButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
public class UnitDetailGroupButton : UIButton
{
  private string groupTitle;
  private string groupDescription;
  private string groupSpriteName;
  private Action<string, string, string> pressAction;

  public void Init(
    Action<string, string, string> action,
    string title,
    string descript,
    string spriteName)
  {
    this.pressAction = action;
    this.groupTitle = title;
    this.groupDescription = descript;
    this.groupSpriteName = spriteName;
  }

  public void PressButton()
  {
    if (this.pressAction == null)
      return;
    this.pressAction(this.groupTitle, this.groupDescription, this.groupSpriteName);
  }
}
