// Decompiled with JetBrains decompiler
// Type: ActivityAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ActivityAnimation : MonoBehaviour
{
  private GameObject EffectObject;

  private void Start() => this.StartCoroutine(this.SetEffect());

  [DebuggerHidden]
  public IEnumerator SetEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ActivityAnimation.\u003CSetEffect\u003Ec__Iterator9D3()
    {
      \u003C\u003Ef__this = this
    };
  }
}
