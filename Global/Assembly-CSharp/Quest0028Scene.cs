// Decompiled with JetBrains decompiler
// Type: Quest0028Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0028Scene : NGSceneBase
{
  public Quest0028Menu menu;
  [SerializeField]
  private GameObject bg;
  private List<PlayerItem> SupplyList = new List<PlayerItem>();

  public static void changeScene(bool stack, PlayerHelper friend, PlayerStoryQuestS story_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8", (stack ? 1 : 0) != 0, (object) friend, (object) story_quest);
  }

  public static void changeScene(bool stack, PlayerHelper friend, PlayerExtraQuestS extra_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8", (stack ? 1 : 0) != 0, (object) friend, (object) extra_quest);
  }

  public static void changeScene(bool stack, PlayerHelper friend, PlayerCharacterQuestS char_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8", (stack ? 1 : 0) != 0, (object) friend, (object) char_quest);
  }

  public static void changeScene(bool stack, PlayerHelper friend, PlayerQuestSConverter char_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8", (stack ? 1 : 0) != 0, (object) friend, (object) char_quest);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator235()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerHelper friend, PlayerStoryQuestS story_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator236()
    {
      friend = friend,
      story_quest = story_quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerHelper friend, PlayerExtraQuestS extra_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator237()
    {
      friend = friend,
      extra_quest = extra_quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerHelper friend, PlayerCharacterQuestS char_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator238()
    {
      friend = friend,
      char_quest = char_quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerHelper friend, PlayerQuestSConverter quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator239()
    {
      friend = friend,
      quest = quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerHelper friend,
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0028Scene.\u003ConStartSceneAsync\u003Ec__Iterator23A()
    {
      story_quest = story_quest,
      extra_quest = extra_quest,
      char_quest = char_quest,
      quest = quest,
      friend = friend,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003Efriend = friend,
      \u003C\u003Ef__this = this
    };
  }

  private string setStoryPath(QuestStoryS quest) => quest.GetBackgroundPath();

  private string setExtraPath(QuestExtraS quest) => quest.GetBackgroundPath();

  private string setCharaPath(QuestCharacterS quest) => quest.GetBackgroundPath();

  private string setQuestConverterPath(QuestSConverter quest)
  {
    string backgroundImageName = quest.quest_m.background_image_name;
    return backgroundImageName == null ? Consts.GetInstance().DEFAULT_BACKGROUND : string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) backgroundImageName);
  }

  public override void onEndScene()
  {
    this.menu.EndScene();
    Singleton<CommonRoot>.GetInstance().releaseBackground();
  }
}
