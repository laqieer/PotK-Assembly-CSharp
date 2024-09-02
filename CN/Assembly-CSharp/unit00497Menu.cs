// Decompiled with JetBrains decompiler
// Type: unit00497Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class unit00497Menu : BackButtonMenuBase
{
  public unit00497Scene scene;
  public EffectControllerPrincessEvolution effect;
  private Unit00499Scene.Mode mode;
  [SerializeField]
  private GameObject back_button_;
  [SerializeField]
  private bool m_bIsBeginAnimation;
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit00497Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator352()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (!this.m_bIsBeginAnimation || !Object.op_Implicit((Object) this.effect) || this.effect.isAnimation || this.touchScript.touch2Next.activeSelf)
      return;
    this.touchScript.touch2Next.SetActive(true);
    this.m_bIsBeginAnimation = false;
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerUnit> num_list,
    bool is_new,
    List<PlayerUnit> item_data,
    Unit00499Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit00497Menu.\u003CSetEffectData\u003Ec__Iterator353()
    {
      mode = mode,
      num_list = num_list,
      is_new = is_new,
      item_data = item_data,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Eitem_data = item_data,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.effect.isAnimation)
    {
      this.StartCoroutine(this.SkipCurrentAnimation());
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().stopSE();
      Singleton<NGSceneManager>.GetInstance().changeScene("unit004_9_8", false, (object) this.scene.evolutionUnit[0], (object) this.scene.evolutionUnit[1], (object) this.mode, (object) this.scene.fromEarth);
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
    Debug.Log((object) "click default event IbtnStartcomposite");
  }
}
