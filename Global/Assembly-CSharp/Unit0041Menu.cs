// Decompiled with JetBrains decompiler
// Type: Unit0041Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Unit0041Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UIButton Ibtn_PakuPaku;

  public void Init()
  {
    ((Component) ((Component) this.Ibtn_PakuPaku).transform.parent).gameObject.SetActive(Player.Current.IsUniteReinfoce());
  }

  public virtual void IbtnBack() => this.backScene();

  public virtual void IbtnFormation_AnimList1() => Unit0046Scene.changeScene(true);

  public virtual void IbtnCpmposite_AnimList2() => Unit00468Scene.changeScene0048(true);

  public virtual void IbtnReinforce() => Unit00468Scene.changeScene00481Reinforce(true);

  public virtual void IbtnEvolution_AnimList3() => Unit00468Scene.changeScene00491Evolution(true);

  public virtual void IbtnTransmigration_AnimLIst4() => Unit00468Scene.changeScene00491Trans(true);

  public virtual void IbtnSell_AnimList4() => Unit00468Scene.changeScene00410(true);

  public virtual void IbtnOverview_AnimList5() => Unit00468Scene.changeScene00411(true);

  public virtual void IbtnEquip_AnimList6() => Unit00468Scene.changeScene00412(true);

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }
}
