﻿// Decompiled with JetBrains decompiler
// Type: Story0099Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Story0099Scene : NGSceneBase
{
  [SerializeField]
  private Story0099Menu menu;

  public IEnumerator onStartSceneAsync()
  {
    IEnumerator e = this.menu.InitScene();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
