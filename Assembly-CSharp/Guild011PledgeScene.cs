// Decompiled with JetBrains decompiler
// Type: Guild011PledgeScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class Guild011PledgeScene : NGSceneBase
{
  public Guild011PledgeMenu menu;

  public static void changeScene(bool stack) => Singleton<NGSceneManager>.GetInstance().changeScene("guide011_PledgeHime_List", stack);

  public IEnumerator onStartSceneAsync()
  {
    IEnumerator e = this.menu.onStartSceneAsync();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override IEnumerator onEndSceneAsync()
  {
    yield return (object) null;
  }
}
