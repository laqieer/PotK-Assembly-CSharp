// Decompiled with JetBrains decompiler
// Type: Quest00210Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Quest00210Scene : NGSceneBase
{
  public Quest00210Menu menu;
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10", stack);
    Singleton<NGSceneManager>.GetInstance().destroyScene("quest002_10a");
  }

  public static void changeScene(bool stack, List<SupplyItem> SupplyItems)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_10", (stack ? 1 : 0) != 0, (object) SupplyItems);
    Singleton<NGSceneManager>.GetInstance().destroyScene("quest002_10a");
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator176()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<SupplyItem> SupplyItems)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator177()
    {
      SupplyItems = SupplyItems,
      \u003C\u0024\u003ESupplyItems = SupplyItems,
      \u003C\u003Ef__this = this
    };
  }
}
