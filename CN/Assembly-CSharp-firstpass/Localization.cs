// Decompiled with JetBrains decompiler
// Type: Localization
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Internal/Localization")]
public class Localization : MonoBehaviour
{
  private static Localization mInstance;
  public static string[] knownLanguages;
  public static bool localizationHasBeenSet = false;
  [HideInInspector]
  public string startingLanguage = "English";
  [HideInInspector]
  public TextAsset[] languages;
  private static Dictionary<string, string> mOldDictionary = new Dictionary<string, string>();
  private static Dictionary<string, string[]> mDictionary = new Dictionary<string, string[]>();
  private static int mLanguageIndex = -1;
  private static string mLanguage;

  public static Dictionary<string, string[]> dictionary
  {
    get
    {
      if (!Localization.localizationHasBeenSet)
        Localization.language = PlayerPrefs.GetString("Language", "English");
      return Localization.mDictionary;
    }
  }

  public static bool isActive
  {
    get => Object.op_Inequality((Object) Localization.mInstance, (Object) null);
  }

  public static Localization instance
  {
    get
    {
      if (Object.op_Equality((Object) Localization.mInstance, (Object) null))
      {
        Localization.mInstance = Object.FindObjectOfType(typeof (Localization)) as Localization;
        if (Object.op_Equality((Object) Localization.mInstance, (Object) null))
        {
          GameObject gameObject = new GameObject("_Localization");
          Object.DontDestroyOnLoad((Object) gameObject);
          Localization.mInstance = gameObject.AddComponent<Localization>();
        }
      }
      return Localization.mInstance;
    }
  }

  private void Awake()
  {
    if (Object.op_Equality((Object) Localization.mInstance, (Object) null))
    {
      Localization.mInstance = this;
      Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
      if (Localization.mOldDictionary.Count == 0 && Localization.mDictionary.Count == 0)
        Localization.language = PlayerPrefs.GetString("Language", this.startingLanguage);
      if (!string.IsNullOrEmpty(Localization.mLanguage) || this.languages == null || this.languages.Length <= 0)
        return;
      Localization.language = ((Object) this.languages[0]).name;
    }
    else
      Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void OnEnable()
  {
    if (!Object.op_Equality((Object) Localization.mInstance, (Object) null))
      return;
    Localization.mInstance = this;
  }

  private void OnDisable()
  {
    Localization.localizationHasBeenSet = false;
    Localization.mLanguageIndex = -1;
    Localization.mDictionary.Clear();
    Localization.mOldDictionary.Clear();
  }

  private void OnDestroy()
  {
    if (!Object.op_Equality((Object) Localization.mInstance, (Object) this))
      return;
    Localization.mInstance = (Localization) null;
  }

  [Obsolete("Use Localization.language instead")]
  public string currentLanguage
  {
    get => Localization.language;
    set => Localization.language = value;
  }

  public static string language
  {
    get => Localization.mLanguage;
    set
    {
      if (!(Localization.mLanguage != value))
        return;
      if (!string.IsNullOrEmpty(value))
      {
        if (Localization.mDictionary.Count == 0)
        {
          TextAsset asset1 = !Localization.localizationHasBeenSet ? Resources.Load(nameof (Localization), typeof (TextAsset)) as TextAsset : (TextAsset) null;
          Localization.localizationHasBeenSet = true;
          if (Object.op_Equality((Object) asset1, (Object) null) || !Localization.LoadCSV(asset1))
          {
            TextAsset asset2 = Resources.Load(value, typeof (TextAsset)) as TextAsset;
            if (Object.op_Inequality((Object) asset2, (Object) null))
            {
              Localization.Load(asset2);
              return;
            }
          }
        }
        if (Localization.mDictionary.Count != 0 && Localization.SelectLanguage(value))
          return;
        if (Object.op_Inequality((Object) Localization.mInstance, (Object) null) && Localization.mInstance.languages != null)
        {
          int index = 0;
          for (int length = Localization.mInstance.languages.Length; index < length; ++index)
          {
            TextAsset language = Localization.mInstance.languages[index];
            if (Object.op_Inequality((Object) language, (Object) null) && ((Object) language).name == value)
            {
              Localization.Load(language);
              return;
            }
          }
        }
      }
      Localization.mOldDictionary.Clear();
      PlayerPrefs.DeleteKey("Language");
    }
  }

  public static void Load(TextAsset asset)
  {
    ByteReader byteReader = new ByteReader(asset);
    Localization.Set(((Object) asset).name, byteReader.ReadDictionary());
  }

  public static bool LoadCSV(TextAsset asset)
  {
    ByteReader byteReader = new ByteReader(asset);
    BetterList<string> values = byteReader.ReadCSV();
    if (values.size < 2)
      return false;
    values[0] = "KEY";
    if (!string.Equals(values[0], "KEY"))
    {
      Debug.LogError((object) ("Invalid localization CSV file. The first value is expected to be 'KEY', followed by language columns.\nInstead found '" + values[0] + "'"), (Object) asset);
      return false;
    }
    Localization.knownLanguages = new string[values.size - 1];
    for (int index = 0; index < Localization.knownLanguages.Length; ++index)
      Localization.knownLanguages[index] = values[index + 1];
    Localization.mDictionary.Clear();
    for (; values != null; values = byteReader.ReadCSV())
      Localization.AddCSV(values);
    return true;
  }

  private static bool SelectLanguage(string language)
  {
    Localization.mLanguageIndex = -1;
    string[] strArray;
    if (Localization.mDictionary.Count == 0 || !Localization.mDictionary.TryGetValue("KEY", out strArray))
      return false;
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (strArray[index] == language)
      {
        Localization.mOldDictionary.Clear();
        Localization.mLanguageIndex = index;
        Localization.mLanguage = language;
        PlayerPrefs.SetString("Language", Localization.mLanguage);
        UIRoot.Broadcast("OnLocalize");
        return true;
      }
    }
    return false;
  }

