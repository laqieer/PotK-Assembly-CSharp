// Decompiled with JetBrains decompiler
// Type: Colosseum0235Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum0235Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel README;
  [SerializeField]
  protected UILabel TxtRankName;
  [SerializeField]
  protected UILabel TxtRankPoint;
  [SerializeField]
  protected UILabel TxtReward;
  [SerializeField]
  private NGxScroll scrollContainer;
  private int cellsPerPage;
  private int[] opponents;
  private ColosseumUtility.Info colosseumInfo;
  private Colosseum0235Scene.Param param;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Initialize(Colosseum0235Scene.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0235Menu.\u003CInitialize\u003Ec__Iterator5D4()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Colosseum0234Scene.ChangeScene(this.param.opponents, this.param.collosseumInfo);
  }

  private void IbtnRankDetail(ColosseumRank rankInfo, int fromPoint, int nextPoint)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    this.param.isInit = false;
    this.param.scrollPos = this.scrollContainer.GetScrollPosition();
    Colosseum02351Scene.ChangeScene(this.param, rankInfo, fromPoint, nextPoint);
  }
}
