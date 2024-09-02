// Decompiled with JetBrains decompiler
// Type: Bugu0051Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Bugu0051Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UIButton Ibtn_PakuPaku;
  [SerializeField]
  protected UIButton Ibtn_Drilling;

  public void Init()
  {
    Player current = Player.Current;
    ((Component) ((Component) this.Ibtn_PakuPaku).transform.parent).gameObject.SetActive(current.IsGearBuildup());
    ((Component) ((Component) this.Ibtn_Drilling).transform.parent).gameObject.SetActive(current.IsGearDrilling());
  }

  public virtual void IbtnOverview() => Bugu0052Scene.changeSceneOverView(true);

  public virtual void IbtnComposite() => Bugu0053Scene.changeScene(true);

  public virtual void IbtnPakuPaku() => Bugu0052Scene.changeScenePakuPakuBase(true, true);

  public virtual void IbtnDrilling() => Bugu0052Scene.changeSceneDrillingBase(true);

  public virtual void IbtnRepair() => Bugu0052Scene.changeSceneRepair(true);

  public virtual void IbtnSell() => Bugu0052Scene.changeSceneSell(true);

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }
}
