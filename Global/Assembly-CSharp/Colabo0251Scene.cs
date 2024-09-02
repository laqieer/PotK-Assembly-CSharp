// Decompiled with JetBrains decompiler
// Type: Colabo0251Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0251Scene : NGSceneBase
{
  [SerializeField]
  private Colabo0251Menu menu;

  public static void ChangeScene0251(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colabo025_1", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Scene.\u003ConStartSceneAsync\u003Ec__Iterator550()
    {
      \u003C\u003Ef__this = this
    };
  }
}
