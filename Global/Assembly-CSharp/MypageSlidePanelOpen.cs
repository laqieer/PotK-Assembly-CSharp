// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelOpen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
