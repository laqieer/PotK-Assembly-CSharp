// Decompiled with JetBrains decompiler
// Type: GachaPickupSelectScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Scenes/Gacha/PickupSelect/Scene")]
public class GachaPickupSelectScene : NGSceneBase
{
  private static readonly string defName = "gacha006_UnitSelect";
  private GachaPickupSelectMenu menu_;

  public static void changeScene(bool bStack, GachaModuleGacha module, System.Action callbackChanged) => Singleton<NGSceneManager>.GetInstance().changeScene(GachaPickupSelectScene.defName, (bStack ? 1 : 0) != 0, (object) module, (object) callbackChanged);

  public override IEnumerator onInitSceneAsync()
  {
    GachaPickupSelectScene pickupSelectScene = this;
    pickupSelectScene.menu_ = pickupSelectScene.menuBase as GachaPickupSelectMenu;
    IEnumerator e = pickupSelectScene.menu_.doLoadResources();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator onStartSceneAsync(GachaModuleGacha module, System.Action callbackChanged)
  {
    Singleton<CommonRoot>.GetInstance().ShowLoadingLayer(0);
    IEnumerator e = this.menu_.onStartSceneAsync(module, callbackChanged);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void onStartScene(GachaModuleGacha module, System.Action callbackChanged) => Singleton<CommonRoot>.GetInstance().HideLoadingLayer();

  public IEnumerator onBackSceneAsync(GachaModuleGacha module, System.Action callbackChanged)
  {
    yield break;
  }

  public void onBackScene(GachaModuleGacha module, System.Action callbackChanged) => Singleton<CommonRoot>.GetInstance().HideLoadingLayer();
}
