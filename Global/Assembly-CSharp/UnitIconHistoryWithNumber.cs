// Decompiled with JetBrains decompiler
// Type: UnitIconHistoryWithNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class UnitIconHistoryWithNumber : WithNumber
{
  public override void pressButton()
  {
    if (!this.withNumberInfo.icon.withNumberInfo.buttonOn)
      return;
    base.pressButton();
    string sceneName = string.Empty;
    if (this.withNumberInfo.icon.withNumberInfo.IsMaterial)
      sceneName = "guide011_2_2b";
    else if (this.withNumberInfo.icon.withNumberInfo.unitData != null)
    {
      if (this.withNumberInfo.icon.withNumberInfo.unitData.Unit.character.category == UnitCategory.player)
        sceneName = "guide011_2_2";
      else if (this.withNumberInfo.icon.withNumberInfo.unitData.Unit.character.category == UnitCategory.enemy)
        sceneName = "guide011_3_2";
    }
    Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true, (object) this.withNumberInfo.icon.withNumberInfo.unitData.Unit);
  }
}
