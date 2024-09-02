// Decompiled with JetBrains decompiler
// Type: Popup02611Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    this.txtTitle.SetText(Consts.Lookup("VERSUS_NOT_LATEST_VERSION_TITLE"));
    this.txtDescription.SetText(Consts.Lookup("VERSUS_NOT_LATEST_VERSION_DESCRIPTION"));
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
