// Decompiled with JetBrains decompiler
// Type: PopupPvpMatchResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class PopupPvpMatchResult : NGBattleMenuBase
{
  [SerializeField]
  private GameObject[] effects;
  [SerializeField]
  private GameObject[] effects_win;
  [SerializeField]
  private UI2DSprite linkObj;
  [SerializeField]
  private GameObject effectParent;
  private Sprite sprite;
  private AppPeer.FinishBattle result;
  private int order;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupPvpMatchResult.\u003CStart_Battle\u003Ec__Iterator980()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Start_Battle_Debug()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupPvpMatchResult.\u003CStart_Battle_Debug\u003Ec__Iterator981()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setResult(AppPeer.FinishBattle f, int p)
  {
    this.result = f;
    this.order = p;
    if (!Object.op_Inequality((Object) this.sprite, (Object) null))
      return;
    this.setResultBase();
  }

  private void setResultBase()
  {
    PvpVictoryEffectEnum victoryEffect = this.result.victoryEffects[this.order];
    int num;
    switch (victoryEffect)
    {
      case PvpVictoryEffectEnum.lose_effect:
        num = 1;
        break;
      case PvpVictoryEffectEnum.draw_effect:
        num = 2;
        break;
      default:
        num = 0;
        break;
    }
    int n = num;
    if (n < this.effects.Length)
      ((IEnumerable<GameObject>) this.effects).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(Object.op_Equality((Object) x, (Object) this.effects[n]))));
    if (victoryEffect == PvpVictoryEffectEnum.great_effect || victoryEffect == PvpVictoryEffectEnum.excellent_effect)
    {
      int m = (int) (victoryEffect - 1);
      ((IEnumerable<GameObject>) this.effects_win).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(Object.op_Equality((Object) x, (Object) this.effects_win[m]))));
    }
    else
      ((IEnumerable<GameObject>) this.effects_win).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    this.linkObj.sprite2D = this.sprite;
    this.linkObj.color = Color.Lerp(Color.white, Color.gray, n != 0 ? 1f : 0.0f);
    ((Component) this.linkObj).GetComponent<NGxMaskSpriteWithScale>().FitMask();
    this.effectParent.SetActive(true);
    Singleton<NGSoundManager>.GetInstance().playSE(this.getSEname(victoryEffect));
  }

  private string getSEname(PvpVictoryEffectEnum e)
  {
    switch (e)
    {
      case PvpVictoryEffectEnum.excellent_effect:
        return "SE_0543";
      case PvpVictoryEffectEnum.great_effect:
        return "SE_0542";
      case PvpVictoryEffectEnum.win_effect:
        return "SE_0541";
      case PvpVictoryEffectEnum.lose_effect:
        return "SE_0540";
      case PvpVictoryEffectEnum.draw_effect:
        return "SE_0539";
      default:
        return "SE_0539";
    }
  }
}
