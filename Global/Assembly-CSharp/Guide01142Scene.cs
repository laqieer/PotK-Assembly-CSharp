// Decompiled with JetBrains decompiler
// Type: Guide01142Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Guide01142Scene : NGSceneBase
{
  public Guide01142Menu menu;

  public static void changeScene(bool stack, GearGear gear)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("guide011_4_2", (stack ? 1 : 0) != 0, (object) gear);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(GearGear gear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142Scene.\u003ConStartSceneAsync\u003Ec__Iterator4C5()
    {
      gear = gear,
      \u003C\u0024\u003Egear = gear,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01142Scene.\u003ConEndSceneAsync\u003Ec__Iterator4C6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
