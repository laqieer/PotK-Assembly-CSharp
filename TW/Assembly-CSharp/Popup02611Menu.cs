// Decompiled with JetBrains decompiler
// Type: Popup02611Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Popup02611Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription;

  public void Init()
  {
    Consts instance = Consts.GetInstance();
    this.txtTitle.SetText(instance.VERSUS_NOT_LATEST_VERSION_TITLE);
    this.txtDescription.SetText(instance.VERSUS_NOT_LATEST_VERSION_DESCRIPTION);
  }

  public void IbtnOK() => StoreUtil.OpenMyStore();

  public void IbtnNo()
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.destroyCurrentScene();
    MypageScene.ChangeScene(false);
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
