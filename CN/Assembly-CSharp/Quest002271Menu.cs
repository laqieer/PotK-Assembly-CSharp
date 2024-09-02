// Decompiled with JetBrains decompiler
// Type: Quest002271Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002271Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtTotalPoint;
  [SerializeField]
  private NGxScrollMasonry scroll;

  [DebuggerHidden]
  public IEnumerator Initialize(QuestScoreCampaignProgress progress, string title, int rank)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002271Menu.\u003CInitialize\u003Ec__Iterator24E()
    {
      title = title,
      rank = rank,
      progress = progress,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Erank = rank,
      \u003C\u0024\u003Eprogress = progress,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
