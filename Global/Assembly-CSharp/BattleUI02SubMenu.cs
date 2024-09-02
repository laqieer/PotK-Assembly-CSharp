// Decompiled with JetBrains decompiler
// Type: BattleUI02SubMenu
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
public class BattleUI02SubMenu : BattleBackButtonMenuBase
{
  private BattleUI02SubMenu.Tabname currentTab;
  [SerializeField]
  private SelectParts force;
  [SerializeField]
  private Battle02StatusScrollParts[] statusPlayerList;
  [SerializeField]
  private Battle02StatusScrollParts[] statusEnemyList;
  [SerializeField]
  private GameObject[] tabButton;
  private bool mIsEnd;
  private GameObject[] prefab = new GameObject[4];
  private BL.BattleModified<BL.StructValue<int>> forceModified;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI02SubMenu.\u003CStart_Battle\u003Ec__Iterator73F()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
  }

  public void onButtonBack()
  {
    if (this.mIsEnd)
      return;
    this.mIsEnd = true;
    this.battleManager.popupDismiss();
  }

  public override void onBackButton() => this.onButtonBack();

  public void onButtonForce()
  {
    this.force.inclementLoopNonTween();
    this.SetActiceButton(this.currentTab, true);
  }

  public void onButtonBase() => this.SetActiceButton(BattleUI02SubMenu.Tabname.BaseTab);

  public void onButtonBattle() => this.SetActiceButton(BattleUI02SubMenu.Tabname.BattleTab);

  public void onButtonDetail() => this.SetActiceButton(BattleUI02SubMenu.Tabname.DetailTab);

  public void onButtonEtc() => this.SetActiceButton(BattleUI02SubMenu.Tabname.EtcTab);

  private void SetActiceButton(BattleUI02SubMenu.Tabname tabName, bool forcingUpdate = false)
  {
    if (this.currentTab == tabName && !forcingUpdate)
      return;
    this.currentTab = tabName;
    for (int index = 0; index < this.tabButton.Length; index += 2)
    {
      bool flag = (BattleUI02SubMenu.Tabname) (index / 2) == tabName;
      this.tabButton[index].SetActive(!flag);
      this.tabButton[index + 1].SetActive(flag);
    }
    if (this.force.getValue() == 0)
    {
      ((IEnumerable<Battle02StatusScrollParts>) this.statusEnemyList).ForEach<Battle02StatusScrollParts>((Action<Battle02StatusScrollParts>) (v => ((Component) v).gameObject.SetActive(false)));
      for (int index = 0; index < this.statusPlayerList.Length; ++index)
      {
        ((Component) ((Component) this.statusPlayerList[index]).transform.parent).gameObject.SetActive((BattleUI02SubMenu.Tabname) index == tabName);
        ((Component) this.statusPlayerList[index]).gameObject.SetActive((BattleUI02SubMenu.Tabname) index == tabName);
      }
    }
    else
    {
      ((IEnumerable<Battle02StatusScrollParts>) this.statusPlayerList).ForEach<Battle02StatusScrollParts>((Action<Battle02StatusScrollParts>) (v => ((Component) v).gameObject.SetActive(false)));
      for (int index = 0; index < this.statusEnemyList.Length; ++index)
      {
        ((Component) ((Component) this.statusEnemyList[index]).transform.parent).gameObject.SetActive((BattleUI02SubMenu.Tabname) index == tabName);
        ((Component) this.statusEnemyList[index]).gameObject.SetActive((BattleUI02SubMenu.Tabname) index == tabName);
      }
    }
  }

  private void PartsUpdate()
  {
    for (int index = 0; index < this.prefab.Length; ++index)
    {
      this.statusPlayerList[index].initParts(this.prefab[index], 0);
      this.statusEnemyList[index].initParts(this.prefab[index], 1);
    }
  }

  private void OnDestroy() => Battle02MenuBase.ClearCache();

  private enum Tabname
  {
    BaseTab,
    BattleTab,
    DetailTab,
    EtcTab,
    Max,
  }
}
