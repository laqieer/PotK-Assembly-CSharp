﻿// Decompiled with JetBrains decompiler
// Type: BattleStateExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

public static class BattleStateExtension
{
  public static void setState_(this BL.PhaseState self, BL.Phase state, BL env) => self.setStateWith(state, env, (System.Action) (() =>
  {
    if (!((UnityEngine.Object) Singleton<TutorialRoot>.GetInstance() != (UnityEngine.Object) null))
      return;
    Singleton<TutorialRoot>.GetInstance().OnBattleStateChange(env);
  }));
}
