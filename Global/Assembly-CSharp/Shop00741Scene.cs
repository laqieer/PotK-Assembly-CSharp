﻿// Decompiled with JetBrains decompiler
// Type: Shop00741Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00741Scene : NGSceneBase
{
  public Shop00741Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_1", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00741Scene.\u003ConStartSceneAsync\u003Ec__Iterator3F4()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    Player player = SMManager.Get<Player>();
    if (player == null)
      return;
    ((Component) this).GetComponent<Shop00741Menu>().SetTextData(player.medal.ToString());
  }
}
