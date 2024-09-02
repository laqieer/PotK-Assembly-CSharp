// Decompiled with JetBrains decompiler
// Type: Quest00219Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00219Scene : NGSceneBase
{
  public Quest00219Menu menu;
  protected bool IsInit;

  public static void ChangeScene(int Sid, bool stack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_19", (stack ? 1 : 0) != 0, (object) Sid);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync(int Sid)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00219Scene.\u003ConStartSceneAsync\u003Ec__Iterator1C9()
    {
      Sid = Sid,
      \u003C\u0024\u003ESid = Sid,
      \u003C\u003Ef__this = this
    };
  }
}
