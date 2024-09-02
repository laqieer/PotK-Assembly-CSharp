// Decompiled with JetBrains decompiler
// Type: Versus02612RewardTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02612RewardTitle : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite title;

  [DebuggerHidden]
  public IEnumerator Init(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612RewardTitle.\u003CInit\u003Ec__Iterator57C()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
