﻿// Decompiled with JetBrains decompiler
// Type: Setting01014Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Setting01014Scene : NGSceneBase
{
  [SerializeField]
  private Setting01014Menu menu;

  public override IEnumerator onInitSceneAsync()
  {
    base.onInitSceneAsync();
    this.menu.Initialize();
    yield break;
  }
}
