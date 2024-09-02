﻿// Decompiled with JetBrains decompiler
// Type: PopupCommon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class PopupCommon : BackButtonMonoBehaiviour
{
  public const string common_prefab_path = "Prefabs/popup_common";
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  public UIButton OK;
  private System.Action callback;

  public void OnOk()
  {
    if (this.callback != null)
      this.callback();
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void IbtnNo() => this.OnOk();

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  public static IEnumerator ShowMiniGame(
    string title,
    string message,
    Transform parent,
    System.Action callback = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupCommon.\u003CShowMiniGame\u003Ec__IteratorB91()
    {
      callback = callback,
      parent = parent,
      title = title,
      message = message,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Emessage = message
    };
  }

  public static GameObject LoadPrefab() => Resources.Load<GameObject>("Prefabs/popup_common");

  public void Init(string title, string message, System.Action callback = null)
  {
    this.title.SetText(title);
    this.message.SetText(message);
    this.callback = callback;
  }

  [DebuggerHidden]
  public static IEnumerator Show(string title, string message, System.Action callback = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupCommon.\u003CShow\u003Ec__IteratorB92()
    {
      title = title,
      message = message,
      callback = callback,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Emessage = message,
      \u003C\u0024\u003Ecallback = callback
    };
  }

  public static void defaultCallback() => Debug.Log((object) "popup close");
}
