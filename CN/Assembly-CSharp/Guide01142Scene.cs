// Decompiled with JetBrains decompiler
// Type: Guide01142Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Guide01142Scene : NGSceneBase
{
  public Guide01142Menu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear gear, bool isDispNumber)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142Scene.\u003ConStartSceneAsync\u003Ec__Iterator569()
    {
      gear = gear,
      isDispNumber = isDispNumber,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003EisDispNumber = isDispNumber,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142Scene.\u003ConEndSceneAsync\u003Ec__Iterator56A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
