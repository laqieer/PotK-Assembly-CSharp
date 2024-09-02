// Decompiled with JetBrains decompiler
// Type: I2.Loc.LocalizationManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using ArabicSupport;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
namespace I2.Loc
{
  public static class LocalizationManager
  {
    private static string mCurrentLanguage;
    private static string mLanguageCode;
    public static bool IsRight2Left = false;
    public static List<LanguageSource> Sources = new List<LanguageSource>();
    public static string[] GlobalSources = new string[1]
    {
      "I2Languages"
    };
    private static string[] LanguagesRTL = new string[20]
    {
      "ar-DZ",
      "ar",
      "ar-BH",
      "ar-EG",
      "ar-IQ",
      "ar-JO",
      "ar-KW",
      "ar-LB",
      "ar-LY",
      "ar-MA",
      "ar-OM",
      "ar-QA",
      "ar-SA",
      "ar-SY",
      "ar-TN",
      "ar-AE",
      "ar-YE",
      "he",
      "ur",
      "ji"
    };

    public static event LocalizationManager.OnLocalizeCallback OnLocalizeEvent;

    public static string CurrentLanguage
    {
      get
      {
        LocalizationManager.InitializeIfNeeded();
        return LocalizationManager.mCurrentLanguage;
      }
      set
      {
        string supportedLanguage = LocalizationManager.GetSupportedLanguage(value);
        if (string.IsNullOrEmpty(supportedLanguage) || !(LocalizationManager.mCurrentLanguage != supportedLanguage))
          return;
        LocalizationManager.SetLanguageAndCode(supportedLanguage, LocalizationManager.GetLanguageCode(supportedLanguage));
      }
    }

    public static string CurrentLanguageCode
    {
      get
      {
        LocalizationManager.InitializeIfNeeded();
        return LocalizationManager.mLanguageCode;
      }
      set
      {
        if (!(LocalizationManager.mLanguageCode != value))
          return;
        string languageFromCode = LocalizationManager.GetLanguageFromCode(value);
        if (string.IsNullOrEmpty(languageFromCode))
          return;
        LocalizationManager.SetLanguageAndCode(languageFromCode, value);
      }
    }

    public static string CurrentRegion
    {
      get
      {
        string currentLanguage = LocalizationManager.CurrentLanguage;
        int num1 = currentLanguage.IndexOfAny("/\\".ToCharArray());
        if (num1 > 0)
          return currentLanguage.Substring(num1 + 1);
        int num2 = currentLanguage.IndexOfAny("[(".ToCharArray());
        int num3 = currentLanguage.LastIndexOfAny("])".ToCharArray());
        return num2 > 0 && num2 != num3 ? currentLanguage.Substring(num2 + 1, num3 - num2 - 1) : string.Empty;
      }
      set
      {
        string str = LocalizationManager.CurrentLanguage;
        int num1 = str.IndexOfAny("/\\".ToCharArray());
        if (num1 > 0)
        {
          LocalizationManager.CurrentLanguage = str.Substring(num1 + 1) + value;
        }
        else
        {
          int startIndex = str.IndexOfAny("[(".ToCharArray());
          int num2 = str.LastIndexOfAny("])".ToCharArray());
          if (startIndex > 0 && startIndex != num2)
            str = str.Substring(startIndex);
          LocalizationManager.CurrentLanguage = str + "(" + value + ")";
        }
      }
    }

    public static string CurrentRegionCode
    {
      get
      {
        string currentLanguageCode = LocalizationManager.CurrentLanguageCode;
        int num = currentLanguageCode.IndexOfAny(" -_/\\".ToCharArray());
        return num < 0 ? string.Empty : currentLanguageCode.Substring(num + 1);
      }
      set
      {
        string str = LocalizationManager.CurrentLanguageCode;
        int length = str.IndexOfAny(" -_/\\".ToCharArray());
        if (length > 0)
          str = str.Substring(0, length);
        LocalizationManager.CurrentLanguageCode = str + "-" + value;
      }
    }

