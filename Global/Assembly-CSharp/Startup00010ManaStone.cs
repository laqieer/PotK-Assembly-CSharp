// Decompiled with JetBrains decompiler
// Type: Startup00010ManaStone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  [DebuggerHidden]
  public IEnumerator Get(System.Action callback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010ManaStone.\u003CGet\u003Ec__Iterator11F()
    {
      callback = callback,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  public void Effect() => this.StartCoroutine(this.Play());

  [DebuggerHidden]
  private IEnumerator Play()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010ManaStone.\u003CPlay\u003Ec__Iterator120()
    {
      \u003C\u003Ef__this = this
    };
  }
}
