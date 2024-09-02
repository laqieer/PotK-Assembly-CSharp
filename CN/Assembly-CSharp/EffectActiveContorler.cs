// Decompiled with JetBrains decompiler
// Type: EffectActiveContorler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new EffectActiveContorler.\u003CactiveOffTimer\u003Ec__Iterator9F9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
