// Decompiled with JetBrains decompiler
// Type: Guide01142bScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Guide01142bScene : NGSceneBase
{
  public Guide01142bMenu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear gear, bool isDispNumber)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142bScene.\u003ConStartSceneAsync\u003Ec__Iterator5BD()
    {
      gear = gear,
      isDispNumber = isDispNumber,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003EisDispNumber = isDispNumber,
      \u003C\u003Ef__this = this
    };
  }
}
