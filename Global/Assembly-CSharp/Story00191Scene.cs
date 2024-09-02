// Decompiled with JetBrains decompiler
// Type: Story00191Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Story00191Scene : NGSceneBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private Story00191Menu menu;
  private bool flg_init = true;
  [SerializeField]
  private GameObject IbtnInvite;
  [SerializeField]
  private GameObject IbtnSerialcord;
  [SerializeField]
  private GameObject IbtnSyoutai;
  [SerializeField]
  private GameObject IbtnCopyRight;
  [SerializeField]
  private GameObject IbtnColabo;
  [SerializeField]
  private GameObject IbtnFacebookLogin;
  [SerializeField]
  private GameObject IbtnFacebookLogout;

  public override IEnumerator onInitSceneAsync()
  {
    this.IbtnInvite.SetActive(!WebAPI.LastPlayerBoot.application_review);
    this.IbtnColabo.SetActive(false);
    this.DisableButton("Colabo");
    this.DisableButton("Lobi");
    this.DisableButton("Asct");
    this.DisableButton("As");
    this.IbtnSerialcord.SetActive(false);
    this.IbtnInvite.SetActive(false);
    if (Persist.auth.Data.FBLoginStatus)
    {
      this.IbtnFacebookLogin.SetActive(false);
      this.IbtnFacebookLogout.SetActive(true);
    }
    else
    {
      this.IbtnFacebookLogin.SetActive(true);
      this.IbtnFacebookLogout.SetActive(false);
    }
    this.menu.showBtnCredit(false);
    this.ScrollContainer.ResolvePosition();
    return base.onInitSceneAsync();
  }

  public void onStartScene()
  {
    if (this.flg_init)
    {
      this.ScrollContainer.ResolvePosition();
      this.flg_init = false;
    }
    this.menu.Init();
  }

  private void DisableButton(string buttonName)
  {
    GameObject gameObject = GameObject.Find(buttonName);
    if (!Object.op_Implicit((Object) gameObject))
      return;
    gameObject.SetActive(false);
  }

  private void Update()
  {
    if (Social.localUser.authenticated || !Persist.firstPGSSignIn.Data.Flag())
      return;
    Persist.firstPGSSignIn.Data.SetFlag(false);
    Persist.firstPGSSignIn.Flush();
  }
}
