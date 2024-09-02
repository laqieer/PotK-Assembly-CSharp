// Decompiled with JetBrains decompiler
// Type: BattleStateExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
