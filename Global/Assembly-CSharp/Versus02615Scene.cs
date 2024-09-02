// Decompiled with JetBrains decompiler
// Type: Versus02615Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02615Scene : NGSceneBase
{
  [SerializeField]
  private Versus02615Menu menu;

  public static void ChangeScene(bool stack, string disp_term, RankingGroup ranking_data)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("versus026_15", (stack ? 1 : 0) != 0, (object) disp_term, (object) ranking_data);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(string disp_term, RankingGroup ranking_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02615Scene.\u003ConStartSceneAsync\u003Ec__Iterator597()
    {
      ranking_data = ranking_data,
      disp_term = disp_term,
      \u003C\u0024\u003Eranking_data = ranking_data,
      \u003C\u0024\u003Edisp_term = disp_term,
      \u003C\u003Ef__this = this
    };
  }
}
