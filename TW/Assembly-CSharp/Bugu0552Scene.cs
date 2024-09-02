// Decompiled with JetBrains decompiler
// Type: Bugu0552Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Bugu0552Scene : NGSceneBase
{
  public Bugu0552Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0552Scene.\u003ConInitSceneAsync\u003Ec__Iterator84D asyncCIterator84D = new Bugu0552Scene.\u003ConInitSceneAsync\u003Ec__Iterator84D();
    return (IEnumerator) asyncCIterator84D;
  }

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu055_2", stack);
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0552Scene.\u003ConStartSceneAsync\u003Ec__Iterator84E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public override void onEndScene()
  {
    Persist.sortOrder.Flush();
    this.menu.onEndScene();
    ItemIcon.ClearCache();
  }
}
