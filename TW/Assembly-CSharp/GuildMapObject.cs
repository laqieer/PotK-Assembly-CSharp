// Decompiled with JetBrains decompiler
// Type: GuildMapObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class GuildMapObject : BackButtonMenuBase
{
  [SerializeField]
  private bool isInitialize;
  private bool overlapControl;
  private UITweener[] tweens;
  private float tweensTime;

  public bool IsInitialize
  {
    get => this.isInitialize;
    set => this.isInitialize = value;
  }

  [DebuggerHidden]
  public IEnumerator StartUp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMapObject.\u003CStartUp\u003Ec__Iterator75E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.backScene();

  public void SetActive(bool flag)
  {
    if (!Object.op_Inequality((Object) ((Component) this).gameObject, (Object) null))
      return;
    ((Component) this).gameObject.SetActive(flag);
  }

  public bool PlayTween(bool flag)
  {
    if (this.tweens == null || this.overlapControl == flag)
      return false;
    this.overlapControl = flag;
    if (flag)
    {
      this.SetActive(flag);
      ((IEnumerable<UITweener>) this.tweens).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 13)).ForEach<UITweener>((Action<UITweener>) (x => ((Behaviour) x).enabled = false));
      NGTween.playTweens(this.tweens, NGTween.Kind.START);
    }
    else if (((Component) this).gameObject.activeSelf)
    {
      this.StartCoroutine(this.DelaySetActive(flag, this.tweensTime));
      ((IEnumerable<UITweener>) this.tweens).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 12)).ForEach<UITweener>((Action<UITweener>) (x => ((Behaviour) x).enabled = false));
      NGTween.playTweens(this.tweens, NGTween.Kind.END);
    }
    return true;
  }

  [DebuggerHidden]
  private IEnumerator DelaySetActive(bool flag, float time)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMapObject.\u003CDelaySetActive\u003Ec__Iterator75F()
    {
      flag = flag,
      time = time,
      \u003C\u0024\u003Eflag = flag,
      \u003C\u0024\u003Etime = time,
      \u003C\u003Ef__this = this
    };
  }
}
