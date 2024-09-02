// Decompiled with JetBrains decompiler
// Type: Startup00010ManaStone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00010ManaStone : MonoBehaviour
{
  [SerializeField]
  private GameObject getAnimation;
  [SerializeField]
  private GameObject effect;
  [SerializeField]
  private GameObject effect2;
  [SerializeField]
  private GameObject shadow;
  [SerializeField]
  private float wait_time = 0.5f;

  public void Get() => this.getAnimation.SetActive(true);

  public void Effect() => this.StartCoroutine(this.Play());

  [DebuggerHidden]
  private IEnumerator Play()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010ManaStone.\u003CPlay\u003Ec__Iterator18D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
