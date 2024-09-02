// Decompiled with JetBrains decompiler
// Type: Bugu00526Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Bugu00526Scene : NGSceneBase
{
  public Bugu00526Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu00526Scene.\u003ConInitSceneAsync\u003Ec__Iterator3FE asyncCIterator3Fe = new Bugu00526Scene.\u003ConInitSceneAsync\u003Ec__Iterator3FE();
    return (IEnumerator) asyncCIterator3Fe;
  }

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_drilling_base", stack);
  }

  [DebuggerHidden]
  public virtual IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00526Scene.\u003ConStartSceneAsync\u003Ec__Iterator3FF()
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
