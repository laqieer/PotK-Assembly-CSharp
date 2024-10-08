﻿// Decompiled with JetBrains decompiler
// Type: Battle01PVPNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PVPNode : BattleMonoBehaviour
{
  [SerializeField]
  private NGTweenParts[] pvp_disposition_nodes;
  [SerializeField]
  private NGTweenParts[] pvp_battle_nodes;
  [SerializeField]
  private Vector3 cameraOffset;
  private BL.BattleModified<BL.PhaseState> phaseStateModified;
  private bool isDisposition;
  private bool isDead;
  private BattleInputObserver _inputObserver;
  private BattleFieldAttribute _fieldAttribute;

  private BattleInputObserver inputObserver
  {
    get
    {
      if (Object.op_Equality((Object) this._inputObserver, (Object) null))
        this._inputObserver = this.battleManager.getController<BattleInputObserver>();
      return this._inputObserver;
    }
  }

  private BattleFieldAttribute fieldAttribute
  {
    get
    {
      if (Object.op_Equality((Object) this._fieldAttribute, (Object) null))
        this._fieldAttribute = this.battleManager.getController<BattleFieldAttribute>();
      return this._fieldAttribute;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPNode.\u003CStart_Battle\u003Ec__Iterator91B()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    if (this.isDead || !this.battleManager.isOvo || !this.phaseStateModified.isChangedOnce())
      return;
    switch (this.phaseStateModified.value.state)
    {
      case BL.Phase.pvp_move_unit_waiting:
      case BL.Phase.pvp_player_start:
      case BL.Phase.pvp_enemy_start:
      case BL.Phase.pvp_result:
      case BL.Phase.pvp_disposition:
      case BL.Phase.pvp_start_init:
      case BL.Phase.pvp_exception:
        bool flag = this.phaseStateModified.value.state == BL.Phase.pvp_disposition;
        if (!flag)
        {
          foreach (NGTweenParts pvpDispositionNode in this.pvp_disposition_nodes)
            pvpDispositionNode.isActive = flag;
        }
        foreach (NGTweenParts pvpBattleNode in this.pvp_battle_nodes)
          pvpBattleNode.isActive = !flag;
        if (flag)
        {
          foreach (BL.Panel panel in this.battleManager.gameEngine.formationPanel)
            panel.setAttribute(BL.PanelAttribute.playermove);
          this.setCameraTarget(this.battleManager.gameEngine.formationPanel);
          this.inputObserver.setDispositionMode(this.battleManager.gameEngine.formationPanel);
        }
        else
        {
          foreach (BL.Panel panel in this.battleManager.gameEngine.formationPanel)
            panel.unsetAttribute(BL.PanelAttribute.playermove);
          this.inputObserver.setDispositionMode((HashSet<BL.Panel>) null);
          if (this.isDisposition)
          {
            this.battleManager.getManager<BattleTimeManager>().setCurrentUnit((BL.Unit) null);
            this.battleManager.saveEnvironment(true);
            this.dispositionNodeDestroy();
            break;
          }
        }
        this.isDisposition = flag;
        break;
      case BL.Phase.pvp_restart:
        foreach (NGTweenParts pvpDispositionNode in this.pvp_disposition_nodes)
          pvpDispositionNode.isActive = false;
        foreach (NGTweenParts pvpBattleNode in this.pvp_battle_nodes)
          pvpBattleNode.isActive = true;
        this.dispositionNodeDestroy();
        break;
    }
  }

  private void dispositionNodeDestroy()
  {
    this.isDead = true;
    this.StartCoroutine(this.doDead());
  }

  [DebuggerHidden]
  private IEnumerator doDead()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01PVPNode.\u003CdoDead\u003Ec__Iterator91C()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void setCameraTarget(HashSet<BL.Panel> pl)
  {
    BattleCameraController controller = this.battleManager.getController<BattleCameraController>();
    Vector3 vector3_1 = Vector3.zero;
    foreach (BL.Panel key in pl)
      vector3_1 = Vector3.op_Addition(vector3_1, this.env.panelResource[key].gameObject.transform.position);
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(vector3_1.x / (float) pl.Count, vector3_1.y / (float) pl.Count, vector3_1.z / (float) pl.Count);
    Vector3 vector3_2 = this.battleManager.order != 0 ? Vector3.op_UnaryNegation(this.cameraOffset) : this.cameraOffset;
    controller.setLookAtTarget(Vector3.op_Addition(vector3_1, vector3_2));
  }
}
