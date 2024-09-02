// Decompiled with JetBrains decompiler
// Type: gacha006_effectMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
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
  private PlayerMaterialUnit materialUnit;
  private PlayerItem item;
  private bool m_bIsBeginAnimation;
  public Touch2NextAuto touchScript;
  public int gachaModuleGachaId = -1;
  public string gachaModuleName;
  public Consts.GachaType gachaType;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new gacha006_effectMenu.\u003CSkipCurrentAnimation\u003Ec__Iterator430()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (!this.m_bIsBeginAnimation || !Object.op_Implicit((Object) this.effect_) || this.effect_.isAnimation || this.touchScript.touch2Next.activeSelf)
      return;
    this.touchScript.touch2Next.SetActive(true);
    this.m_bIsBeginAnimation = false;
  }

  public void IbtnSkip()
  {
    Singleton<NGSoundManager>.GetInstance().stopSE();
    if (!Singleton<TutorialRoot>.GetInstance().IsTutorialFinish())
      Singleton<TutorialRoot>.GetInstance().OnGachaFinish();
    else if (!this.deteil_)
    {
      if (this.gachaModuleGachaId >= 0 && this.gachaModuleName != null && this.gachaType != Consts.GachaType.NULL)
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_13", false, (object) this.gachaModuleName, (object) this.gachaType, (object) this.gachaModuleGachaId);
      else
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_13");
    }
    else if (this.item != (PlayerItem) null)
    {
      if (!this.item.gear.kind.isEquip)
        Bugu00561Scene.changeScene(false, this.item, this.is_new_, true);
      else
        Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", false, (object) this.is_new_, (object) this.item);
    }
    else if (this.materialUnit != null)
      Unit00493Scene.changeScene(false, this.materialUnit.unit, this.is_new_, true);
    else if (this.unit.unit.IsMaterialUnit)
      Unit00493Scene.changeScene(false, this.unit.unit, this.is_new_, true);
    else
      Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_8", false, (object) this.unit, (object) this.is_new_);
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
      {
        if (this.gachaModuleGachaId >= 0 && this.gachaModuleName != null && this.gachaType != Consts.GachaType.NULL)
          Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_13", false, (object) this.gachaModuleName, (object) this.gachaType, (object) this.gachaModuleGachaId);
        else
          Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_13");
      }
      else if (this.item != (PlayerItem) null)
      {
        if (!this.item.gear.kind.isEquip)
          Bugu00561Scene.changeScene(false, this.item, this.is_new_, true);
        else
          Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_11", false, (object) this.is_new_, (object) this.item);
      }
      else if (this.materialUnit != null)
        Unit00493Scene.changeScene(false, this.materialUnit.unit, this.is_new_, true);
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
    return (IEnumerator) new gacha006_effectMenu.\u003CSetEffectData\u003Ec__Iterator431()
    {
      gacha_data = gacha_data,
      \u003C\u0024\u003Egacha_data = gacha_data,
      \u003C\u003Ef__this = this
    };
  }
}
