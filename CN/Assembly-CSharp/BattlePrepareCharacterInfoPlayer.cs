﻿// Decompiled with JetBrains decompiler
// Type: BattlePrepareCharacterInfoPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattlePrepareCharacterInfoPlayer : BattlePrepareCharacterInfoBase
{
  [SerializeField]
  private GameObject selectCommand;
  [SerializeField]
  private NGHorizontalScrollParts indicator;
  [SerializeField]
  private GameObject mDotContainer;
  private GameObject commandPrefab;

  [DebuggerHidden]
  public override IEnumerator Init(BL.UnitPosition up, AttackStatus[] attacks)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattlePrepareCharacterInfoPlayer.\u003CInit\u003Ec__Iterator891()
    {
      up = up,
      attacks = attacks,
      \u003C\u0024\u003Eup = up,
      \u003C\u0024\u003Eattacks = attacks,
      \u003C\u003Ef__this = this
    };
  }

  private void setIndicatorVisible()
  {
    ((Component) this.indicator).gameObject.GetComponent<TweenAlpha>().PlayForward();
  }

  public void onItemChanged()
  {
    if (this.attacks.Length == 0)
    {
      Debug.Log((object) "magicBullets is empty but call onItemChanged");
    }
    else
    {
      int selected = this.indicator.selected;
      if (selected < 0 || selected >= this.magicBullets.Length)
      {
        Debug.LogError((object) ("bug, illegal indicator index=" + (object) selected));
      }
      else
      {
        this.setCurrentAttack(this.magicBullets[selected]);
        int cost = this.magicBullets[selected].magicBullet.cost;
        if (cost > 0)
          this.TxtConsume.SetTextLocalize("-" + (object) cost);
        else
          this.TxtConsume.SetText(string.Empty);
      }
    }
  }

  protected override ResourceObject maskResource() => Res.GUI._009_3_sozai.mask_Chara_L;
}
