﻿// Decompiled with JetBrains decompiler
// Type: TutorialHomePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHomePage : TutorialPageBase
{
  public override IEnumerator Show()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGGameDataManager>.GetInstance().IsSea = false;
    MypageScene.ChangeScene();
    yield break;
  }

  public override void Advise()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<TutorialRoot>.GetInstance().ForceShowAdviceInNextButton("newchapter_home1_tutorial", new Dictionary<string, Func<Transform, UIButton>>()
    {
      {
        "chapter_home1",
        (Func<Transform, UIButton>) (root => root.GetChildInFind("bottom").GetComponentInChildren<UIButton>())
      }
    }, (System.Action) (() => this.NextPage()));
  }
}
