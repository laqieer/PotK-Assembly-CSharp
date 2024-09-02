// Decompiled with JetBrains decompiler
// Type: PopupTitleBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class PopupTitleBack : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UIButton ibtnYes;
  [SerializeField]
  private UIButton ibtnNo;
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel description;

  public void Init()
  {
    this.title.SetText(Consts.Lookup("titleback_title"));
    this.description.SetText(Consts.Lookup("titleback_text"));
  }

  public void IbtnYes()
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.RestartGame();
    else
      SceneManager.LoadScene("startup000_6");
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
