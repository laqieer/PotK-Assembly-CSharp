﻿// Decompiled with JetBrains decompiler
// Type: Unit05422Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;

public class Unit05422Scene : NGSceneBase
{
  public Unit05422Menu menu;

  public static void changeScene(bool stack, PlayerUnit playerUnit) => Singleton<NGSceneManager>.GetInstance().changeScene("unit054_2_2", (stack ? 1 : 0) != 0, (object) playerUnit);

  public IEnumerator onStartSceneAsync(PlayerUnit playerUnit)
  {
    IEnumerator e = this.menu.Init(playerUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
