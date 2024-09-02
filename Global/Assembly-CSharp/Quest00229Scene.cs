// Decompiled with JetBrains decompiler
// Type: Quest00229Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00229Scene : NGSceneBase
{
  [SerializeField]
  private Quest00229Menu menu;

  public static void ChangeScene(int scoreCampaignID, bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_29", (stack ? 1 : 0) != 0, (object) scoreCampaignID);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int scoreCampaignID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229Scene.\u003ConStartSceneAsync\u003Ec__Iterator218()
    {
      scoreCampaignID = scoreCampaignID,
      \u003C\u0024\u003EscoreCampaignID = scoreCampaignID,
      \u003C\u003Ef__this = this
    };
  }
}
