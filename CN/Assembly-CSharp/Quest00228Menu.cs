// Decompiled with JetBrains decompiler
// Type: Quest00228Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Quest00228Menu.\u003CInit\u003Ec__Iterator254()
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
    return (IEnumerator) new Quest00228Menu.\u003CInit\u003Ec__Iterator255()
    {
      description = description,
      \u003C\u0024\u003Edescription = description,
      \u003C\u003Ef__this = this
    };
  }
}
