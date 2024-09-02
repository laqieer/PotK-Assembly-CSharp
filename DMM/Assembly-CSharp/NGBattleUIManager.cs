// Decompiled with JetBrains decompiler
// Type: NGBattleUIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;

public class NGBattleUIManager : BattleManagerBase
{
  public BattleUIController controller;
  public BattleStateController stateController;

  public override IEnumerator initialize(BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    NGBattleUIManager ngBattleUiManager = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    ngBattleUiManager.controller = ngBattleUiManager.gameObject.AddComponent<BattleUIController>();
    ngBattleUiManager.stateController = ngBattleUiManager.gameObject.AddComponent<BattleStateController>();
    return false;
  }

  public override IEnumerator cleanup()
  {
    this.controller = (BattleUIController) null;
    this.stateController = (BattleStateController) null;
    yield break;
  }
}
