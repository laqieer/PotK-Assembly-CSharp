// Decompiled with JetBrains decompiler
// Type: GearIconHistoryWithNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class GearIconHistoryWithNumber : WithNumber
{
  public override void pressButton()
  {
    if (!this.withNumberInfo.icon.withNumberInfo.buttonOn)
      return;
    base.pressButton();
    string empty = string.Empty;
    string sceneName = this.withNumberInfo.icon.withNumberInfo.unitData.Gear.kind.Enum == GearKindEnum.smith ? (this.withNumberInfo.icon.withNumberInfo.unitData.Gear.compose_kind.kind.Enum == GearKindEnum.smith ? "guide011_4_2c" : "guide011_4_2b") : "guide011_4_2";
    Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true, (object) this.withNumberInfo.icon.withNumberInfo.unitData.Gear, (object) true);
  }
}
