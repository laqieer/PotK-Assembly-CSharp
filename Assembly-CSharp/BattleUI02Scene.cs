// Decompiled with JetBrains decompiler
// Type: BattleUI02Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;

public class BattleUI02Scene : BattleSceneBase
{
  public override IEnumerator onInitSceneAsync()
  {
    BattleUI02Scene battleUi02Scene = this;
    IEnumerator e = Singleton<NGBattleManager>.GetInstance().initBattle();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = battleUi02Scene.gameObject.GetComponent<AttachSEtoButtonOnBattle>().AddSEtoButton();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onStartScene() => Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = false;

  public override void onEndScene() => Singleton<CommonRoot>.GetInstance().isActiveBackground3DCamera = true;

  public override IEnumerator onDestroySceneAsync()
  {
    IEnumerator e = Singleton<NGBattleManager>.GetInstance().cleanupBattle();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
