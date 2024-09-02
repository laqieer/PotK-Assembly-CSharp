// Decompiled with JetBrains decompiler
// Type: Story0593Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0593Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel mTitleLabel;
  [SerializeField]
  private UIGrid mGrid;
  [SerializeField]
  private UIScrollView mScrollView;
  private GameObject ScrollParts;

  [DebuggerHidden]
  public IEnumerator InitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0593Menu.\u003CInitAsync\u003Ec__Iterator655()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartAsync(EarthQuestChapter chapter, List<Story059ItemData> itemList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0593Menu.\u003CStartAsync\u003Ec__Iterator656()
    {
      chapter = chapter,
      itemList = itemList,
      \u003C\u0024\u003Echapter = chapter,
      \u003C\u0024\u003EitemList = itemList,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
