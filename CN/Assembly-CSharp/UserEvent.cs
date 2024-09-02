// Decompiled with JetBrains decompiler
// Type: UserEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UserEvent
{
  public const string ST_PRESS_START = "Press_start";
  public const string ST_FIRST_DOWN_0 = "First_download_0";
  public const string ST_FIRST_DOWN_10 = "First_download_10";
  public const string ST_FIRST_DOWN_20 = "First_download_20";
  public const string ST_FIRST_DOWN_30 = "First_download_30";
  public const string ST_FIRST_DOWN_40 = "First_download_40";
  public const string ST_FIRST_DOWN_50 = "First_download_50";
  public const string ST_FIRST_DOWN_60 = "First_download_60";
  public const string ST_FIRST_DOWN_70 = "First_download_70";
  public const string ST_FIRST_DOWN_80 = "First_download_80";
  public const string ST_FIRST_DOWN_90 = "First_download_90";
  public const string ST_FIRST_DOWN_100 = "First_download_100";
  public const string ST_CMD_START = "Combat_Command_start";
  public const string ST_CMD_END = "Combat_Command_end";
  public const string ST_CAREER_START = "Career_start";
  public const string ST_CAREER_END = "Career_end";
  public const string ST_PROPS_USE_START = "Props_use_start";
  public const string ST_PROPS_USE_END = "Props_use_end";
  public const string ST_FIRST_GACHA_START = "Frist_Gacha_start";
  public const string ST_Frist_Gacha_end = "Frist_Gacha_end";
  public const string ST_Team_editor_start = "Team_editor_start";
  public const string ST_Team_editor_end = "Team_editor_end";
  public const string ST_Unit_synthesis_start = "Unit_synthesis_start";
  public const string ST_Unit_synthesis_end = "Unit_synthesis_end";
  public const string ST_Unit_evolution_start = "Unit_evolution_start";
  public const string ST_Unit_evolution_end = "Unit_evolution_end";
  public const string ST_Unit_strengthen_start = "Unit_strengthen_start";
  public const string ST_Unit_strengthen_end = "Unit_strengthen_end";
  public const string ST_Unit_reincarnation_start = "Unit_reincarnation_start";
  public const string ST_Unit_reincarnation_end = "Unit_reincarnation_end";
  public const string ST_Unit_equipment_start = "Unit_equipment_start";
  public const string ST_Unit_equipment_end = "Unit_equipment_end";
  public const string ST_shop_start = "Shop_start";
  public const string ST_shop_end = "Shop_end";
  public const string ST_Rare_badges_start = "Rare_badges_start";
  public const string ST_Rare_badges_end = "Rare_badges_end";
  public const string ST_War_badge_start = "War_badge_start";
  public const string ST_War_badge_end = "War_badge_end";
  public const string ST_Active_copy_instructions_start = "Active_copy_instructions_start";
  public const string ST_Active_copy_instructions_end = "Active_copy_instructions_end";
  public const string ST_Gear_synthesis_start = "Gear_synthesis_start";
  public const string ST_Gear_synthesis_end = "Gear_synthesis_end";
  public const string ST_Slot_open = "Slot_open";
  public const string ST_Slot_start = "Slot_start";
  public const string ST_Slot_end = "Slot_end";
  public const string ST_Slot_close = "Slot_close";
  public const string ST_Novice_task_start = "Novice_task_start";
  public const string ST_Novice_task_end = "Novice_task_end";
  public const string ST_Novice_task_choice = "Novice_task_choice";
  public const string ST_Novice_task_one = "Novice_task_one";
  public const string ST_Novice_task_two = "Novice_task_two";
  public const string ST_Novice_task_three = "Novice_task_three";
  public const string ST_Novice_task_four = "Novice_task_four";
  public const string ST_Novice_task_five = "Novice_task_five";
  public const string ST_Novice_task_six = "Novice_task_six";
  public const string ST_Novice_task_seven = "Novice_task_seven";
  public const string ST_Novice_task_eight = "Novice_task_eight";
  public const string ST_Novice_task_nine = "Novice_task_nine";
  public const string ST_Receive = "Receive";
  public const string ST_Arena_start = "Arena_start";
  public const string ST_Arena_end = "Arena_end";
  public const string ST_Multiplayer_friend_start = "Multiplayer_friend_start";
  public const string ST_Multiplayer_friend_end = "Multiplayer_friend_end";
  public const string ST_Multiplayer_qualifying_start = "Multiplayer_qualifying_start";
  public const string ST_Multiplayer_qualifying_end = "Multiplayer_qualifying_end";
  public const string ST_Novice_boot_stage_start = "Novice_boot_stage_start";
  public const string ST_Novice_boot_stage_end = "Novice_boot_stage_end";
  public const string ST_Directed_attack = "Directed_attack";
  public const string ST_Command_kill = "Command_kill";
  public const string ST_Boot_attack = "Boot_attack";
  public const string ST_Characteristic_kill = "Characteristic_kill";
  private static Dictionary<string, string> screenShowDic;
  private static Dictionary<string, string> screenCloseDic;

  public static void SendEvent(MonoBehaviour mono, string stag, string remark = null, string des = null)
  {
    Debug.Log((object) ("sendEvent:" + stag + " rmk:" + remark));
    string playId = SDK.instance.GetPlayID();
    int level = 0;
    Player player = SMManager.Get<Player>();
    if (player != null)
      level = player.level;
    mono.StartCoroutine(WebAPI.SendEvent(stag, playId, level, remark, des).Wait());
  }

  public static void SendDownloadEvent(MonoBehaviour mono, int index, int times)
  {
    string stag = (string) null;
    switch (index)
    {
      case 0:
        stag = "First_download_0";
        break;
      case 1:
        stag = "First_download_10";
        break;
      case 2:
        stag = "First_download_20";
        break;
      case 3:
        stag = "First_download_30";
        break;
      case 4:
        stag = "First_download_40";
        break;
      case 5:
        stag = "First_download_50";
        break;
      case 6:
        stag = "First_download_60";
        break;
      case 7:
        stag = "First_download_70";
        break;
      case 8:
        stag = "First_download_80";
        break;
      case 9:
        stag = "First_download_90";
        break;
      case 10:
        stag = "First_download_100";
        break;
    }
    if (stag == null)
      return;
    UserEvent.SendEvent(mono, stag, times.ToString());
  }

  private static void initShowDic()
  {
    UserEvent.screenShowDic = new Dictionary<string, string>()
    {
      {
        "tutorial_battle1",
        "Combat_Command_start"
      },
      {
        "unit004_6_0822",
        "Team_editor_start"
      },
      {
        "unit004_8_3",
        "Unit_synthesis_start"
      },
      {
        "unit004_9_9_evo",
        "Unit_evolution_start"
      },
      {
        "unit004_8_4_reinforce",
        "Unit_strengthen_start"
      },
      {
        "shop007_1_base",
        "Shop_start"
      },
      {
        "shop007_1_base_slot",
        "Shop_start"
      },
      {
        "unit004_4",
        "Unit_equipment_start"
      },
      {
        "bugu005_3",
        "Gear_synthesis_start"
      },
      {
        "quest002_17",
        "Active_copy_instructions_start"
      },
      {
        "colosseum1",
        "Arena_start"
      },
      {
        "dailymission027_1",
        "Novice_task_start"
      }
    };
  }

  private static Dictionary<string, string> showDic
  {
    get
    {
      if (UserEvent.screenShowDic == null)
        UserEvent.initShowDic();
      return UserEvent.screenShowDic;
    }
  }

  public static void SendEvent4TutorialScreenShow(MonoBehaviour mono, string screenName)
  {
    if (!UserEvent.showDic.ContainsKey(screenName))
      return;
    string stag = UserEvent.showDic[screenName];
    if (stag == null)
      return;
    UserEvent.SendEvent(mono, stag);
  }

  private static void initCloseDic()
  {
    UserEvent.screenCloseDic = new Dictionary<string, string>()
    {
      {
        "tutorial_battle1",
        "Combat_Command_end"
      },
      {
        "unit004_6_0822",
        "Team_editor_end"
      },
      {
        "unit004_8_3",
        "Unit_synthesis_end"
      },
      {
        "unit004_9_9_evo",
        "Unit_evolution_end"
      },
      {
        "unit004_8_4_reinforce",
        "Unit_strengthen_end"
      },
      {
        "shop007_1_base",
        "Shop_end"
      },
      {
        "shop007_1_base_slot",
        "Shop_end"
      },
      {
        "unit004_4",
        "Unit_equipment_end"
      },
      {
        "bugu005_3",
        "Gear_synthesis_end"
      },
      {
        "quest002_17",
        "Active_copy_instructions_end"
      },
      {
        "colosseum1",
        "Arena_end"
      },
      {
        "dailymission027_1",
        "Novice_task_end"
      }
    };
  }

  private static Dictionary<string, string> closeDic
  {
    get
    {
      if (UserEvent.screenCloseDic == null)
        UserEvent.initCloseDic();
      return UserEvent.screenCloseDic;
    }
  }

  public static void SendEvent4TotorialScreenClose(MonoBehaviour mono, string screenName)
  {
    if (!UserEvent.closeDic.ContainsKey(screenName))
      return;
    string stag = UserEvent.closeDic[screenName];
    if (stag == null)
      return;
    UserEvent.SendEvent(mono, stag);
  }

  public static void SendByTutorialBGShow(MonoBehaviour mono, string screenName, string bgName)
  {
  }

  public static void SendByTutorialBGClose(MonoBehaviour mono, string screenName, string bgName)
  {
    string stag = (string) null;
    if ("tutorial_battle2" == screenName)
    {
      if ("battle7" == bgName)
        stag = "Career_start";
      else if ("battle3" == bgName)
        stag = "Career_end";
      else if ("battle1" == bgName)
        stag = "Props_use_start";
      else if ("battle10" == bgName)
        stag = "Props_use_end";
    }
    if (stag == null)
      return;
    UserEvent.SendEvent(mono, stag);
  }
}
