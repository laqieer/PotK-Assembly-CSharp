// Decompiled with JetBrains decompiler
// Type: TreasureBoxManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TreasureBoxManager : BattleManagerBase
{
  private const float moveTime = 0.1f;
  public string treasurebox_a_path = "Prefabs/BattleCommon/treasurebox/treasurebox_a/Prefab";
  public string treasurebox_b_path = "Prefabs/BattleCommon/treasurebox/treasurebox_b/Prefab";
  public string treasurebox_c_path = "Prefabs/BattleCommon/treasurebox/treasurebox_c/Prefab";
  public string dropicon_gold_path = "Prefabs/BattleCommon/get_item/dropicon_gold_M";
  public string dropicon_item_path = "Prefabs/BattleCommon/get_item/dropicon_item";
  public string dropicon_weapon_path = "Prefabs/BattleCommon/get_item/dropicon_weapon";
  public GameObject lastEffectPrefab;
  public GameObject startPrefab;
  public GameObject movePrefab_1;
  public GameObject movePrefab_2;
  public GameObject movePrefab_3;
  public GameObject treasurebox_a;
  public GameObject treasurebox_b;
  public GameObject treasurebox_c;
  public GameObject dropicon_gold;
  public GameObject dropicon_item;
  public GameObject dropicon_weapon;
  private NGBattleManager battleManager;
  private Queue<TreasureBoxManager.Continuer> exeQuene = new Queue<TreasureBoxManager.Continuer>();

  [DebuggerHidden]
  public override IEnumerator initialize(BattleInfo info, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TreasureBoxManager.\u003Cinitialize\u003Ec__Iterator824()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TreasureBoxManager.\u003Ccleanup\u003Ec__Iterator825()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void execute(
    BL.DropData drop,
    BL.Panel panel,
    Vector3 target,
    Action<BL.DropData> firstCallback,
    Action<BL.DropData> endCallback,
    float time)
  {
    this.battleManager = Singleton<NGBattleManager>.GetInstance();
    this.battleManager.getManager<BattleTimeManager>().setSchedule((Schedule) new TreasureBoxManager.ExecuteSchedule(this, new TreasureBoxManager.Continuer(drop, panel, target, firstCallback, endCallback, time)));
  }

  public void cloneMoveEffect()
  {
    if (this.exeQuene.Count == 0)
      return;
    this.exeQuene.Peek().cloneMoveEffect(this);
  }

  public void startEffect()
  {
    if (this.exeQuene.Count == 0)
      return;
    this.exeQuene.Peek().startEffect(this);
  }

  [DebuggerHidden]
  private IEnumerator doExecute()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TreasureBoxManager.\u003CdoExecute\u003Ec__Iterator826()
    {
      \u003C\u003Ef__this = this
    };
  }

  private class ExecuteSchedule : ScheduleEnumerator
  {
    private TreasureBoxManager parent;
    private TreasureBoxManager.Continuer c;

    public ExecuteSchedule(TreasureBoxManager parent, TreasureBoxManager.Continuer c)
    {
      this.parent = parent;
      this.c = c;
      this.isCompleted = false;
      this.isInsertMode = true;
    }

    [DebuggerHidden]
    public override IEnumerator doBody()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TreasureBoxManager.ExecuteSchedule.\u003CdoBody\u003Ec__Iterator828()
      {
        \u003C\u003Ef__this = this
      };
    }
  }

  private class Continuer
  {
    public bool isRunnging;
    private BL.Panel panel;
    private Vector3 target;
    private float startTime;
    private GameObject boxObject;
    private GameObject moveEffect;
    private GameObject lastEffect;
    private BL.DropData drop;
    private Action<BL.DropData> firstCallback;
    private Action<BL.DropData> endCallback;
    private Vector3 targetPosition;
    private Vector3 velocity;
    private Transform cameraParent;
    private Camera frontCamera;
    private float timeoutTime;
    private bool isDoEndRunning;

    public Continuer(
      BL.DropData drop,
      BL.Panel panel,
      Vector3 target,
      Action<BL.DropData> firstCallback,
      Action<BL.DropData> endCallback,
      float time)
    {
      this.drop = drop;
      this.panel = panel;
      this.target = target;
      this.firstCallback = firstCallback;
      this.endCallback = endCallback;
      this.timeoutTime = time;
    }

    public void execute(TreasureBoxManager tm)
    {
      this.isRunnging = true;
      Camera[] componentsInChildren = tm.battleManager.battleCamera.GetComponentsInChildren<Camera>(true);
      if (this.drop.isDropBox)
      {
        this.cloneBoxPrefab(this.drop, this.panel, tm);
        Animator componentInChildren = this.boxObject.GetComponentInChildren<Animator>();
        if (Object.op_Inequality((Object) componentInChildren, (Object) null))
          componentInChildren.SetTrigger("open");
        else
          Debug.LogWarning((object) ("Treasurebox dropped object animation is missing for " + ((Object) this.boxObject).name));
        Vector3 vector3 = Vector3.op_Multiply(Vector3.forward, Vector3.Distance(this.boxObject.transform.position, ((Component) componentsInChildren[0]).transform.position));
        this.targetPosition = componentsInChildren[0].ScreenToWorldPoint(Vector3.op_Addition(this.target, vector3));
        this.velocity = Vector3.zero;
        foreach (Camera camera in componentsInChildren)
        {
          if (((Object) camera).name == "3D Camera Front")
          {
            this.frontCamera = camera;
            this.cameraParent = ((Component) this.frontCamera).transform.parent;
            ((Component) this.frontCamera).transform.parent = (Transform) null;
          }
        }
      }
      else if (this.firstCallback != null)
        this.firstCallback(this.drop);
      this.startTime = Time.time;
    }

    public void cloneMoveEffect(TreasureBoxManager tm)
    {
      if (Object.op_Equality((Object) this.boxObject, (Object) null))
        return;
      if (this.drop.rarity <= 1)
        this.moveEffect = tm.movePrefab_1.Clone(this.boxObject.transform);
      else if (this.drop.rarity <= 3)
        this.moveEffect = tm.movePrefab_2.Clone(this.boxObject.transform);
      else
        this.moveEffect = tm.movePrefab_3.Clone(this.boxObject.transform);
    }

    public void startEffect(TreasureBoxManager tm)
    {
      GameObject self = (GameObject) null;
      switch (this.drop.reward.Type)
      {
        case MasterDataTable.CommonRewardType.supply:
          self = tm.dropicon_item;
          break;
        case MasterDataTable.CommonRewardType.gear:
          self = tm.dropicon_weapon;
          break;
        case MasterDataTable.CommonRewardType.money:
          self = tm.dropicon_gold;
          break;
      }
      if (Object.op_Inequality((Object) self, (Object) null))
        self.Clone(this.boxObject.transform);
      tm.startPrefab.Clone(this.boxObject.transform);
    }

    private void cloneBoxPrefab(BL.DropData drop, BL.Panel panel, TreasureBoxManager tm)
    {
      BE.PanelResource panelResource = Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel];
      Transform transform = panelResource.gameObject.transform;
      this.boxObject = drop.rarity > 1 ? (drop.rarity > 3 ? tm.treasurebox_c.Clone(transform) : tm.treasurebox_b.Clone(transform)) : tm.treasurebox_a.Clone(transform);
      this.boxObject.transform.localPosition = new Vector3(0.0f, panelResource.gameObject.GetComponent<BattlePanelParts>().getHeight() + 3f, 0.0f);
    }

    public void update(TreasureBoxManager tm)
    {
      if (this.endCallback == null && Object.op_Equality((Object) this.boxObject, (Object) null) || this.isDoEndRunning)
        return;
      if ((double) Time.time - (double) this.startTime > (double) this.timeoutTime)
      {
        tm.StartCoroutine(this.doEnd(tm));
      }
      else
      {
        if (!Object.op_Inequality((Object) this.moveEffect, (Object) null))
          return;
        this.moveEffect.transform.position = Vector3.SmoothDamp(this.moveEffect.transform.position, this.targetPosition, ref this.velocity, 0.1f);
        if ((double) Vector3.Distance(this.moveEffect.transform.position, this.targetPosition) >= 0.0099999997764825821)
          return;
        tm.StartCoroutine(this.doEnd(tm));
      }
    }

    [DebuggerHidden]
    private IEnumerator doEnd(TreasureBoxManager tm)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TreasureBoxManager.Continuer.\u003CdoEnd\u003Ec__Iterator829()
      {
        tm = tm,
        \u003C\u0024\u003Etm = tm,
        \u003C\u003Ef__this = this
      };
    }
  }
}
