// Decompiled with JetBrains decompiler
// Type: Colosseum0236Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum0236Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtNum01;
  [SerializeField]
  protected UILabel TxtNum02;
  [SerializeField]
  protected UILabel TxtNum04;
  [SerializeField]
  protected UILabel TxtNum05;
  [SerializeField]
  protected UILabel TxtNum06;
  [SerializeField]
  protected UILabel TxtNum07;
  [SerializeField]
  protected UILabel TxtNum08;
  [SerializeField]
  protected UILabel TxtRankName;
  [SerializeField]
  protected UILabel TxtResultsNum;
  private ColosseumUtility.Info info;

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Initialize(ColosseumUtility.Info info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0236Menu.\u003CInitialize\u003Ec__Iterator62F()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Colosseum0234Scene.ChangeScene(this.info);
  }
}
