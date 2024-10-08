﻿// Decompiled with JetBrains decompiler
// Type: ScheduleEnumerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class ScheduleEnumerator : Schedule
{
  protected bool isCompleted;

  public virtual IEnumerator doBody()
  {
    this.isCompleted = true;
    yield break;
  }

  public override bool body()
  {
    Singleton<NGBattleManager>.GetInstance().getManager<BattleTimeManager>().StartCoroutine(this.doBody());
    return true;
  }

  public override bool completedp() => this.isCompleted;
}
