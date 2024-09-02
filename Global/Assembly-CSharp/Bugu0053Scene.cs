// Decompiled with JetBrains decompiler
// Type: Bugu0053Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Bugu0053Scene : NGSceneBase
{
  private const int SELECT_MAX = 5;
  public Bugu0053Menu menu;
  private List<InventoryItem> playerGears = new List<InventoryItem>();

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_3", stack);
  }

  public static void changeScene(bool stack, List<InventoryItem> gearList)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_3", (stack ? 1 : 0) != 0, (object) gearList);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Scene.\u003ConInitSceneAsync\u003Ec__Iterator325()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Scene.\u003ConStartSceneAsync\u003Ec__Iterator326()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<InventoryItem> gearList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Scene.\u003ConStartSceneAsync\u003Ec__Iterator327()
    {
      gearList = gearList,
      \u003C\u0024\u003EgearList = gearList,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public void onStartScene(List<InventoryItem> gearList)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
  }

  public override void onEndScene() => this.menu.onEndScene();
}
