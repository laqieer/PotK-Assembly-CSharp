// Decompiled with JetBrains decompiler
// Type: Quest00229MenuTextParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00229MenuTextParts : MonoBehaviour
{
  [SerializeField]
  protected GameObject LinkUnit;
  [SerializeField]
  protected UI2DSprite Emblem;
  [SerializeField]
  protected UILabel TxtPlayerName;
  [SerializeField]
  protected UILabel TxtPlayerPoint;
  [SerializeField]
  protected UILabel TxtPT;
  [SerializeField]
  protected UILabel TxtRank;

  [DebuggerHidden]
  public IEnumerator Init(QuestScoreRankingPlayer data, GameObject iconPrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229MenuTextParts.\u003CInit\u003Ec__Iterator293()
    {
      data = data,
      iconPrefab = iconPrefab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u003Ef__this = this
    };
  }
}
