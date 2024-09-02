// Decompiled with JetBrains decompiler
// Type: Bugu0059Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Bugu0059Scene : NGSceneBase
{
  private Bugu0059Menu menu;
  private bool resetFlag;

  public static void changeScene(bool stack, ItemInfo itemInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9", (stack ? 1 : 0) != 0, (object) itemInfo, null);
  }

  public static void changeScene(bool stack, ItemInfo itemInfo, List<InventoryItem> materials)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_9", (stack ? 1 : 0) != 0, (object) itemInfo, (object) materials);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Scene.\u003ConInitSceneAsync\u003Ec__Iterator3F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ItemInfo itemInfo, List<InventoryItem> materials)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0059Scene.\u003ConStartSceneAsync\u003Ec__Iterator3F4()
    {
      itemInfo = itemInfo,
      materials = materials,
      \u003C\u0024\u003EitemInfo = itemInfo,
      \u003C\u0024\u003Ematerials = materials,
      \u003C\u003Ef__this = this
    };
  }

  public void SetResetFlag() => this.resetFlag = true;
}
