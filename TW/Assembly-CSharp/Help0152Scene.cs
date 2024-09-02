// Decompiled with JetBrains decompiler
// Type: Help0152Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Help0152Scene.\u003ConStartSceneAsync\u003Ec__Iterator5CC()
    {
      helps = helps,
      \u003C\u0024\u003Ehelps = helps,
      \u003C\u003Ef__this = this
    };
  }
}