    private static void InitializeIfNeeded()
    {
      if (!string.IsNullOrEmpty(LocalizationManager.mCurrentLanguage))
        return;
      LocalizationManager.UpdateSources();
      LocalizationManager.SelectStartupLanguage();
    }

    public static void SetLanguageAndCode(
      string LanguageName,
      string LanguageCode,
      bool RememberLanguage = true,
      bool Force = false)
    {
      if (!(LocalizationManager.mCurrentLanguage != LanguageName) && !(LocalizationManager.mLanguageCode != LanguageCode) && !Force)
        return;
      if (RememberLanguage)
        PlayerPrefs.SetString("I2 Language", LanguageName);
      LocalizationManager.mCurrentLanguage = LanguageName;
      LocalizationManager.mLanguageCode = LanguageCode;
      LocalizationManager.IsRight2Left = LocalizationManager.IsRTL(LocalizationManager.mLanguageCode);
      LocalizationManager.LocalizeAll(Force);
    }

    private static void SelectStartupLanguage()
    {
      string Language1 = PlayerPrefs.GetString("I2 Language", string.Empty);
      string Language2 = ((Enum) (object) Application.systemLanguage).ToString();
      if (Language2 == "ChineseSimplified")
        Language2 = "Chinese (Simplified)";
      if (Language2 == "ChineseTraditional")
        Language2 = "Chinese (Traditional)";
      if (LocalizationManager.HasLanguage(Language1, Initialize: false))
      {
        LocalizationManager.CurrentLanguage = Language1;
      }
      else
      {
        string supportedLanguage = LocalizationManager.GetSupportedLanguage(Language2);
        if (!string.IsNullOrEmpty(supportedLanguage))
        {
          LocalizationManager.SetLanguageAndCode(supportedLanguage, LocalizationManager.GetLanguageCode(supportedLanguage), false);
        }
        else
        {
          int index = 0;
          for (int count = LocalizationManager.Sources.Count; index < count; ++index)
          {
            if (LocalizationManager.Sources[index].mLanguages.Count > 0)
            {
              LocalizationManager.SetLanguageAndCode(LocalizationManager.Sources[index].mLanguages[0].Name, LocalizationManager.Sources[index].mLanguages[0].Code, false);
              break;
            }
          }
        }
      }
    }

    public static string GetTermTranslation(string Term)
    {
      return LocalizationManager.GetTermTranslation(Term, false, 0);
    }

    public static string GetTermTranslation(string Term, bool FixForRTL)
    {
      return LocalizationManager.GetTermTranslation(Term, FixForRTL, 0);
    }

    public static string GetTermTranslation(string Term, bool FixForRTL, int maxLineLengthForRTL)
    {
      string Translation;
      return LocalizationManager.TryGetTermTranslation(Term, out Translation, FixForRTL, maxLineLengthForRTL) ? Translation : string.Empty;
    }

    public static bool TryGetTermTranslation(string Term, out string Translation)
    {
      return LocalizationManager.TryGetTermTranslation(Term, out Translation, false, 0);
    }

    public static bool TryGetTermTranslation(string Term, out string Translation, bool FixForRTL)
    {
      return LocalizationManager.TryGetTermTranslation(Term, out Translation, FixForRTL, 0);
    }

    public static bool TryGetTermTranslation(
      string Term,
      out string Translation,
      bool FixForRTL,
      int maxLineLengthForRTL)
    {
      Translation = string.Empty;
      if (string.IsNullOrEmpty(Term))
        return false;
      LocalizationManager.InitializeIfNeeded();
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        if (LocalizationManager.Sources[index].TryGetTermTranslation(Term, out Translation))
        {
          if (LocalizationManager.IsRight2Left && FixForRTL)
            Translation = LocalizationManager.ApplyRTLfix(Translation, maxLineLengthForRTL);
          return true;
        }
      }
      return false;
    }

    public static string ApplyRTLfix(string line) => LocalizationManager.ApplyRTLfix(line, 0);

