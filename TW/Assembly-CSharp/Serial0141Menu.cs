// Decompiled with JetBrains decompiler
// Type: Serial0141Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Serial0141Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel InpId;
  [SerializeField]
  protected UILabel Txt_Period;
  [SerializeField]
  protected UILabel TxtSerialcode;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  protected virtual void Foreground()
  {
  }

  protected virtual void IbtnPopupSend()
  {
  }

  protected virtual void VScrollBar()
  {
  }

  protected virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator initScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Serial0141Menu.\u003CinitScroll\u003Ec__Iterator5C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private class CampainData
  {
    public int campainId;
    public DateTime fromDate;
    public DateTime toDate;
    public bool isOpen;

    public CampainData(int id, DateTime from, DateTime to)
    {
      this.campainId = id;
      this.fromDate = from;
      this.toDate = to;
      this.isOpen = false;
    }
  }
}
