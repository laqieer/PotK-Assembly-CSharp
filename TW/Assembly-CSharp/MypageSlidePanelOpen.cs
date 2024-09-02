// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelOpen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class MypageSlidePanelOpen : MonoBehaviour
{
  private Action<MypageSlidePanelOpen> endAction;

  public void Init(Action<MypageSlidePanelOpen> action) => this.endAction = action;

  public void StartEffect()
  {
  }

  public void EndEffect() => this.endAction(this);
}
