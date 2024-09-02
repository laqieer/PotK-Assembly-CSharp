// Decompiled with JetBrains decompiler
// Type: Guild0284TitleSortPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Guild0284TitleSortPopup : DisplayOrderSortPopup
{
  public void Init(System.Action sortAction)
  {
    this.Init(GuildUtil.getTitleSortCategory(), sortAction);
  }

  public override void IbtnOK()
  {
    this.SaveData();
    base.IbtnOK();
  }

  public override void SaveData()
  {
    base.SaveData();
    GuildUtil.setTitleSortCategory(this.nowCategory);
    Persist.guildSetting.Flush();
  }
}
