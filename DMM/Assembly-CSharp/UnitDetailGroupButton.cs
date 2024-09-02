// Decompiled with JetBrains decompiler
// Type: UnitDetailGroupButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class UnitDetailGroupButton : UIButton
{
  private string groupTitle;
  private string groupDescription;
  private string groupSpriteName;
  private System.Action<string, string, string> pressAction;

  public void Init(
    System.Action<string, string, string> action,
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
