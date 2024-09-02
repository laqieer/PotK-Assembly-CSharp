// Decompiled with JetBrains decompiler
// Type: Unit0046Indicator_menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0046Indicator_menu : MonoBehaviour
{
  public Unit0046IndiStatus[] status = new Unit0046IndiStatus[5];
  public Unit0046IndiThumb[] Thumb = new Unit0046IndiThumb[5];

  [DebuggerHidden]
  public IEnumerator SetStatus(PlayerDeck pDeck)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Indicator_menu.\u003CSetStatus\u003Ec__Iterator27C()
    {
      pDeck = pDeck,
      \u003C\u0024\u003EpDeck = pDeck,
      \u003C\u003Ef__this = this
    };
  }
}
