﻿// Decompiled with JetBrains decompiler
// Type: BackButtonMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class BackButtonMenuBase : NGMenuBase
{
  public bool BackBtnEnable = true;

  protected virtual void Update()
  {
    if (Singleton<CommonRoot>.GetInstance().isInputBlock || !this.BackBtnEnable || Singleton<TutorialRoot>.GetInstance().IsAdviced || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.onBackButton();
  }

  public abstract void onBackButton();
}
