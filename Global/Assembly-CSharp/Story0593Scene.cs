﻿// Decompiled with JetBrains decompiler
// Type: Story0593Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Story0593Scene : NGSceneBase
{
  private Story0593Menu menu;
  private bool isInit;

  public static void ChangeScene(
    bool stack,
    EarthQuestChapter chapter,
    List<Story059ItemData> itemList)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("story059_3", (stack ? 1 : 0) != 0, (object) chapter, (object) itemList);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0593Scene.\u003ConInitSceneAsync\u003Ec__Iterator657()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(EarthQuestChapter chapter, List<Story059ItemData> itemList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0593Scene.\u003ConStartSceneAsync\u003Ec__Iterator658()
    {
      chapter = chapter,
      itemList = itemList,
      \u003C\u0024\u003Echapter = chapter,
      \u003C\u0024\u003EitemList = itemList,
      \u003C\u003Ef__this = this
    };
  }
}
