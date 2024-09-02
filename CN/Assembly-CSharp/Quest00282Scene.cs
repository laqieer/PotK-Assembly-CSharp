// Decompiled with JetBrains decompiler
// Type: Quest00282Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00282Scene : NGSceneBase
{
  public Quest00282Menu menu;
  public NGxScroll scroll;

  public static void changeScene(bool stack, PlayerStoryQuestS story_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8_2", (stack ? 1 : 0) != 0, (object) story_quest);
  }

  public static void changeScene(bool stack, PlayerQuestSConverter quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8_2", (stack ? 1 : 0) != 0, (object) quest);
  }

  public static void changeScene(bool stack, PlayerExtraQuestS extra_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8_2", (stack ? 1 : 0) != 0, (object) extra_quest);
  }

  public static void changeScene(bool stack, PlayerCharacterQuestS char_quest)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_8_2", (stack ? 1 : 0) != 0, (object) char_quest);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerStoryQuestS story_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator28E()
    {
      story_quest = story_quest,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerQuestSConverter quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator28F()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerExtraQuestS extra_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator290()
    {
      extra_quest = extra_quest,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerCharacterQuestS char_quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator291()
    {
      char_quest = char_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerStoryQuestS story_quest,
    PlayerExtraQuestS extra_quest,
    PlayerCharacterQuestS char_quest,
    PlayerQuestSConverter quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator292()
    {
      story_quest = story_quest,
      extra_quest = extra_quest,
      char_quest = char_quest,
      quest = quest,
      \u003C\u0024\u003Estory_quest = story_quest,
      \u003C\u0024\u003Eextra_quest = extra_quest,
      \u003C\u0024\u003Echar_quest = char_quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConStartSceneAsync\u003Ec__Iterator293()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00282Scene.\u003ConEndSceneAsync\u003Ec__Iterator294()
    {
      \u003C\u003Ef__this = this
    };
  }
}
