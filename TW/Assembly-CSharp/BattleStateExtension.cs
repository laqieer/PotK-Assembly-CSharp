// Decompiled with JetBrains decompiler
// Type: BattleStateExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public static class BattleStateExtension
{
  public static void setState_(this BL.PhaseState self, BL.Phase state, BL env)
  {
    self.setStateWith(state, env, (System.Action) (() =>
    {
      if (!Object.op_Inequality((Object) Singleton<TutorialRoot>.GetInstance(), (Object) null))
        return;
      Singleton<TutorialRoot>.GetInstance().OnBattleStateChange(env);
    }));
  }
}
