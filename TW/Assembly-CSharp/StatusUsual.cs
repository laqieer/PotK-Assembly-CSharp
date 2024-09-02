// Decompiled with JetBrains decompiler
// Type: StatusUsual
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[Serializable]
public class StatusUsual
{
  public UILabel txt_waiting_for_entery_to_start;
  [SerializeField]
  private GuildStatus myStatus;

  public GuildStatus MyStatus
  {
    get => this.myStatus;
    set => this.myStatus = value;
  }

  [DebuggerHidden]
  public IEnumerator ResourceLoad(GuildRegistration myData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StatusUsual.\u003CResourceLoad\u003Ec__Iterator76F()
    {
      myData = myData,
      \u003C\u0024\u003EmyData = myData,
      \u003C\u003Ef__this = this
    };
  }
}
