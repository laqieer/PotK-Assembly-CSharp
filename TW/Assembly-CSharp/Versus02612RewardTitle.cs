// Decompiled with JetBrains decompiler
// Type: Versus02612RewardTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02612RewardTitle : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite title;

  [DebuggerHidden]
  public IEnumerator Init(int id, bool isGuild = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612RewardTitle.\u003CInit\u003Ec__Iterator676()
    {
      isGuild = isGuild,
      id = id,
      \u003C\u0024\u003EisGuild = isGuild,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
