// Decompiled with JetBrains decompiler
// Type: BackButtonMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
