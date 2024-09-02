// Decompiled with JetBrains decompiler
// Type: BattleUI05ResultMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05ResultMenu : ResultMenuBase
{
  private const float LINK_WIDTH = 120f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 0.882352948f;
  [SerializeField]
  protected UILabel TxtREADME30;
  [SerializeField]
  protected UILabel TxtSubTitle24;
  [SerializeField]
  protected UILabel TxtTitle30;
  [SerializeField]
  protected UILabel TxtCharaEXP26;
  [SerializeField]
  protected UILabel TxtGetPlayerEXP24;
  [SerializeField]
  protected UILabel TxtGetZenie28;
  [SerializeField]
  protected UILabel TxtNextLevel18;
  [SerializeField]
  protected UILabel TxtNextLevelNB20;
  [SerializeField]
  private GameObject Title;
  [SerializeField]
  private GameObject Scene_Result;
  [SerializeField]
  private GameObject Block_Zeni;
  [SerializeField]
  private GameObject Block_Exp;
  [SerializeField]
  private GameObject Block_CharaExpTitle;
  [SerializeField]
  private GameObject PlayerEXPGauge;
  [SerializeField]
  private GameObject Top;
  [SerializeField]
  public GameObject touch2NextNoFun;
  [HideInInspector]
  public List<bool> BonusFlg;
  private int bonusCategory;
  private GameObject mPlayerLevelupPrefab;
  private GameObject mStageMissionPrefab;
  private GameObject bonus;
  private BattleUI05Bonus bonusScript;
  private GameCore.BattleInfo info;
  private BattleEnd result;
  private NGSoundManager SM;
  private List<GameObject> mResultUnitPanels = new List<GameObject>();
  public Touch2NextAuto touchScript;

  public int BonusCategory => this.bonusCategory;

  public override void OnDestroy()
  {
    this.mResultUnitPanels.Clear();
    base.OnDestroy();
  }

  private void Awake()
  {
    this.SM = Singleton<NGSoundManager>.GetInstance();
    this.mResultUnitPanels.Clear();
    if (Object.op_Implicit((Object) this.touch2NextNoFun))
      this.touch2NextNoFun.SetActive(false);
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CLoadResources\u003Ec__Iterator991()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Init(GameCore.BattleInfo info, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CInit\u003Ec__Iterator992()
    {
      info = info,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void SetZenie(int zenie) => this.TxtGetZenie28.SetTextLocalize(zenie);

  public void SetQuestName(string txt) => this.TxtSubTitle24.SetTextLocalize(txt);

  [DebuggerHidden]
  public IEnumerator OnPlayerLevelup(GameObject obj, int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003COnPlayerLevelup\u003Ec__Iterator993()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CRun\u003Ec__Iterator994()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003COnFinish\u003Ec__Iterator995()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitObjects()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CInitObjects\u003Ec__Iterator996()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowMoney()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CShowMoney\u003Ec__Iterator997()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowPlayerEXP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CShowPlayerEXP\u003Ec__Iterator998()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowTitleEXP()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CShowTitleEXP\u003Ec__Iterator999()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StageMissionPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CStageMissionPopup\u003Ec__Iterator99A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StageMissionCompletePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ResultMenu.\u003CStageMissionCompletePopup\u003Ec__Iterator99B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetBonus(int category, bool isClear = false)
  {
    this.bonusScript.SetBonusTitle(category, isClear);
  }

  public void DisableBonusTitle() => this.SetBonus(0, true);

  private delegate IEnumerator Runner();
}
