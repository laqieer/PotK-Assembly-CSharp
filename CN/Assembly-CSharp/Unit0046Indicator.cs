// Decompiled with JetBrains decompiler
// Type: Unit0046Indicator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0046Indicator : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtLeaderskillDescription;
  [SerializeField]
  private UILabel TxtLeaderskillName;

  [DebuggerHidden]
  public IEnumerator InitPlayerDeck(Player player, PlayerDeck playerDeck)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Indicator.\u003CInitPlayerDeck\u003Ec__Iterator2E2()
    {
      playerDeck = playerDeck,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u003Ef__this = this
    };
  }
}
