// Decompiled with JetBrains decompiler
// Type: Title0241SortPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
public class Title0241SortPopup : DisplayOrderSortPopup
{
  public void Init(System.Action sortAction)
  {
    this.Init(Persist.emblemSortCategory.Data.category, sortAction);
  }

  public override void IbtnOK()
  {
    this.SaveData();
    base.IbtnOK();
  }

  public override void SaveData()
  {
    base.SaveData();
    Persist.emblemSortCategory.Data.category = this.nowCategory;
    Persist.emblemSortCategory.Flush();
  }
}
