// Decompiled with JetBrains decompiler
// Type: Schedule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Schedule
{
  public bool isSetBattleEnable;
  public bool isBattleEnable;
  public float startTime;
  public BL.Phase state = BL.Phase.unset;
  public System.Action endAction;
  public bool isInsertMode;

  public virtual bool body() => true;

  public virtual bool completedp() => true;

  public float time => Time.time;

  public float deltaTime => Time.time - this.startTime;

  public bool execBody()
  {
    BattleTimeManager manager = Singleton<NGBattleManager>.GetInstance().getManager<BattleTimeManager>();
    bool insertMode = manager.insertMode;
    manager.insertMode = this.isInsertMode;
    bool flag = this.body();
    manager.insertMode = insertMode;
    return flag;
  }
}
