﻿// Decompiled with JetBrains decompiler
// Type: Quest00210Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Quest00210Scene : NGSceneBase
{
  public Quest00210Menu menu;
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10", stack);
    Singleton<NGSceneManager>.GetInstance().destroyScene("quest002_10a");
  }

  public static void changeScene(bool stack, List<SupplyItem> SupplyItems)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10", (stack ? 1 : 0) != 0, (object) SupplyItems);
    Singleton<NGSceneManager>.GetInstance().destroyScene("quest002_10a");
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator1B0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<SupplyItem> SupplyItems)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator1B1()
    {
      SupplyItems = SupplyItems,
      \u003C\u0024\u003ESupplyItems = SupplyItems,
      \u003C\u003Ef__this = this
    };
  }
}
