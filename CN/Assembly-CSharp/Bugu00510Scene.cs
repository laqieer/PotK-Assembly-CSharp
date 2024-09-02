// Decompiled with JetBrains decompiler
// Type: Bugu00510Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu00510Scene : NGSceneBase
{
  private Bugu00510Menu _menu;

  private Bugu00510Menu menu
  {
    get
    {
      if (Object.op_Equality((Object) this._menu, (Object) null))
        this._menu = this.menuBase as Bugu00510Menu;
      return this._menu;
    }
  }

  public static void changeSceneRecipe(bool isStack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_10", isStack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Scene.\u003ConInitSceneAsync\u003Ec__Iterator378()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Scene.\u003ConStartSceneAsync\u003Ec__Iterator379()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
  }
}
