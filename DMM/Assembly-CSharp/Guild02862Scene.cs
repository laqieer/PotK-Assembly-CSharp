﻿// Decompiled with JetBrains decompiler
// Type: Guild02862Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Guild02862Scene : NGSceneBase
{
  [SerializeField]
  private Guild02862Menu menu;

  public static void ChangeScene() => Singleton<NGSceneManager>.GetInstance().changeScene("guild028_6_2", true);

  public IEnumerator onStartSceneAsync()
  {
    IEnumerator e = this.menu.InitializeAsync();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onStartScene() => this.menu.Initialize();
}
