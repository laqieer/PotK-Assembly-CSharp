// Decompiled with JetBrains decompiler
// Type: Title0241Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Title0241Scene.\u003ConStartSceneAsync\u003Ec__Iterator5EF()
    {
      \u003C\u003Ef__this = this
    };
  }
}
