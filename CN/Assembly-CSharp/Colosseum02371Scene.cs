// Decompiled with JetBrains decompiler
// Type: Colosseum02371Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02371Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum02371Menu menu;
  private RankingPlayer MyRanking;
  private RankingPlayer[] TotalRanking;
  private RankingPlayer[] FriendRanking;

  public static void ChangeScene(ColosseumUtility.Info colosseumInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_7_1", false, (object) colosseumInfo);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Scene.\u003ConInitSceneAsync\u003Ec__Iterator5E7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ColosseumUtility.Info colosseumInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Scene.\u003ConStartSceneAsync\u003Ec__Iterator5E8()
    {
      colosseumInfo = colosseumInfo,
      \u003C\u0024\u003EcolosseumInfo = colosseumInfo,
      \u003C\u003Ef__this = this
    };
  }
}
