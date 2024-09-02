// Decompiled with JetBrains decompiler
// Type: Quest00210Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class Quest00210Scene : NGSceneBase
{
  public Quest00210Menu menu;

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
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00210Scene.\u003ConInitSceneAsync\u003Ec__Iterator1DB asyncCIterator1Db = new Quest00210Scene.\u003ConInitSceneAsync\u003Ec__Iterator1DB();
    return (IEnumerator) asyncCIterator1Db;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator1DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<SupplyItem> SupplyItems)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Scene.\u003ConStartSceneAsync\u003Ec__Iterator1DD()
    {
      SupplyItems = SupplyItems,
      \u003C\u0024\u003ESupplyItems = SupplyItems,
      \u003C\u003Ef__this = this
    };
  }
}
