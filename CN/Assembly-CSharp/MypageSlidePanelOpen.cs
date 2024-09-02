// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelOpen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
