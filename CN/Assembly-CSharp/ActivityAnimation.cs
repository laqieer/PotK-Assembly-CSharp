// Decompiled with JetBrains decompiler
// Type: ActivityAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new ActivityAnimation.\u003CSetEffect\u003Ec__Iterator906()
    {
      \u003C\u003Ef__this = this
    };
  }
}
