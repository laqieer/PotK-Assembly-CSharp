﻿// Decompiled with JetBrains decompiler
// Type: Shop00742Key
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742Key : MonoBehaviour
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
    return (IEnumerator) new Shop00742Key.\u003CInit\u003Ec__Iterator491()
    {
      entity_id = entity_id,
      \u003C\u0024\u003Eentity_id = entity_id,
      \u003C\u003Ef__this = this
    };
  }
}
