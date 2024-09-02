// Decompiled with JetBrains decompiler
// Type: Bugu00523Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Bugu00523Scene : NGSceneBase
{
  public Bugu00523Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu00523Scene.\u003ConInitSceneAsync\u003Ec__Iterator3F9 asyncCIterator3F9 = new Bugu00523Scene.\u003ConInitSceneAsync\u003Ec__Iterator3F9();
    return (IEnumerator) asyncCIterator3F9;
  }

  public static void ChangeScene(bool stack, List<ItemInfo> select, ItemInfo target)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_buildup_material", (stack ? 1 : 0) != 0, (object) select, (object) target);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<ItemInfo> select, ItemInfo target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00523Scene.\u003ConStartSceneAsync\u003Ec__Iterator3FA()
    {
      select = select,
      target = target,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene(List<ItemInfo> select, ItemInfo target)
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
