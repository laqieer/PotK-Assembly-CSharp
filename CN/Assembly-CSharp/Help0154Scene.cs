﻿// Decompiled with JetBrains decompiler
// Type: Help0154Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Help0154Scene : NGSceneBase
{
  public Help0154Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_4", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0154Scene.\u003ConStartSceneAsync\u003Ec__Iterator57C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.menu.InitContact(SMManager.Get<Player>());
}
