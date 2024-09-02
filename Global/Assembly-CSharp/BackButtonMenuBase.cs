// Decompiled with JetBrains decompiler
// Type: BackButtonMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
