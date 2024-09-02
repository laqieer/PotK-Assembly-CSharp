﻿// Decompiled with JetBrains decompiler
// Type: Title0241TitleSetPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Title0241TitleSetPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private UI2DSprite spr;
  [SerializeField]
  private GameObject unknown;
  [SerializeField]
  private GameObject ibtnChange;
  [SerializeField]
  private GameObject ibtnRemove;
  [SerializeField]
  private GameObject ibtnClose;
  private int id;
  private System.Action act;

  [DebuggerHidden]
  public IEnumerator Init(int id, string txt, bool hasEmblem, bool isCur, System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241TitleSetPopup.\u003CInit\u003Ec__Iterator54B()
    {
      id = id,
      act = act,
      txt = txt,
      hasEmblem = hasEmblem,
      isCur = isCur,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Etxt = txt,
      \u003C\u0024\u003EhasEmblem = hasEmblem,
      \u003C\u0024\u003EisCur = isCur,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnChange() => this.StartCoroutine(this.EmblemSetAPI(this.id));

  public void IbtnRemove() => this.StartCoroutine(this.EmblemSetAPI(0));

  [DebuggerHidden]
  private IEnumerator EmblemSetAPI(int ID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241TitleSetPopup.\u003CEmblemSetAPI\u003Ec__Iterator54C()
    {
      ID = ID,
      \u003C\u0024\u003EID = ID,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241TitleSetPopup.\u003CCreateSprite\u003Ec__Iterator54D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
