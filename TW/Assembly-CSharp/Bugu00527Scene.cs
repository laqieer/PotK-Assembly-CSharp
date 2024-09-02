// Decompiled with JetBrains decompiler
// Type: Bugu00527Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Bugu00527Scene : NGSceneBase
{
  public Bugu00527Menu menu;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu00527Scene.\u003ConInitSceneAsync\u003Ec__Iterator401 asyncCIterator401 = new Bugu00527Scene.\u003ConInitSceneAsync\u003Ec__Iterator401();
    return (IEnumerator) asyncCIterator401;
  }

  public static void ChangeScene(
    bool stack,
    List<InventoryItem> select,
    ItemInfo target,
    bool isSpecial)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_drilling_material", (stack ? 1 : 0) != 0, (object) select, (object) target, (object) isSpecial);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<InventoryItem> select, ItemInfo target, bool isSpecial)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00527Scene.\u003ConStartSceneAsync\u003Ec__Iterator402()
    {
      isSpecial = isSpecial,
      select = select,
      target = target,
      \u003C\u0024\u003EisSpecial = isSpecial,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void onStartScene(List<InventoryItem> select, ItemInfo target, bool isSpecial)
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
