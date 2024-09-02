// Decompiled with JetBrains decompiler
// Type: StatusReady
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[Serializable]
public class StatusReady
{
  [SerializeField]
  public List<SpriteNumberSelectDirect> slc_Remain_hours;
  [SerializeField]
  public List<SpriteNumberSelectDirect> slc_Remain_minutes;
  [SerializeField]
  private NGTweenGaugeFillAmount slc_enemy_pvp_HP_Gauge;
  [SerializeField]
  private NGTweenGaugeFillAmount slc_player_pvp_HP_Gauge;
  [SerializeField]
  private GuildStatus myStatus;
  [SerializeField]
  private GuildStatus enStatus;

  public GuildStatus MyStatus
  {
    get => this.myStatus;
    set => this.myStatus = value;
  }

  public GuildStatus EnStatus
  {
    get => this.enStatus;
    set => this.enStatus = value;
  }

  [DebuggerHidden]
  public IEnumerator ResourceLoad(GuildRegistration myData, GuildRegistration enData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StatusReady.\u003CResourceLoad\u003Ec__Iterator770()
    {
      myData = myData,
      enData = enData,
      \u003C\u0024\u003EmyData = myData,
      \u003C\u0024\u003EenData = enData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetStatus(GuildRegistration myData, GuildRegistration enData)
  {
    this.MyStatus.SetStatus(myData);
    this.EnStatus.SetStatus(enData);
  }

  public void UpdateStatus(GuildRegistration myData, GuildRegistration enData)
  {
    this.MyStatus.UpdateStatus(myData);
    this.EnStatus.UpdateStatus(enData);
  }
}
