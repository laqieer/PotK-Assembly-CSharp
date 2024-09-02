// Decompiled with JetBrains decompiler
// Type: Quest00228Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00228Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;
  private List<Texture2D[]> textures;

  public virtual void Foreground()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init(QuestScoreCampaignProgress qscp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Menu.\u003CInit\u003Ec__Iterator289()
    {
      qscp = qscp,
      \u003C\u0024\u003Eqscp = qscp,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(Description description)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Menu.\u003CInit\u003Ec__Iterator28A()
    {
      description = description,
      \u003C\u0024\u003Edescription = description,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(QuestExtraDescription[] descriptions)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00228Menu.\u003CInit\u003Ec__Iterator28B()
    {
      descriptions = descriptions,
      \u003C\u0024\u003Edescriptions = descriptions,
      \u003C\u003Ef__this = this
    };
  }
}
