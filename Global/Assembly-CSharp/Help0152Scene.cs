﻿// Decompiled with JetBrains decompiler
// Type: Help0152Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Help0152Scene : NGSceneBase
{
  public Help0152Menu menu;

  public static void ChangeScene(bool stack, List<HelpHelp> helps)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_2", (stack ? 1 : 0) != 0, (object) helps);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<HelpHelp> helps)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0152Scene.\u003ConStartSceneAsync\u003Ec__Iterator4D7()
    {
      helps = helps,
      \u003C\u0024\u003Ehelps = helps,
      \u003C\u003Ef__this = this
    };
  }
}
