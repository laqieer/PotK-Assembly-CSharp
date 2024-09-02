// Decompiled with JetBrains decompiler
// Type: unit004812Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class unit004812Menu : BackButtonMenuBase
{
  public unit004812Scene scene;
  public EffectControllerPrincessSynthesis effect;
  private PlayerUnit basePlayerUnit_;
  private PlayerUnit resultPlayerUnit_;
  private List<int> otherData;
  public Dictionary<string, object> showPopupData;
  [SerializeField]
  private GameObject backButton_;

  public Unit00468Scene.Mode mode { get; set; }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator2BC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Menu.\u003CSetEffectData\u003Ec__Iterator2BD()
    {
      result_list = result_list,
      other_list = other_list,
      num_list = num_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u0024\u003Enum_list = num_list,
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
      Unit004813Scene.changeScene(false, this.basePlayerUnit_, this.resultPlayerUnit_, this.otherData, this.showPopupData, this.mode);
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
  }
}
