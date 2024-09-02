// Decompiled with JetBrains decompiler
// Type: Title0241Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Title0241Scene : NGSceneBase
{
  [SerializeField]
  private Title0241Menu menu;

  public static void ChangeScene00241(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("title024_1", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Scene.\u003ConStartSceneAsync\u003Ec__Iterator641()
    {
      \u003C\u003Ef__this = this
    };
  }
}
