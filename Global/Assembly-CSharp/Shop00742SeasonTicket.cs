// Decompiled with JetBrains decompiler
// Type: Shop00742SeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Shop00742SeasonTicket.\u003CInit\u003Ec__Iterator400()
    {
      entity_id = entity_id,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u003Ef__this = this
    };
  }
}
