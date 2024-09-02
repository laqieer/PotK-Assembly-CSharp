// Decompiled with JetBrains decompiler
// Type: gacha006_effectMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class gacha006_effectMenu : BackButtonMenuBase
{
  public gacha006_effectScene scene_;
  public EffectControllerGacha effect_;
  public GameObject back_button_;
  private bool deteil_;
  private bool is_new_;
  private PlayerUnit unit;
  private PlayerItem item;

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectMenu.\u003CSkipCurrentAnimation\u003Ec__Iterator3AF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.effect_.isAnimation)
    {
      if (!(((object) this.effect_).GetType().ToString() == "EffectControllerGacha11"))
        return;
      (this.effect_ as EffectControllerGacha11).Skip();
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().stopSE();
      if (!Singleton<TutorialRoot>.GetInstance().IsTutorialFinish())
        Singleton<TutorialRoot>.GetInstance().OnGachaFinish();
      else if (!this.deteil_)
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_13");
      else if (this.unit == (PlayerUnit) null)
      {
        if (!this.item.gear.kind.isEquip)
          Bugu00561Scene.changeScene(false, this.item, this.is_new_, true);
        else
          Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", false, (object) this.is_new_, (object) this.item);
      }
      else if (this.unit.unit.IsMaterialUnit)
        Unit00493Scene.changeScene(false, this.unit.unit, this.is_new_, true);
      else
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_8", false, (object) this.unit, (object) this.is_new_);
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(GachaResultData.ResultData gacha_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectMenu.\u003CSetEffectData\u003Ec__Iterator3B0()
    {
      gacha_data = gacha_data,
      \u003C\u0024\u003Egacha_data = gacha_data,
      \u003C\u003Ef__this = this
    };
  }
}
