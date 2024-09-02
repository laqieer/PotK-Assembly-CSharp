// Decompiled with JetBrains decompiler
// Type: Shop0074Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0074Scene : NGSceneBase
{
  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0074Scene.\u003ConStartSceneAsync\u003Ec__Iterator3EC()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    Player player = SMManager.Get<Player>();
    if (player == null)
      return;
    ((Component) this).GetComponent<Shop0074Menu>().updateText(player.money.ToString());
  }
}
