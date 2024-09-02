// Decompiled with JetBrains decompiler
// Type: Colabo0252Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0252Scene : NGSceneBase
{
  [SerializeField]
  private Colabo0252Menu menu;

  public static void ChangeScene0252(
    CrossFestaCampaign colaboData,
    CrossFestaAchieve[] campaignDatas,
    PlayerCrossFestaSerial[] serials,
    bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colabo025_2", (stack ? 1 : 0) != 0, (object) colaboData, (object) campaignDatas, (object) serials);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    CrossFestaCampaign colaboData,
    CrossFestaAchieve[] campaignDatas,
    PlayerCrossFestaSerial[] serials)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252Scene.\u003ConStartSceneAsync\u003Ec__Iterator651()
    {
      colaboData = colaboData,
      campaignDatas = campaignDatas,
      serials = serials,
      \u003C\u0024\u003EcolaboData = colaboData,
      \u003C\u0024\u003EcampaignDatas = campaignDatas,
      \u003C\u0024\u003Eserials = serials,
      \u003C\u003Ef__this = this
    };
  }
}
