// Decompiled with JetBrains decompiler
// Type: Unit004topMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit004topMenu : BackButtonMenuBase
{
  public const int CAMPAIGN_ICON_UNIT_COMPOSITE = 0;
  public const int CAMPAIGN_ICON_UNIT_EVOLUTION = 1;
  public const int CAMPAIGN_ICON_UNIT_STRENGTHEN = 2;
  public const int CAMPAIGN_ICON_WEAPON_COMPOSITE = 3;
  public const int CAMPAIGN_ICON_WEAPON_DRILLING = 4;
  public const int CAMPAIGN_ICON_WEAPON_REPAIR = 5;
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
    return (IEnumerator) new Unit004topMenu.\u003CInit\u003Ec__Iterator36E()
    {
      \u003C\u003Ef__this = this
    };
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

  public virtual void IbtnOverview() => Bugu0052Scene.changeSceneOverView(true);

  public virtual void IbtnComposite() => Bugu0053Scene.changeScene(true);

  public virtual void IbtnPakuPaku() => Bugu0052Scene.changeScenePakuPakuBase(true, true);

  public virtual void IbtnDrilling() => Bugu0052Scene.changeSceneDrillingBase(true);

  public virtual void IbtnRepair() => Bugu0052Scene.changeSceneRepair(true);

  public virtual void IbtnSell() => Bugu0052Scene.changeSceneSell(true);

  public virtual void IbtnRecipe() => Bugu00510Scene.changeSceneRecipe(true);

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }
}
