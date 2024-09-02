// Decompiled with JetBrains decompiler
// Type: Shop00742SeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742SeasonTicket : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtFlavor;
  [SerializeField]
  protected UILabel TxtName;
  [SerializeField]
  protected UI2DSprite SlcTarget;
  private float scale = 0.7f;

  [DebuggerHidden]
  public IEnumerator Init(int entity_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742SeasonTicket.\u003CInit\u003Ec__Iterator4E7()
    {
      entity_id = entity_id,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u003Ef__this = this
    };
  }
}
