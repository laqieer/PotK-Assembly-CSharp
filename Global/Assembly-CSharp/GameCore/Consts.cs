// Decompiled with JetBrains decompiler
// Type: GameCore.Consts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  public class Consts
  {
    private static Regex transRegex;
    private static Consts instance;
    public readonly Dictionary<string, string> tutorial = new Dictionary<string, string>();
    public readonly Color UI3DMODEL_AMBIENT_COLOR = new Color(0.905882359f, 0.905882359f, 0.905882359f);
    public readonly Color UI3DMODEL_DEFAULT_AMBIENT_COLOR = new Color(0.2f, 0.2f, 0.2f);
    public readonly Color GACHA_RESULT_BACKGROUND_COLOR = new Color(0.6f, 0.6f, 0.6f, 1f);
    public readonly Vector3 UI3DMODEL_DIRECTIONAL_LIGHT_ROUTATE = new Vector3(23.35987f, 35.98368f, -30.84772f);
    public readonly int UNIT_EXTEND_VALUE = 5;
    public readonly int ITEM_EXTEND_VALUE = 5;
    public readonly int UNIT_EXTEND_MAX = 500;
    public readonly int ITEM_EXTEND_MAX = 500;
    public readonly Color UI_SPRITE_NORMAL_COLOR = new Color(0.5f, 0.5f, 0.5f, 1f);
    public readonly Color UI_SPRITE_HIGHLIGHT_COLOR = new Color(0.75f, 0.75f, 0.75f, 1f);
    public readonly Color UI_SPRITE_DISABLED_COLOR = new Color(0.25f, 0.25f, 0.25f, 1f);
    public readonly Color UI_LABEL_NORMAL_COLOR = new Color(1f, 1f, 1f, 1f);
    public readonly Color UI_LABEL_DISABLED_COLOR = new Color(0.5f, 0.5f, 0.5f, 1f);
    public readonly string PLATFORM_LC = "android";
    public readonly int MONEY_MAX = 99999999;
    public readonly int MEDAL_MAX = 99999999;
    public readonly int KEY_MAX = 99999999;
    public readonly int FRIEND_POINT_MAX = 99999999;
    public readonly int NORMAL_BUGU;
    public readonly int CUSTOM_BUGU = 1;
    public readonly int QUEST_KEY_ITEM = 2;
    public readonly string DEFAULT_BACKGROUND = "Prefabs/BackGround/flower_garden";
    public readonly string BACKGROUND_BASE_PATH = "Prefabs/BackGround/{0}";
    public readonly double APP_TIME_ZONE = 9.0;
    public readonly int DECK_POSITION_FRIEND = 6;

    private Consts()
    {
    }

    private Consts(ConstsConsts[] consts)
    {
      System.Type type = this.GetType();
      foreach (ConstsConsts constsConsts in consts)
      {
        string[] source = constsConsts.name.Split('.');
        if (source.Length == 2)
        {
          string name = ((IEnumerable<string>) source).First<string>();
          FieldInfo field = type.GetField(name);
          if ((object) field == null)
            Debug.LogWarning((object) ("consts not found name=" + name));
          else if (!(field.GetValue((object) this) is Dictionary<string, string> dictionary))
          {
            Debug.LogError((object) ("consts cast Dictionary<string, string> is null. name=" + name));
          }
          else
          {
            string key = ((IEnumerable<string>) source).Last<string>();
            dictionary[key] = constsConsts.description;
          }
        }
      }
    }

    public static string Lookup(string key, IDictionary args = null)
    {
      string result = string.Empty;
      if (!LocalizationManager.TryGetTermTranslation(key, out result))
      {
        Debug.LogError((object) ("[LOCALIZATION] Cannot find translation for term " + key));
        return string.Empty;
      }
      if (args == null)
        return result;
      if (Consts.transRegex == null)
        Consts.transRegex = new Regex("%\\(([^)]+)\\)s");
      return Consts.transRegex.Replace(result, (MatchEvaluator) (match =>
      {
        string key1 = match.Groups[1].Value;
        if (args.Contains((object) key1))
          return string.Empty + args[(object) key1];
        Debug.LogWarning((object) string.Format("[LOCALIZATION] Could not find translation key \"{0}\": {1}", (object) key1, (object) result));
        return string.Empty;
      }));
    }

    public static Consts GetInstance()
    {
      if (Consts.instance == null)
        Consts.instance = new Consts();
      return Consts.instance;
    }

    public static void Update(ConstsConsts[] consts) => Consts.instance = new Consts(consts);

    public string hummableSize(long requiredSize)
    {
      if (requiredSize >= 1073741824L)
        return Consts.Lookup("SIZE", (IDictionary) new Hashtable()
        {
          {
            (object) "size",
            (object) ((double) Mathf.Ceil((float) requiredSize / 1.07374182E+09f * 10f) / 10.0)
          },
          {
            (object) "unit",
            (object) Consts.Lookup("G")
          }
        });
      if (requiredSize >= 1048576L)
        return Consts.Lookup("SIZE", (IDictionary) new Hashtable()
        {
          {
            (object) "size",
            (object) ((double) Mathf.Ceil((float) requiredSize / 1048576f * 10f) / 10.0)
          },
          {
            (object) "unit",
            (object) Consts.Lookup("M")
          }
        });
      if (requiredSize >= 1024L)
        return Consts.Lookup("SIZE", (IDictionary) new Hashtable()
        {
          {
            (object) "size",
            (object) ((double) Mathf.Ceil((float) requiredSize / 1024f * 10f) / 10.0)
          },
          {
            (object) "unit",
            (object) Consts.Lookup("K")
          }
        });
      return Consts.Lookup("SIZE", (IDictionary) new Hashtable()
      {
        {
          (object) "size",
          (object) ((double) Mathf.Ceil((float) requiredSize / 1f * 10f) / 10.0)
        },
        {
          (object) "unit",
          (object) string.Empty
        }
      });
    }

    public string clearCacheProgress(int a, int b)
    {
      return string.Format(Consts.Lookup("clear_cache_progress"), (object) a, (object) b);
    }

    public string dlcNotEnoughDiskSpace(long requiredSize)
    {
      return string.Format(Consts.Lookup("dlc_fail_disk_space_text"), (object) this.hummableSize(requiredSize));
    }

    public string bulkDownloadText(long requiredSize)
    {
      return string.Format(Consts.Lookup("bulk_download_text"), (object) this.hummableSize(requiredSize));
    }

    public enum GachaType
    {
      NULL = 0,
      KISEKI = 1,
      FRIEND = 2,
      TICKET = 4,
      BEGINNER = 5,
      GIFT = 6,
      SHEET = 7,
    }
  }
}
