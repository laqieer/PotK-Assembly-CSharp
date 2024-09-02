﻿// Decompiled with JetBrains decompiler
// Type: Colabo0252SerialPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0252SerialPopup : BackButtonMenuBase
{
  [SerializeField]
  private UIButton ibtnNo;
  [SerializeField]
  private UIButton ibtnCopy;
  [SerializeField]
  private UILabel txtLimit;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtSerial;
  private string serialCode;

  [DebuggerHidden]
  public IEnumerator Init(string description, string serialCode, DateTime? endtime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252SerialPopup.\u003CInit\u003Ec__Iterator654()
    {
      description = description,
      serialCode = serialCode,
      endtime = endtime,
      \u003C\u0024\u003Edescription = description,
      \u003C\u0024\u003EserialCode = serialCode,
      \u003C\u0024\u003Eendtime = endtime,
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

  public void IbtnCopy()
  {
    if (this.IsPush)
      return;
    Clipboard.setText(this.serialCode);
    this.StartCoroutine(this.openPopup008161());
  }

  [DebuggerHidden]
  private IEnumerator openPopup008161()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colabo0252SerialPopup.\u003CopenPopup008161\u003Ec__Iterator655 popup008161CIterator655 = new Colabo0252SerialPopup.\u003CopenPopup008161\u003Ec__Iterator655();
    return (IEnumerator) popup008161CIterator655;
  }
}
