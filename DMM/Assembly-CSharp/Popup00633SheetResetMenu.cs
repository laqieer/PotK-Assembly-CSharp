﻿// Decompiled with JetBrains decompiler
// Type: Popup00633SheetResetMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;

public class Popup00633SheetResetMenu : BackButtonMenuBase
{
  private Func<IEnumerator> YesAction;
  private System.Action NoAction;

  public IEnumerator Init(Func<IEnumerator> yesAction, System.Action noAction)
  {
    this.YesAction = yesAction;
    this.NoAction = noAction;
    yield break;
  }

  private IEnumerator IbtnYesReset()
  {
    yield break;
  }

  public void IbtnYes()
  {
    if (this.YesAction == null)
      return;
    this.StartCoroutine(this.YesAction());
  }

  public void IbtnNo()
  {
    if (this.NoAction == null)
      return;
    this.NoAction();
  }

  public override void onBackButton() => this.IbtnNo();
}
