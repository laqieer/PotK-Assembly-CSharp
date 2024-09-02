// Decompiled with JetBrains decompiler
// Type: Battle01CommandWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Battle01CommandWait : BattleMonoBehaviour, IButtonEnableBeheviour
{
  private BattleUIController controller;
  private UIButton button;
  private static System.Action onClickAction;

  public bool buttonEnable
  {
    set => this.button.isEnabled = value;
  }

  public override IEnumerator onInitAsync()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Battle01CommandWait battle01CommandWait = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    battle01CommandWait.button = battle01CommandWait.GetComponent<UIButton>();
    EventDelegate.Set(battle01CommandWait.button.onClick, new EventDelegate((MonoBehaviour) battle01CommandWait, "onClick"));
    battle01CommandWait.controller = battle01CommandWait.battleManager.getManager<NGBattleUIManager>().controller;
    battle01CommandWait.controller.setButtonBehaviour((IButtonEnableBeheviour) battle01CommandWait);
    return false;
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.battleManager.getController<BattleStateController>().isWaitCurrentAIActionCancel)
      return;
    this.controller.uiWait();
    if (Battle01CommandWait.onClickAction == null)
      return;
    Battle01CommandWait.onClickAction();
  }

  public static void SetOnClickAction(System.Action action) => Battle01CommandWait.onClickAction = action;
}
