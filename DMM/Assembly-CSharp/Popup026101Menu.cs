﻿// Decompiled with JetBrains decompiler
// Type: Popup026101Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Popup026101Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;

  public virtual void IbtnBack() => Singleton<PopupManager>.GetInstance().onDismiss();

  public virtual void IbtnRecover() => this.StartCoroutine(this.ShowBPAlertPopup());

  public void IbtnNo() => this.IbtnBack();

  public override void onBackButton() => this.IbtnNo();

  private IEnumerator ShowBPAlertPopup()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    this.title.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_101_TITLE);
    this.message.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_101_MESSAGE);
    Future<GameObject> prefabf = Res.Prefabs.popup.popup_026_10_2__anim_popup01.Load<GameObject>();
    IEnumerator e = prefabf.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Singleton<PopupManager>.GetInstance().open(prefabf.Result).GetComponent<Popup026102Menu>().Init();
  }
}