    public static string ApplyRTLfix(string line, int maxCharacters)
    {
      if (maxCharacters <= 0)
        return ArabicFixer.Fix(line);
      line = new Regex(".{0," + (object) maxCharacters + "}(\\s+|$)", RegexOptions.Multiline).Replace(line, "$0\n");
      if (line.EndsWith("\n\n"))
        line = line.Substring(0, line.Length - 2);
      string[] strArray = line.Split('\n');
      int index = 0;
      for (int length = strArray.Length; index < length; ++index)
        strArray[index] = ArabicFixer.Fix(strArray[index]);
      line = string.Join("\n", strArray);
      return line;
    }

    public static string FixRTL_IfNeeded(string text, int maxCharacters = 0)
    {
      return LocalizationManager.IsRight2Left ? LocalizationManager.ApplyRTLfix(text, maxCharacters) : text;
    }

    internal static void LocalizeAll(bool Force = false)
    {
      Localize[] objectsOfTypeAll = (Localize[]) Resources.FindObjectsOfTypeAll(typeof (Localize));
      int index = 0;
      for (int length = objectsOfTypeAll.Length; index < length; ++index)
        objectsOfTypeAll[index].OnLocalize(Force);
      if (LocalizationManager.OnLocalizeEvent != null)
        LocalizationManager.OnLocalizeEvent();
      ResourceManager.pInstance.CleanResourceCache();
    }

    public static bool UpdateSources()
    {
      LocalizationManager.UnregisterDeletededSources();
      LocalizationManager.RegisterSourceInResources();
      LocalizationManager.RegisterSceneSources();
      return LocalizationManager.Sources.Count > 0;
    }

    private static void UnregisterDeletededSources()
    {
      for (int index = LocalizationManager.Sources.Count - 1; index >= 0; --index)
      {
        if (Object.op_Equality((Object) LocalizationManager.Sources[index], (Object) null))
          LocalizationManager.RemoveSource(LocalizationManager.Sources[index]);
      }
    }

    private static void RegisterSceneSources()
    {
      LanguageSource[] objectsOfTypeAll = (LanguageSource[]) Resources.FindObjectsOfTypeAll(typeof (LanguageSource));
      int index = 0;
      for (int length = objectsOfTypeAll.Length; index < length; ++index)
      {
        if (!LocalizationManager.Sources.Contains(objectsOfTypeAll[index]))
          LocalizationManager.AddSource(objectsOfTypeAll[index]);
      }
    }

    private static void RegisterSourceInResources()
    {
      foreach (string globalSource in LocalizationManager.GlobalSources)
      {
        GameObject asset = ResourceManager.pInstance.GetAsset<GameObject>(globalSource);
        LanguageSource component = !Object.op_Implicit((Object) asset) ? (LanguageSource) null : asset.GetComponent<LanguageSource>();
        if (Object.op_Implicit((Object) component) && !LocalizationManager.Sources.Contains(component))
          LocalizationManager.AddSource(component);
      }
    }

    internal static void AddSource(LanguageSource Source)
    {
      if (LocalizationManager.Sources.Contains(Source))
        return;
      LocalizationManager.Sources.Add(Source);
      Source.Import_Google_FromCache();
      if ((double) Source.GoogleUpdateDelay > 0.0)
        Source.Invoke("Delayed_Import_Google", Source.GoogleUpdateDelay);
      else
        Source.Import_Google();
      if (Source.mDictionary.Count != 0)
        return;
      Source.UpdateDictionary(true);
    }

    internal static void RemoveSource(LanguageSource Source)
    {
      LocalizationManager.Sources.Remove(Source);
    }

    public static bool IsGlobalSource(string SourceName)
    {
      return Array.IndexOf<string>(LocalizationManager.GlobalSources, SourceName) >= 0;
    }

    public static bool HasLanguage(string Language, bool AllowDiscartingRegion = true, bool Initialize = true)
    {
      if (Initialize)
        LocalizationManager.InitializeIfNeeded();
      int index1 = 0;
      for (int count = LocalizationManager.Sources.Count; index1 < count; ++index1)
      {
        if (LocalizationManager.Sources[index1].GetLanguageIndex(Language, false) >= 0)
          return true;
      }
      if (AllowDiscartingRegion)
      {
        int index2 = 0;
        for (int count = LocalizationManager.Sources.Count; index2 < count; ++index2)
        {
          if (LocalizationManager.Sources[index2].GetLanguageIndex(Language) >= 0)
            return true;
        }
      }
      return false;
    }

