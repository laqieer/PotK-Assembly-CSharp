// Decompiled with JetBrains decompiler
// Type: GuildGBResultReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildGBResultReward : MonoBehaviour
{
  [SerializeField]
  private NGxScrollMasonry scrollContainer;
  private GameObject marginPrefab;
  private GameObject boxPrefab;

  public void PositionReset() => this.scrollContainer.ResolvePosition();

  [DebuggerHidden]
  public IEnumerator Initialize(WebAPI.Response.GvgResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildGBResultReward.\u003CInitialize\u003Ec__Iterator73F()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator TestInitialize(WebAPI.Response.GvgResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GuildGBResultReward.\u003CTestInitialize\u003Ec__Iterator740 initializeCIterator740 = new GuildGBResultReward.\u003CTestInitialize\u003Ec__Iterator740();
    return (IEnumerator) initializeCIterator740;
  }

  public void Close() => Singleton<PopupManager>.GetInstance().dismiss();
}
