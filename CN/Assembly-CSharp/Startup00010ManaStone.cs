// Decompiled with JetBrains decompiler
// Type: Startup00010ManaStone
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Startup00010ManaStone.\u003CPlay\u003Ec__Iterator162()
    {
      \u003C\u003Ef__this = this
    };
  }
}