    public static string GetSupportedLanguage(string Language)
    {
      int index1 = 0;
      for (int count = LocalizationManager.Sources.Count; index1 < count; ++index1)
      {
        int languageIndex = LocalizationManager.Sources[index1].GetLanguageIndex(Language, false);
        if (languageIndex >= 0)
          return LocalizationManager.Sources[index1].mLanguages[languageIndex].Name;
      }
      int index2 = 0;
      for (int count = LocalizationManager.Sources.Count; index2 < count; ++index2)
      {
        int languageIndex = LocalizationManager.Sources[index2].GetLanguageIndex(Language);
        if (languageIndex >= 0)
          return LocalizationManager.Sources[index2].mLanguages[languageIndex].Name;
      }
      return string.Empty;
    }

    public static string GetLanguageCode(string Language)
    {
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        int languageIndex = LocalizationManager.Sources[index].GetLanguageIndex(Language);
        if (languageIndex >= 0)
          return LocalizationManager.Sources[index].mLanguages[languageIndex].Code;
      }
      return string.Empty;
    }

    public static string GetLanguageFromCode(string Code)
    {
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        int languageIndexFromCode = LocalizationManager.Sources[index].GetLanguageIndexFromCode(Code);
        if (languageIndexFromCode >= 0)
          return LocalizationManager.Sources[index].mLanguages[languageIndexFromCode].Name;
      }
      return string.Empty;
    }

    public static List<string> GetAllLanguages()
    {
      List<string> allLanguages = new List<string>();
      int index1 = 0;
      for (int count1 = LocalizationManager.Sources.Count; index1 < count1; ++index1)
      {
        int index2 = 0;
        for (int count2 = LocalizationManager.Sources[index1].mLanguages.Count; index2 < count2; ++index2)
        {
          if (!allLanguages.Contains(LocalizationManager.Sources[index1].mLanguages[index2].Name))
            allLanguages.Add(LocalizationManager.Sources[index1].mLanguages[index2].Name);
        }
      }
      return allLanguages;
    }

    public static List<string> GetCategories()
    {
      List<string> Categories = new List<string>();
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
        LocalizationManager.Sources[index].GetCategories(Categories: Categories);
      return Categories;
    }

    public static List<string> GetTermsList()
    {
      if (LocalizationManager.Sources.Count == 0)
        LocalizationManager.UpdateSources();
      if (LocalizationManager.Sources.Count == 1)
        return LocalizationManager.Sources[0].GetTermsList();
      HashSet<string> collection = new HashSet<string>();
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
        collection.UnionWith((IEnumerable<string>) LocalizationManager.Sources[index].GetTermsList());
      return new List<string>((IEnumerable<string>) collection);
    }

    public static TermData GetTermData(string term)
    {
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        TermData termData = LocalizationManager.Sources[index].GetTermData(term);
        if (termData != null)
          return termData;
      }
      return (TermData) null;
    }

    public static LanguageSource GetSourceContaining(string term, bool fallbackToFirst = true)
    {
      if (!string.IsNullOrEmpty(term))
      {
        int index = 0;
        for (int count = LocalizationManager.Sources.Count; index < count; ++index)
        {
          if (LocalizationManager.Sources[index].GetTermData(term) != null)
            return LocalizationManager.Sources[index];
        }
      }
      return fallbackToFirst && LocalizationManager.Sources.Count > 0 ? LocalizationManager.Sources[0] : (LanguageSource) null;
    }

    public static Object FindAsset(string value)
    {
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        Object asset = LocalizationManager.Sources[index].FindAsset(value);
        if (Object.op_Implicit(asset))
          return asset;
      }
      return (Object) null;
    }

    public static string GetVersion() => "2.6.6 b1";

    public static int GetRequiredWebServiceVersion() => 4;

    private static bool IsRTL(string Code)
    {
      return Array.IndexOf<string>(LocalizationManager.LanguagesRTL, Code) >= 0;
    }

    public delegate void OnLocalizeCallback();
  }
}
