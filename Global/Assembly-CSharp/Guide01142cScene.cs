// Decompiled with JetBrains decompiler
// Type: Guide01142cScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Guide01142cScene : NGSceneBase
{
  public Guide01142cMenu menu;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142cScene.\u003ConStartSceneAsync\u003Ec__Iterator4C8()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }
}
