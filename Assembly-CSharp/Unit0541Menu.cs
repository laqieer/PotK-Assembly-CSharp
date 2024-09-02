// Decompiled with JetBrains decompiler
// Type: Unit0541Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Unit0541Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIButton evolutionButton;

  public IEnumerator InitSceneAsync()
  {
    if (((IEnumerable<UnitEvolutionPattern>) MasterData.UnitEvolutionPatternList).Count<UnitEvolutionPattern>() <= 0)
    {
      this.evolutionButton.isEnabled = false;
    }
    else
    {
      this.evolutionButton.isEnabled = true;
      yield break;
    }
  }

  public IEnumerator StartSceneAsync()
  {
    yield break;
  }

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051", false);
  }

  public void onOrderClick() => Unit05468Scene.ChangeScene(true);

  public void onEvolutionClick() => Unit0549Scene.ChangeScene(true);

  public void onEquipClick() => Unit05412Scene.ChangeScene(true);

  public void onListClick() => Unit05411Scene.ChangeScene(true);
}
