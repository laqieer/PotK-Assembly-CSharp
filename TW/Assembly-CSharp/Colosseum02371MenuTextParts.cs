// Decompiled with JetBrains decompiler
// Type: Colosseum02371MenuTextParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02371MenuTextParts : MonoBehaviour
{
  [SerializeField]
  protected GameObject LinkUnit;
  [SerializeField]
  protected UI2DSprite Emblem;
  [SerializeField]
  protected UILabel TxtIssue;
  [SerializeField]
  protected UILabel TxtLose;
  [SerializeField]
  protected UILabel TxtPlayerName;
  [SerializeField]
  protected UILabel TxtPlayerPoint;
  [SerializeField]
  protected UILabel TxtPlayerRank;
  [SerializeField]
  protected UILabel TxtPT;
  [SerializeField]
  protected UILabel TxtVictory;
  [SerializeField]
  protected UILabel TxtRank;

  [DebuggerHidden]
  public IEnumerator Init(RankingPlayer data, GameObject iconPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371MenuTextParts.\u003CInit\u003Ec__Iterator638()
    {
      data = data,
      iconPrefab = iconPrefab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u003Ef__this = this
    };
  }
}