  private static void AddCSV(BetterList<string> values)
  {
    if (values.size < 2)
      return;
    string[] strArray = new string[values.size - 1];
    for (int i = 1; i < values.size; ++i)
      strArray[i - 1] = values[i];
    Localization.mDictionary.Add(values[0], strArray);
  }

  public static void Set(string languageName, Dictionary<string, string> dictionary)
  {
    Localization.mLanguage = languageName;
    PlayerPrefs.SetString("Language", Localization.mLanguage);
    Localization.mOldDictionary = dictionary;
    Localization.localizationHasBeenSet = false;
    Localization.mLanguageIndex = -1;
    Localization.knownLanguages = new string[1]
    {
      languageName
    };
    UIRoot.Broadcast("OnLocalize");
  }

  public static string Get(string key)
  {
    if (!Localization.localizationHasBeenSet)
      Localization.language = PlayerPrefs.GetString("Language", "English");
    string key1 = key + " Mobile";
    string[] strArray;
    string str;
    if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key1, out strArray))
    {
      if (Localization.mLanguageIndex < strArray.Length)
        return strArray[Localization.mLanguageIndex];
    }
    else if (Localization.mOldDictionary.TryGetValue(key1, out str))
      return str;
    if (Localization.mLanguageIndex != -1 && Localization.mDictionary.TryGetValue(key, out strArray))
    {
      if (Localization.mLanguageIndex < strArray.Length)
        return strArray[Localization.mLanguageIndex];
    }
    else if (Localization.mOldDictionary.TryGetValue(key, out str))
      return str;
    return key;
  }

  [Obsolete("Use Localization.Get instead")]
  public static string Localize(string key) => Localization.Get(key);

  public static bool Exists(string key)
  {
    return Localization.mLanguageIndex != -1 ? Localization.mDictionary.ContainsKey(key) : Localization.mOldDictionary.ContainsKey(key);
  }
}
