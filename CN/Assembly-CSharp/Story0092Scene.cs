﻿// Decompiled with JetBrains decompiler
// Type: Story0092Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0092Scene : NGSceneBase
{
  public Story0092Menu menu;
  public UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerStoryQuestS quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0092Scene.\u003ConStartSceneAsync\u003Ec__Iterator511()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }
}
