// Decompiled with JetBrains decompiler
// Type: Shop00743Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Shop00743Scene : NGSceneBase
{
  public Shop00743Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_3", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Scene.\u003ConStartSceneAsync\u003Ec__Iterator409()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    Player player = SMManager.Get<Player>();
    if (player == null)
      return;
    this.menu.SetTextData(player.battle_medal.ToString());
  }
}
