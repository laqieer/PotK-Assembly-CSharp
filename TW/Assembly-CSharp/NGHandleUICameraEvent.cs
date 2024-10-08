﻿// Decompiled with JetBrains decompiler
// Type: NGHandleUICameraEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGHandleUICameraEvent : MonoBehaviour
{
  private static readonly string[] closeNames = new string[4]
  {
    "ibtn_Close",
    "ibtn_Back",
    "ibtn_Popup_Close",
    "ibtn_Popup_No"
  };
  private static readonly string[] okNames = new string[3]
  {
    "ibtn_On_",
    "ibtn_Off_",
    "ibtn_Sortie"
  };
  private static readonly string[] battleNames = new string[1]
  {
    "ibtn_Attack"
  };

  private void Awake()
  {
    Debug.Log((object) "[DEBUG-5800] Awake called");
    if (!Object.op_Equality((Object) UICamera.genericEventHandler, (Object) null))
      return;
    UICamera.genericEventHandler = ((Component) this).gameObject;
  }

  private void OnClick()
  {
    if (Object.op_Equality((Object) UICamera.currentTouch.pressed, (Object) null))
      return;
    this.clickDispatch(UICamera.currentTouch.pressed);
    this.clickBlock(UICamera.currentTouch.pressed);
  }

  private void clickBlock(GameObject go)
  {
    Singleton<CommonRoot>.GetInstance().isTouchBlockAutoClose = true;
  }

  private bool clickDispatch(GameObject go)
  {
    string name = ((Object) go).name;
    return this.casePlay("SE_1030", ((IEnumerable<string>) NGHandleUICameraEvent.battleNames).Any<string>((Func<string, bool>) (x => x == name))) || this.casePlay("SE_1004", ((IEnumerable<string>) NGHandleUICameraEvent.closeNames).Any<string>((Func<string, bool>) (x => x == name))) || this.casePlay("SE_1003", ((IEnumerable<string>) NGHandleUICameraEvent.okNames).Any<string>((Func<string, bool>) (x => x.StartsWith(name)))) || this.casePlay("SE_2002", name.Equals("ibtn_Battle_Start_002_8")) || this.casePlay("SE_1002", name.StartsWith("ibtn_")) || this.casePlay("SE_1005", name.StartsWith("uipopuplist_"));
  }

  private bool casePlay(string name, bool isPlay)
  {
    if (isPlay)
      this.playSE(name);
    return isPlay;
  }

  private void playSE(string name)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!Object.op_Inequality((Object) instance, (Object) null))
      return;
    instance.playSE(name);
  }
}
