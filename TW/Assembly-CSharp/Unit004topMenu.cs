// Decompiled with JetBrains decompiler
// Type: Unit004topMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit004topMenu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UIButton Ibtn_PakuPaku;
  [SerializeField]
  private List<GameObject> campaignIcons;

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004topMenu.\u003CInit\u003Ec__Iterator3AF()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitBoost(List<GameObject> campaignIcons)
  {
    for (int index = 0; index < campaignIcons.Count; ++index)
      campaignIcons[index].SetActive(false);
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    if (boostInfo == null)
      return;
    int[] boostListNow = boostInfo.TypeIdList;
    if (boostListNow.Length == 0)
      return;
    BoostCampaignTypeName[] campaignTypeNameList = MasterData.BoostCampaignTypeNameList;
    Array values = Enum.GetValues(typeof (BoostIconPosition));
    IEnumerable<BoostCampaignTypeName> source = ((IEnumerable<BoostCampaignTypeName>) campaignTypeNameList).Where<BoostCampaignTypeName>((Func<BoostCampaignTypeName, bool>) (w => ((IEnumerable<int>) boostListNow).Contains<int>(w.ID)));
    foreach (object obj in values)
    {
      object e = obj;
      BoostCampaignTypeName campaignTypeName = source.FirstOrDefault<BoostCampaignTypeName>((Func<BoostCampaignTypeName, bool>) (fd => fd.position_BoostIconPosition == (int) e));
      if (campaignTypeName != null)
      {
        string imgName = campaignTypeName.img_name;
        int boostIconPosition = campaignTypeName.position_BoostIconPosition;
        GameObject campaignIcon = campaignIcons[boostIconPosition];
        campaignIcon.SetActive(true);
        campaignIcon.GetComponent<SpriteSelectDirect>().SetSpriteName<string>(imgName);
      }
    }
  }

  public void onStartScene() => ((Component) this).gameObject.SetActive(true);

  public virtual void IbtnBack() => this.backScene();

  public virtual void IbtnFormation_AnimList1() => Unit0046Scene.changeScene(true);

  public virtual void IbtnCpmposite_AnimList2() => Unit00468Scene.changeScene0048(true);

  public virtual void IbtnReinforce() => Unit00468Scene.changeScene00481Reinforce(true);

  public virtual void IbtnEvolution_AnimList3() => Unit00468Scene.changeScene00491Evolution(true);

  public virtual void IbtnTransmigration_AnimLIst4() => Unit00468Scene.changeScene00491Trans(true);

  public virtual void IbtnSell_AnimList4() => Unit00468Scene.changeScene00410(true);

  public virtual void IbtnOverview_AnimList5() => Unit00468Scene.changeScene00411(true);

  public virtual void IbtnEquip_AnimList6() => Unit00468Scene.changeScene00412(true);

  public virtual void IbtnMaterailOverview_AnimList7() => Unit00468Scene.changeScene00414(true);

  public virtual void IbtnOverview() => Bugu0052Scene.ChangeScene(true);

  public virtual void IbtnComposite() => Bugu0053Scene.changeScene(true);

  public virtual void IbtnPakuPaku() => Bugu00522Scene.ChangeScene(true);

  public virtual void IbtnDrilling() => Bugu00526Scene.ChangeScene(true);

  public virtual void IbtnRepair() => Bugu00524Scene.ChangeScene(true);

  public virtual void IbtnSell() => Bugu00525Scene.ChangeScene(true);

  public virtual void IbtnRecipe() => Bugu00510Scene.changeSceneRecipe(true);

  public virtual void IbtnMaterialList() => Bugu005MaterialListScene.ChangeScene(true);

  public virtual void IbtnSupplyList() => Bugu005SupplyListScene.ChangeScene(true);

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  private enum IconPosition
  {
    UnitComposite,
    UnitEvolution,
    UnitStrengthen,
    UnitTransmigration,
    WeaponCompsite,
    WeaponDrilling,
    WeaponRepair,
  }
}
