// Decompiled with JetBrains decompiler
// Type: EffectActiveContorler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectActiveContorler : MonoBehaviour
{
  [SerializeField]
  private float activeOffTime;

  private void OnEnable()
  {
    if ((double) this.activeOffTime <= 0.0)
      return;
    this.StartCoroutine(this.activeOffTimer());
  }

  [DebuggerHidden]
  private IEnumerator activeOffTimer()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectActiveContorler.\u003CactiveOffTimer\u003Ec__Iterator87E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
