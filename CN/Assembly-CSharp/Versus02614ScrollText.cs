// Decompiled with JetBrains decompiler
// Type: Versus02614ScrollText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02614ScrollText : MonoBehaviour
{
  [SerializeField]
  protected GameObject LinkUnit;
  [SerializeField]
  protected UI2DSprite Emblem;
  [SerializeField]
  protected UILabel TxtPT;
  [SerializeField]
  protected UILabel TxtRank;
  [SerializeField]
  protected UILabel TxtLose;
  [SerializeField]
  protected UILabel TxtVictory;
  [SerializeField]
  protected UILabel TxtTotalVictory;
  [SerializeField]
  protected UILabel TxtPlayerName;
  [SerializeField]
  protected UILabel TxtPlayerPoint;
  [SerializeField]
  protected UILabel TxtPlayerRank;

  [DebuggerHidden]
  public IEnumerator Init(PvPRankingPlayer data, GameObject iconPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614ScrollText.\u003CInit\u003Ec__Iterator647()
    {
      data = data,
      iconPrefab = iconPrefab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u003Ef__this = this
    };
  }
}
