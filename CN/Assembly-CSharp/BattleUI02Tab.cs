// Decompiled with JetBrains decompiler
// Type: BattleUI02Tab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI02Tab : BattleMonoBehaviour
{
  public GameObject pmBaseTab;
  public GameObject pmBattleTab;
  public GameObject pmDetailTab;
  public GameObject pmEtcTab;
  public GameObject mBase;
  public GameObject mBaseA;
  public GameObject mBtl;
  public GameObject mBtlA;
  public GameObject mDet;
  public GameObject mDetA;
  public GameObject mEtc;
  public GameObject mEtcA;
  private GameObject[] buttonList;
  private GameObject[] paramList;
  private BattleUI02Tab.Tabname currentTab;

  [DebuggerHidden]
  protected override IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI02Tab.\u003CStart_Original\u003Ec__Iterator88A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI02Tab.\u003CStart_Battle\u003Ec__Iterator88B()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
  }

  public void onBaseButton() => this.SetActiceButton(BattleUI02Tab.Tabname.BaseTab);

  public void onBattleButton() => this.SetActiceButton(BattleUI02Tab.Tabname.BattleTab);

  public void onDetailButton() => this.SetActiceButton(BattleUI02Tab.Tabname.DetailTab);

  public void onEtcButton() => this.SetActiceButton(BattleUI02Tab.Tabname.EtcTab);

  private void SetActiceButton(BattleUI02Tab.Tabname tabName)
  {
    if (this.currentTab == tabName)
      return;
    this.currentTab = tabName;
    for (int index = 0; index < this.buttonList.Length; index += 2)
    {
      bool flag = (BattleUI02Tab.Tabname) (index / 2) == tabName;
      this.buttonList[index].SetActive(!flag);
      this.buttonList[index + 1].SetActive(flag);
    }
    for (int index = 0; index < this.paramList.Length; ++index)
      this.paramList[index].SetActive((BattleUI02Tab.Tabname) index == tabName);
  }

  private enum Tabname
  {
    BaseTab,
    BattleTab,
    DetailTab,
    EtcTab,
  }
}
