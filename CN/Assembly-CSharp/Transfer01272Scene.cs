// Decompiled with JetBrains decompiler
// Type: Transfer01272Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Transfer01272Scene : NGSceneBase
{
  public Transfer01272Menu menu;

  public static void ChangeScene(bool stack, string code, DateTime timeLimit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("transfer012_7_2", (stack ? 1 : 0) != 0, (object) code, (object) timeLimit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Transfer01272Scene.\u003ConStartSceneAsync\u003Ec__Iterator56D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(string code, DateTime timeLimit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Transfer01272Scene.\u003ConStartSceneAsync\u003Ec__Iterator56E()
    {
      code = code,
      timeLimit = timeLimit,
      \u003C\u0024\u003Ecode = code,
      \u003C\u0024\u003EtimeLimit = timeLimit,
      \u003C\u003Ef__this = this
    };
  }
}
