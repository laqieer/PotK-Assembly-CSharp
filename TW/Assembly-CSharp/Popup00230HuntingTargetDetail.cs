// Decompiled with JetBrains decompiler
// Type: Popup00230HuntingTargetDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup00230HuntingTargetDetail : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTargetPointValue;
  [SerializeField]
  private UILabel txtTargetDescription;
  [SerializeField]
  private CreateIconObject dynThum;
  [SerializeField]
  private UI2DSprite[] gearKindIcons;
  [SerializeField]
  private GameObject dirTargetQuest;
  [SerializeField]
  private GameObject dirTargetQuestNon;
  [SerializeField]
  private NGxScroll scrollContainer;

  private Sprite GetGearKindSprite(GearKind kind)
  {
    string empty = string.Empty;
    return Resources.Load<Sprite>(kind.Enum == GearKindEnum.smith || kind.Enum == GearKindEnum.accessories || kind.Enum == GearKindEnum.dummy || kind.Enum == GearKindEnum.none ? "Icons/Materials/GuideWeaponBtn/slc_unique_wepon_idle" : string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_idle", (object) kind.Enum.ToString()));
  }

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.EventDetail detailData,
    EnemyTopInfo[] infos,
    GameObject questListPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup00230HuntingTargetDetail.\u003CInit\u003Ec__Iterator9F7()
    {
      infos = infos,
      detailData = detailData,
      questListPrefab = questListPrefab,
      \u003C\u0024\u003Einfos = infos,
      \u003C\u0024\u003EdetailData = detailData,
      \u003C\u0024\u003EquestListPrefab = questListPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().onDismiss();
}
