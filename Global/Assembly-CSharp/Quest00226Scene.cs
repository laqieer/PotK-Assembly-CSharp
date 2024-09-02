// Decompiled with JetBrains decompiler
// Type: Quest00226Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00226Scene : NGSceneBase
{
  [SerializeField]
  private Quest00226Menu menu00226;
  protected bool IsInit;

  public static void ChangeScene(int Sid, bool stack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_26", (stack ? 1 : 0) != 0, (object) Sid);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Scene.\u003ConStartSceneAsync\u003Ec__Iterator207()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int Sid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00226Scene.\u003ConStartSceneAsync\u003Ec__Iterator208()
    {
      Sid = Sid,
      \u003C\u0024\u003ESid = Sid,
      \u003C\u003Ef__this = this
    };
  }
}
