// Decompiled with JetBrains decompiler
// Type: Help0156Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Help0156Scene : NGSceneBase
{
  public Help0156Menu menu;

  public static void ChangeScene(bool stack, List<BeginnerNaviTitle> bnTitles)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help_015_6", (stack ? 1 : 0) != 0, (object) bnTitles);
  }

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help_015_6", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<BeginnerNaviTitle> bnTitles)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0156Scene.\u003ConStartSceneAsync\u003Ec__Iterator5D3()
    {
      bnTitles = bnTitles,
      \u003C\u0024\u003EbnTitles = bnTitles,
      \u003C\u003Ef__this = this
    };
  }
}
