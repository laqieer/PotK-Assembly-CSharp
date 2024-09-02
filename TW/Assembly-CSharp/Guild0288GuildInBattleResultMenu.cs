// Decompiled with JetBrains decompiler
// Type: Guild0288GuildInBattleResultMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0288GuildInBattleResultMenu : ResultMenuBase
{
  [SerializeField]
  private GameObject battleResultMenuContainer;
  [SerializeField]
  private GameObject battleResultMenuTitle;
  [SerializeField]
  private GameObject battleResultIconContainer;
  [SerializeField]
  private GameObject winIcon;
  [SerializeField]
  private GameObject drawIcon;
  [SerializeField]
  private GameObject loseIcon;
  [SerializeField]
  private GameObject excellentIcon;
  [SerializeField]
  private GameObject greatIcon;
  [SerializeField]
  private UI2DSprite manaPointSprite;
  [SerializeField]
  private UI2DSprite phankillMedalSprite;
  [SerializeField]
  private UILabel manaPointCountLabel;
  [SerializeField]
  private UILabel phankillMedalCountLabel;
  [SerializeField]
  private GameObject dir_Mana;
  [SerializeField]
  private GameObject dir_Phankill_Medal;
  [SerializeField]
  private UILabel addedExperienceLabel;
  [SerializeField]
  private UILabel experienceToNextLevelLabel;
  [SerializeField]
  private GameObject dir_Exp;
  [SerializeField]
  private GameObject experienceProgressBar;
  private NGSoundManager soundManager;
  private GameObject playerLevelupPrefab;
  private WebAPI.Response.GvgBattleFinish guildBattleResultData;

  private void Awake() => this.soundManager = Singleton<NGSoundManager>.GetInstance();

  private void Update()
  {
  }

  [DebuggerHidden]
  public override IEnumerator Init(
    WebAPI.Response.GvgBattleFinish guildBattleResultData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CInit\u003Ec__Iterator7DA()
    {
      guildBattleResultData = guildBattleResultData,
      \u003C\u0024\u003EguildBattleResultData = guildBattleResultData,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadResources()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CLoadResources\u003Ec__Iterator7DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CRun\u003Ec__Iterator7DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator OnFinish()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003COnFinish\u003Ec__Iterator7DD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitObjects()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CInitObjects\u003Ec__Iterator7DE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowManaPoint()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CShowManaPoint\u003Ec__Iterator7DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowPhankillMedal()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CShowPhankillMedal\u003Ec__Iterator7E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ShowPlayerExperience()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003CShowPlayerExperience\u003Ec__Iterator7E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator OnPlayerLevelup(GameObject obj, int count)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0288GuildInBattleResultMenu.\u003COnPlayerLevelup\u003Ec__Iterator7E2()
    {
      count = count,
      \u003C\u0024\u003Ecount = count,
      \u003C\u003Ef__this = this
    };
  }

  private delegate IEnumerator Runner();
}
