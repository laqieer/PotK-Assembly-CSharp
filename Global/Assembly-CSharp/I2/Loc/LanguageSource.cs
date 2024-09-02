// Decompiled with JetBrains decompiler
// Type: I2.Loc.LanguageSource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
namespace I2.Loc
{
  [AddComponentMenu("I2/Localization/Source")]
  public class LanguageSource : MonoBehaviour
  {
    public string Google_WebServiceURL;
    public string Google_SpreadsheetKey;
    public string Google_SpreadsheetName;
    public string Google_LastUpdatedVersion;
    public LanguageSource.eGoogleUpdateFrequency GoogleUpdateFrequency = LanguageSource.eGoogleUpdateFrequency.Weekly;
    public float GoogleUpdateDelay = 5f;
    public static string EmptyCategory = "Default";
    public static char[] CategorySeparators = "/\\".ToCharArray();
    public List<TermData> mTerms = new List<TermData>();
    public List<LanguageData> mLanguages = new List<LanguageData>();
    public bool CaseInsensitiveTerms;
    [NonSerialized]
    public Dictionary<string, TermData> mDictionary = new Dictionary<string, TermData>((IEqualityComparer<string>) StringComparer.Ordinal);
    public Object[] Assets;
    public bool NeverDestroy = true;
    public bool UserAgreesToHaveItOnTheScene;
    public bool UserAgreesToHaveItInsideThePluginsFolder;

    public event Action<LanguageSource> Event_OnSourceUpdateFromGoogle;

    public string Export_I2CSV(string Category, char Separator = ',')
    {
      StringBuilder Builder = new StringBuilder();
      Builder.Append("Key[*]Type[*]Desc");
      foreach (LanguageData mLanguage in this.mLanguages)
      {
        Builder.Append("[*]");
        Builder.Append(GoogleLanguages.GetCodedLanguage(mLanguage.Name, mLanguage.Code));
      }
      Builder.Append("[ln]");
      int count = this.mLanguages.Count;
      foreach (TermData mTerm in this.mTerms)
      {
        string Term;
        if (string.IsNullOrEmpty(Category) || Category == LanguageSource.EmptyCategory && mTerm.Term.IndexOfAny(LanguageSource.CategorySeparators) < 0)
          Term = mTerm.Term;
        else if (mTerm.Term.StartsWith(Category + "/") && Category != mTerm.Term)
          Term = mTerm.Term.Substring(Category.Length + 1);
        else
          continue;
        LanguageSource.AppendI2Term(Builder, count, Term, mTerm, string.Empty, mTerm.Languages, mTerm.Languages_Touch, Separator, (byte) 1, (byte) 2);
        if (mTerm.HasTouchTranslations())
          LanguageSource.AppendI2Term(Builder, count, Term, mTerm, "[touch]", mTerm.Languages_Touch, (string[]) null, Separator, (byte) 2, (byte) 1);
      }
      return Builder.ToString();
    }

    private static void AppendI2Term(
      StringBuilder Builder,
      int nLanguages,
      string Term,
      TermData termData,
      string postfix,
      string[] aLanguages,
      string[] aSecLanguages,
      char Separator,
      byte FlagBitMask,
      byte SecFlagBitMask)
    {
      Builder.Append(Term);
      Builder.Append(postfix);
      Builder.Append("[*]");
      Builder.Append(termData.TermType.ToString());
      Builder.Append("[*]");
      Builder.Append(termData.Description);
      for (int index = 0; index < Mathf.Min(nLanguages, aLanguages.Length); ++index)
      {
        Builder.Append("[*]");
        string str = aLanguages[index];
        bool flag = ((int) termData.Flags[index] & (int) FlagBitMask) > 0;
        if (string.IsNullOrEmpty(str) && aSecLanguages != null)
        {
          str = aSecLanguages[index];
          flag = ((int) termData.Flags[index] & (int) SecFlagBitMask) > 0;
        }
        if (flag)
          Builder.Append("[i2auto]");
        Builder.Append(str);
      }
      Builder.Append("[ln]");
    }

    public string Export_CSV(string Category, char Separator = ',')
    {
      StringBuilder Builder = new StringBuilder();
      int count = this.mLanguages.Count;
      Builder.AppendFormat("Key{0}Type{0}Desc", (object) Separator);
      foreach (LanguageData mLanguage in this.mLanguages)
      {
        Builder.Append(Separator);
        LanguageSource.AppendString(Builder, GoogleLanguages.GetCodedLanguage(mLanguage.Name, mLanguage.Code), Separator);
      }
      Builder.Append("\n");
      this.mTerms = this.mTerms.OrderBy<TermData, string>((Func<TermData, string>) (x => x.Term)).ToList<TermData>();
      foreach (TermData mTerm in this.mTerms)
      {
        string Term;
        if (string.IsNullOrEmpty(Category) || Category == LanguageSource.EmptyCategory && mTerm.Term.IndexOfAny(LanguageSource.CategorySeparators) < 0)
          Term = mTerm.Term;
        else if (mTerm.Term.StartsWith(Category + "/") && Category != mTerm.Term)
          Term = mTerm.Term.Substring(Category.Length + 1);
        else
          continue;
        LanguageSource.AppendTerm(Builder, count, Term, mTerm, (string) null, mTerm.Languages, mTerm.Languages_Touch, Separator, (byte) 1, (byte) 2);
        if (mTerm.HasTouchTranslations())
          LanguageSource.AppendTerm(Builder, count, Term, mTerm, "[touch]", mTerm.Languages_Touch, (string[]) null, Separator, (byte) 2, (byte) 1);
      }
      return Builder.ToString();
    }

    private static void AppendTerm(
      StringBuilder Builder,
      int nLanguages,
      string Term,
      TermData termData,
      string prefix,
      string[] aLanguages,
      string[] aSecLanguages,
      char Separator,
      byte FlagBitMask,
      byte SecFlagBitMask)
    {
      LanguageSource.AppendString(Builder, Term, Separator);
      if (!string.IsNullOrEmpty(prefix))
        Builder.Append(prefix);
      Builder.Append(Separator);
      Builder.Append(termData.TermType.ToString());
      Builder.Append(Separator);
      LanguageSource.AppendString(Builder, termData.Description, Separator);
      for (int index = 0; index < Mathf.Min(nLanguages, aLanguages.Length); ++index)
      {
        Builder.Append(Separator);
        string Text = aLanguages[index];
        bool flag = ((int) termData.Flags[index] & (int) FlagBitMask) > 0;
        if (string.IsNullOrEmpty(Text) && aSecLanguages != null)
        {
          Text = aSecLanguages[index];
          flag = ((int) termData.Flags[index] & (int) SecFlagBitMask) > 0;
        }
        if (flag)
          Builder.Append("[i2auto]");
        LanguageSource.AppendString(Builder, Text, Separator);
      }
      Builder.Append("\n");
    }

    private static void AppendString(StringBuilder Builder, string Text, char Separator)
    {
      if (string.IsNullOrEmpty(Text))
        return;
      Text = Text.Replace("\\n", "\n");
      if (Text.IndexOfAny((Separator.ToString() + "\n\"").ToCharArray()) >= 0)
      {
        Text = Text.Replace("\"", "\"\"");
        Builder.AppendFormat("\"{0}\"", (object) Text);
      }
      else
        Builder.Append(Text);
    }

    public WWW Export_Google_CreateWWWcall(eSpreadsheetUpdateMode UpdateMode = eSpreadsheetUpdateMode.Replace)
    {
      string data = this.Export_Google_CreateData();
      WWWForm wwwForm = new WWWForm();
      wwwForm.AddField("key", this.Google_SpreadsheetKey);
      wwwForm.AddField("action", "SetLanguageSource");
      wwwForm.AddField("data", data);
      wwwForm.AddField("updateMode", UpdateMode.ToString());
      return new WWW(this.Google_WebServiceURL, wwwForm);
    }

    private string Export_Google_CreateData()
    {
      List<string> categories = this.GetCategories(true);
      StringBuilder stringBuilder = new StringBuilder();
      bool flag = true;
      foreach (string Category in categories)
      {
        if (flag)
          flag = false;
        else
          stringBuilder.Append("<I2Loc>");
        string str = this.Export_I2CSV(Category);
        stringBuilder.Append(Category);
        stringBuilder.Append("<I2Loc>");
        stringBuilder.Append(str);
      }
      return stringBuilder.ToString();
    }

    public string Import_CSV(
      string Category,
      string CSVstring,
      eSpreadsheetUpdateMode UpdateMode = eSpreadsheetUpdateMode.Replace,
      char Separator = ',')
    {
      List<string[]> CSV = LocalizationReader.ReadCSV(CSVstring, Separator);
      return this.Import_CSV(Category, CSV, UpdateMode);
    }

    public string Import_I2CSV(
      string Category,
      string I2CSVstring,
      eSpreadsheetUpdateMode UpdateMode = eSpreadsheetUpdateMode.Replace)
    {
      List<string[]> CSV = LocalizationReader.ReadI2CSV(I2CSVstring);
      return this.Import_CSV(Category, CSV, UpdateMode);
    }

    public string Import_CSV(
      string Category,
      List<string[]> CSV,
      eSpreadsheetUpdateMode UpdateMode = eSpreadsheetUpdateMode.Replace)
    {
      string[] strArray1 = CSV[0];
      int num1 = 1;
      int index1 = -1;
      int index2 = -1;
      string[] strArray2 = new string[1]{ "Key" };
      string[] strArray3 = new string[1]{ "Type" };
      string[] strArray4 = new string[2]
      {
        "Desc",
        "Description"
      };
      if (strArray1.Length <= 1 || !this.ArrayContains(strArray1[0], strArray2))
        return "Bad Spreadsheet Format.\nFirst columns should be 'Key', 'Type' and 'Desc'";
      if (UpdateMode == eSpreadsheetUpdateMode.Replace)
        this.ClearAllData();
      if (strArray1.Length > 2)
      {
        if (this.ArrayContains(strArray1[1], strArray3))
        {
          index1 = 1;
          num1 = 2;
        }
        if (this.ArrayContains(strArray1[1], strArray4))
        {
          index2 = 1;
          num1 = 2;
        }
      }
      if (strArray1.Length > 3)
      {
        if (this.ArrayContains(strArray1[2], strArray3))
        {
          index1 = 2;
          num1 = 3;
        }
        if (this.ArrayContains(strArray1[2], strArray4))
        {
          index2 = 2;
          num1 = 3;
        }
      }
      int length = Mathf.Max(strArray1.Length - num1, 0);
      int[] numArray = new int[length];
      for (int index3 = 0; index3 < length; ++index3)
      {
        if (string.IsNullOrEmpty(strArray1[index3 + num1]))
        {
          numArray[index3] = -1;
        }
        else
        {
          string Language;
          string code;
          GoogleLanguages.UnPackCodeFromLanguageName(strArray1[index3 + num1], out Language, out code);
          int num2 = string.IsNullOrEmpty(code) ? this.GetLanguageIndex(Language) : this.GetLanguageIndexFromCode(code);
          if (num2 < 0)
          {
            this.mLanguages.Add(new LanguageData()
            {
              Name = Language,
              Code = code
            });
            num2 = this.mLanguages.Count - 1;
          }
          numArray[index3] = num2;
        }
      }
      int count1 = this.mLanguages.Count;
      int index4 = 0;
      for (int count2 = this.mTerms.Count; index4 < count2; ++index4)
      {
        TermData mTerm = this.mTerms[index4];
        if (mTerm.Languages.Length < count1)
        {
          Array.Resize<string>(ref mTerm.Languages, count1);
          Array.Resize<string>(ref mTerm.Languages_Touch, count1);
          Array.Resize<byte>(ref mTerm.Flags, count1);
        }
      }
      int index5 = 1;
      for (int count3 = CSV.Count; index5 < count3; ++index5)
      {
        string[] strArray5 = CSV[index5];
        string Term = !string.IsNullOrEmpty(Category) ? Category + "/" + strArray5[0] : strArray5[0];
        bool flag1 = false;
        if (Term.EndsWith("[touch]"))
        {
          Term = Term.Remove(Term.Length - "[touch]".Length);
          flag1 = true;
        }
        LanguageSource.ValidateFullTerm(ref Term);
        if (!string.IsNullOrEmpty(Term))
        {
          TermData termData = this.GetTermData(Term);
          if (termData == null)
          {
            termData = new TermData();
            termData.Term = Term;
            termData.Languages = new string[this.mLanguages.Count];
            termData.Languages_Touch = new string[this.mLanguages.Count];
            termData.Flags = new byte[this.mLanguages.Count];
            for (int index6 = 0; index6 < this.mLanguages.Count; ++index6)
              termData.Languages[index6] = termData.Languages_Touch[index6] = string.Empty;
            this.mTerms.Add(termData);
            this.mDictionary.Add(Term, termData);
          }
          else if (UpdateMode == eSpreadsheetUpdateMode.AddNewTerms)
            continue;
          if (index1 > 0)
            termData.TermType = LanguageSource.GetTermType(strArray5[index1]);
          if (index2 > 0)
            termData.Description = strArray5[index2];
          for (int index7 = 0; index7 < numArray.Length && index7 < strArray5.Length - num1; ++index7)
          {
            if (!string.IsNullOrEmpty(strArray5[index7 + num1]))
            {
              int index8 = numArray[index7];
              if (index8 >= 0)
              {
                string str = strArray5[index7 + num1];
                bool flag2 = str.StartsWith("[i2auto]");
                if (flag2)
                {
                  str = str.Substring("[isauto]".Length);
                  if (str.StartsWith("\"") && str.EndsWith("\""))
                    str = str.Substring(1, str.Length - 2);
                }
                if (flag1)
                {
                  termData.Languages_Touch[index8] = str;
                  if (flag2)
                    termData.Flags[index8] |= (byte) 2;
                  else
                    termData.Flags[index8] &= (byte) 253;
                }
                else
                {
                  termData.Languages[index8] = str;
                  if (flag2)
                    termData.Flags[index8] |= (byte) 1;
                  else
                    termData.Flags[index8] &= (byte) 254;
                }
              }
            }
          }
        }
      }
      return string.Empty;
    }

    private bool ArrayContains(string MainText, params string[] texts)
    {
      int index = 0;
      for (int length = texts.Length; index < length; ++index)
      {
        if (MainText.IndexOf(texts[index], StringComparison.OrdinalIgnoreCase) >= 0)
          return true;
      }
      return false;
    }

    public static eTermType GetTermType(string type)
    {
      int termType = 0;
      for (int index = 7; termType <= index; ++termType)
      {
        if (string.Equals(((eTermType) termType).ToString(), type, StringComparison.OrdinalIgnoreCase))
          return (eTermType) termType;
      }
      return eTermType.Text;
    }

    public void Delayed_Import_Google() => this.Import_Google();

    public void Import_Google_FromCache()
    {
      if (!Application.isPlaying)
        return;
      string sourcePlayerPrefName = this.GetSourcePlayerPrefName();
      string JsonString = PlayerPrefs.GetString("I2Source_" + sourcePlayerPrefName, (string) null);
      if (string.IsNullOrEmpty(JsonString))
        return;
      bool flag = false;
      string lastUpdatedVersion = this.Google_LastUpdatedVersion;
      if (PlayerPrefs.HasKey("I2SourceVersion_" + sourcePlayerPrefName))
      {
        lastUpdatedVersion = PlayerPrefs.GetString("I2SourceVersion_" + sourcePlayerPrefName, this.Google_LastUpdatedVersion);
        flag = lastUpdatedVersion.CompareTo(this.Google_LastUpdatedVersion) > 0;
      }
      if (!flag)
      {
        PlayerPrefs.DeleteKey("I2Source_" + sourcePlayerPrefName);
        PlayerPrefs.DeleteKey("I2SourceVersion_" + sourcePlayerPrefName);
      }
      else
      {
        this.Google_LastUpdatedVersion = lastUpdatedVersion;
        Debug.Log((object) ("[I2Loc] Using Saved (PlayerPref) data in 'I2Source_" + sourcePlayerPrefName + "'"));
        this.Import_Google_Result(JsonString, eSpreadsheetUpdateMode.Replace);
      }
    }

    public void Import_Google(bool ForceUpdate = false)
    {
      if (this.GoogleUpdateFrequency == LanguageSource.eGoogleUpdateFrequency.Never)
        return;
      string sourcePlayerPrefName = this.GetSourcePlayerPrefName();
      DateTime result;
      if (!ForceUpdate && this.GoogleUpdateFrequency != LanguageSource.eGoogleUpdateFrequency.Always && DateTime.TryParse(PlayerPrefs.GetString("LastGoogleUpdate_" + sourcePlayerPrefName, string.Empty), out result))
      {
        double totalDays = (DateTime.Now - result).TotalDays;
        switch (this.GoogleUpdateFrequency)
        {
          case LanguageSource.eGoogleUpdateFrequency.Daily:
            if (totalDays < 1.0)
              return;
            break;
          case LanguageSource.eGoogleUpdateFrequency.Weekly:
            if (totalDays < 8.0)
              return;
            break;
          case LanguageSource.eGoogleUpdateFrequency.Monthly:
            if (totalDays < 31.0)
              return;
            break;
        }
      }
      PlayerPrefs.SetString("LastGoogleUpdate_" + sourcePlayerPrefName, DateTime.Now.ToString());
      CoroutineManager.pInstance.StartCoroutine(this.Import_Google_Coroutine());
    }

    private string GetSourcePlayerPrefName()
    {
      if (Array.IndexOf<string>(LocalizationManager.GlobalSources, ((Object) this).name) >= 0)
        return ((Object) this).name;
      Scene activeScene = SceneManager.GetActiveScene();
      return ((Scene) ref activeScene).name + "_" + ((Object) this).name;
    }

    [DebuggerHidden]
    private IEnumerator Import_Google_Coroutine()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new LanguageSource.\u003CImport_Google_Coroutine\u003Ec__Iterator113()
      {
        \u003C\u003Ef__this = this
      };
    }

    public WWW Import_Google_CreateWWWcall(bool ForceUpdate = false)
    {
      if (!this.HasGoogleSpreadsheet())
        return (WWW) null;
      string str = PlayerPrefs.GetString("I2SourceVersion_" + this.GetSourcePlayerPrefName(), this.Google_LastUpdatedVersion);
      if (str.CompareTo(this.Google_LastUpdatedVersion) > 0)
        this.Google_LastUpdatedVersion = str;
      return new WWW(string.Format("{0}?key={1}&action=GetLanguageSource&version={2}", (object) this.Google_WebServiceURL, (object) this.Google_SpreadsheetKey, !ForceUpdate ? (object) this.Google_LastUpdatedVersion : (object) "0"));
    }

    public bool HasGoogleSpreadsheet()
    {
      return !string.IsNullOrEmpty(this.Google_WebServiceURL) && !string.IsNullOrEmpty(this.Google_SpreadsheetKey);
    }

    public string Import_Google_Result(
      string JsonString,
      eSpreadsheetUpdateMode UpdateMode,
      bool saveInPlayerPrefs = false)
    {
      string empty = string.Empty;
      if (string.IsNullOrEmpty(JsonString) || JsonString == "\"\"")
        return empty;
      int num1 = JsonString.IndexOf("version=");
      int num2 = JsonString.IndexOf("script_version=");
      if (num1 < 0 || num2 < 0)
        return "Invalid Response from Google, Most likely the WebService needs to be updated";
      int startIndex1 = num1 + "version=".Length;
      int startIndex2 = num2 + "script_version=".Length;
      string str = JsonString.Substring(startIndex1, JsonString.IndexOf(",", startIndex1) - startIndex1);
      if (int.Parse(JsonString.Substring(startIndex2, JsonString.IndexOf(",", startIndex2) - startIndex2)) != LocalizationManager.GetRequiredWebServiceVersion())
        return "The current Google WebService is not supported.\nPlease, delete the WebService from the Google Drive and Install the latest version.";
      if (!saveInPlayerPrefs && str.CompareTo(this.Google_LastUpdatedVersion) <= 0)
        return "LanguageSource is up-to-date";
      if (saveInPlayerPrefs)
      {
        string sourcePlayerPrefName = this.GetSourcePlayerPrefName();
        PlayerPrefs.SetString("I2Source_" + sourcePlayerPrefName, JsonString);
        PlayerPrefs.SetString("I2SourceVersion_" + sourcePlayerPrefName, str);
        PlayerPrefs.Save();
      }
      this.Google_LastUpdatedVersion = str;
      if (UpdateMode == eSpreadsheetUpdateMode.Replace)
        this.ClearAllData();
      int num3 = JsonString.IndexOf("[i2category]");
      while (num3 > 0)
      {
        int startIndex3 = num3 + "[i2category]".Length;
        int num4 = JsonString.IndexOf("[/i2category]", startIndex3);
        string Category = JsonString.Substring(startIndex3, num4 - startIndex3);
        int startIndex4 = num4 + "[/i2category]".Length;
        int startIndex5 = JsonString.IndexOf("[/i2csv]", startIndex4);
        string I2CSVstring = JsonString.Substring(startIndex4, startIndex5 - startIndex4);
        num3 = JsonString.IndexOf("[i2category]", startIndex5);
        this.Import_I2CSV(Category, I2CSVstring, UpdateMode);
        if (UpdateMode == eSpreadsheetUpdateMode.Replace)
          UpdateMode = eSpreadsheetUpdateMode.Merge;
      }
      return empty;
    }

    public List<string> GetCategories(bool OnlyMainCategory = false, List<string> Categories = null)
    {
      if (Categories == null)
        Categories = new List<string>();
      foreach (TermData mTerm in this.mTerms)
      {
        string categoryFromFullTerm = LanguageSource.GetCategoryFromFullTerm(mTerm.Term, OnlyMainCategory);
        if (!Categories.Contains(categoryFromFullTerm))
          Categories.Add(categoryFromFullTerm);
      }
      Categories.Sort();
      return Categories;
    }

    public static string GetKeyFromFullTerm(string FullTerm, bool OnlyMainCategory = false)
    {
      int num = !OnlyMainCategory ? FullTerm.LastIndexOfAny(LanguageSource.CategorySeparators) : FullTerm.IndexOfAny(LanguageSource.CategorySeparators);
      return num < 0 ? FullTerm : FullTerm.Substring(num + 1);
    }

    public static string GetCategoryFromFullTerm(string FullTerm, bool OnlyMainCategory = false)
    {
      int length = !OnlyMainCategory ? FullTerm.LastIndexOfAny(LanguageSource.CategorySeparators) : FullTerm.IndexOfAny(LanguageSource.CategorySeparators);
      return length < 0 ? LanguageSource.EmptyCategory : FullTerm.Substring(0, length);
    }

    public static void DeserializeFullTerm(
      string FullTerm,
      out string Key,
      out string Category,
      bool OnlyMainCategory = false)
    {
      int length = !OnlyMainCategory ? FullTerm.LastIndexOfAny(LanguageSource.CategorySeparators) : FullTerm.IndexOfAny(LanguageSource.CategorySeparators);
      if (length < 0)
      {
        Category = LanguageSource.EmptyCategory;
        Key = FullTerm;
      }
      else
      {
        Category = FullTerm.Substring(0, length);
        Key = FullTerm.Substring(length + 1);
      }
    }

    public static LanguageSource.eInputSpecialization GetCurrentInputType()
    {
      return LanguageSource.eInputSpecialization.Touch;
    }

    private void Awake()
    {
      if (this.NeverDestroy)
      {
        if (this.ManagerHasASimilarSource())
        {
          Object.Destroy((Object) this);
          return;
        }
        if (Application.isPlaying)
          Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
      }
      LocalizationManager.AddSource(this);
      this.UpdateDictionary();
    }

    public void UpdateDictionary(bool force = false)
    {
      if (!force && this.mDictionary != null && this.mDictionary.Count == this.mTerms.Count)
        return;
      StringComparer comparer = !this.CaseInsensitiveTerms ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
      if (this.mDictionary.Comparer != comparer)
        this.mDictionary = new Dictionary<string, TermData>((IEqualityComparer<string>) comparer);
      else
        this.mDictionary.Clear();
      int index = 0;
      for (int count = this.mTerms.Count; index < count; ++index)
      {
        LanguageSource.ValidateFullTerm(ref this.mTerms[index].Term);
        if (this.mTerms[index].Languages_Touch == null || this.mTerms[index].Languages_Touch.Length != this.mTerms[index].Languages.Length)
          this.mTerms[index].Languages_Touch = new string[this.mTerms[index].Languages.Length];
        this.mDictionary[this.mTerms[index].Term] = this.mTerms[index];
        this.mTerms[index].Validate();
      }
    }

    public string GetSourceName()
    {
      string sourceName = ((Object) ((Component) this).gameObject).name;
      for (Transform parent = ((Component) this).transform.parent; Object.op_Implicit((Object) parent); parent = parent.parent)
        sourceName = ((Object) parent).name + "_" + sourceName;
      return sourceName;
    }

    public int GetLanguageIndex(string language, bool AllowDiscartingRegion = true)
    {
      int index1 = 0;
      for (int count = this.mLanguages.Count; index1 < count; ++index1)
      {
        if (string.Compare(this.mLanguages[index1].Name, language, StringComparison.OrdinalIgnoreCase) == 0)
          return index1;
      }
      if (AllowDiscartingRegion)
      {
        int languageIndex = -1;
        int num = 0;
        int index2 = 0;
        for (int count = this.mLanguages.Count; index2 < count; ++index2)
        {
          int wordInLanguageNames = LanguageSource.GetCommonWordInLanguageNames(this.mLanguages[index2].Name, language);
          if (wordInLanguageNames > num)
          {
            num = wordInLanguageNames;
            languageIndex = index2;
          }
        }
        if (languageIndex >= 0)
          return languageIndex;
      }
      return -1;
    }

    public int GetLanguageIndexFromCode(string Code)
    {
      int index = 0;
      for (int count = this.mLanguages.Count; index < count; ++index)
      {
        if (string.Compare(this.mLanguages[index].Code, Code, StringComparison.OrdinalIgnoreCase) == 0)
          return index;
      }
      return -1;
    }

    public static int GetCommonWordInLanguageNames(string Language1, string Language2)
    {
      if (string.IsNullOrEmpty(Language1) || string.IsNullOrEmpty(Language2))
        return 0;
      string[] array1 = ((IEnumerable<string>) Language1.Split("( )-/\\".ToCharArray())).Where<string>((Func<string, bool>) (x => !string.IsNullOrEmpty(x))).ToArray<string>();
      string[] array2 = ((IEnumerable<string>) Language2.Split("( )-/\\".ToCharArray())).Where<string>((Func<string, bool>) (x => !string.IsNullOrEmpty(x))).ToArray<string>();
      int wordInLanguageNames = 0;
      foreach (string str in array1)
      {
        if (((IEnumerable<string>) array2).Contains<string>(str))
          ++wordInLanguageNames;
      }
      foreach (string str in array2)
      {
        if (((IEnumerable<string>) array1).Contains<string>(str))
          ++wordInLanguageNames;
      }
      return wordInLanguageNames;
    }

    public static bool AreTheSameLanguage(string Language1, string Language2)
    {
      Language1 = LanguageSource.GetLanguageWithoutRegion(Language1);
      Language2 = LanguageSource.GetLanguageWithoutRegion(Language2);
      return string.Compare(Language1, Language2, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static string GetLanguageWithoutRegion(string Language)
    {
      int length = Language.IndexOfAny("(/\\[,{".ToCharArray());
      return length < 0 ? Language : Language.Substring(0, length).Trim();
    }

    public void AddLanguage(string LanguageName, string LanguageCode)
    {
      if (this.GetLanguageIndex(LanguageName, false) >= 0)
        return;
      this.mLanguages.Add(new LanguageData()
      {
        Name = LanguageName,
        Code = LanguageCode
      });
      int count1 = this.mLanguages.Count;
      int index = 0;
      for (int count2 = this.mTerms.Count; index < count2; ++index)
      {
        Array.Resize<string>(ref this.mTerms[index].Languages, count1);
        Array.Resize<string>(ref this.mTerms[index].Languages_Touch, count1);
        Array.Resize<byte>(ref this.mTerms[index].Flags, count1);
      }
    }

    public void RemoveLanguage(string LanguageName)
    {
      int languageIndex = this.GetLanguageIndex(LanguageName);
      if (languageIndex < 0)
        return;
      int count1 = this.mLanguages.Count;
      int index1 = 0;
      for (int count2 = this.mTerms.Count; index1 < count2; ++index1)
      {
        for (int index2 = languageIndex + 1; index2 < count1; ++index2)
        {
          this.mTerms[index1].Languages[index2 - 1] = this.mTerms[index1].Languages[index2];
          this.mTerms[index1].Languages_Touch[index2 - 1] = this.mTerms[index1].Languages_Touch[index2];
          this.mTerms[index1].Flags[index2 - 1] = this.mTerms[index1].Flags[index2];
        }
        Array.Resize<string>(ref this.mTerms[index1].Languages, count1 - 1);
        Array.Resize<string>(ref this.mTerms[index1].Languages_Touch, count1 - 1);
        Array.Resize<byte>(ref this.mTerms[index1].Flags, count1 - 1);
      }
      this.mLanguages.RemoveAt(languageIndex);
    }

    public List<string> GetLanguages()
    {
      List<string> languages = new List<string>();
      int index = 0;
      for (int count = this.mLanguages.Count; index < count; ++index)
        languages.Add(this.mLanguages[index].Name);
      return languages;
    }

    public string GetTermTranslation(string term)
    {
      int languageIndex = this.GetLanguageIndex(LocalizationManager.CurrentLanguage);
      if (languageIndex < 0)
        return string.Empty;
      TermData termData = this.GetTermData(term);
      return termData != null ? termData.GetTranslation(languageIndex) : string.Empty;
    }

    public bool TryGetTermTranslation(string term, out string Translation)
    {
      int languageIndex = this.GetLanguageIndex(LocalizationManager.CurrentLanguage);
      if (languageIndex >= 0)
      {
        TermData termData = this.GetTermData(term);
        if (termData != null)
        {
          Translation = termData.GetTranslation(languageIndex);
          return true;
        }
      }
      Translation = string.Empty;
      return false;
    }

    public TermData AddTerm(string term) => this.AddTerm(term, eTermType.Text);

    public TermData GetTermData(string term, bool allowCategoryMistmatch = false)
    {
      if (string.IsNullOrEmpty(term))
        return (TermData) null;
      if (this.mDictionary.Count == 0)
        this.UpdateDictionary();
      TermData termData1;
      if (this.mDictionary.TryGetValue(term, out termData1))
        return termData1;
      TermData termData2 = (TermData) null;
      if (allowCategoryMistmatch)
      {
        string keyFromFullTerm = LanguageSource.GetKeyFromFullTerm(term);
        foreach (KeyValuePair<string, TermData> m in this.mDictionary)
        {
          if (m.Value.IsTerm(keyFromFullTerm, true))
          {
            if (termData2 != null)
              return (TermData) null;
            termData2 = m.Value;
          }
        }
      }
      return termData2;
    }

    public bool ContainsTerm(string term) => this.GetTermData(term) != null;

    public List<string> GetTermsList()
    {
      if (this.mDictionary.Count != this.mTerms.Count)
        this.UpdateDictionary();
      return new List<string>((IEnumerable<string>) this.mDictionary.Keys);
    }

    public TermData AddTerm(string NewTerm, eTermType termType, bool SaveSource = true)
    {
      LanguageSource.ValidateFullTerm(ref NewTerm);
      NewTerm = NewTerm.Trim();
      if (this.mLanguages.Count == 0)
        this.AddLanguage("English", "en");
      TermData termData = this.GetTermData(NewTerm);
      if (termData == null)
      {
        termData = new TermData();
        termData.Term = NewTerm;
        termData.TermType = termType;
        termData.Languages = new string[this.mLanguages.Count];
        termData.Languages_Touch = new string[this.mLanguages.Count];
        termData.Flags = new byte[this.mLanguages.Count];
        this.mTerms.Add(termData);
        this.mDictionary.Add(NewTerm, termData);
      }
      return termData;
    }

    public void RemoveTerm(string term)
    {
      int index = 0;
      for (int count = this.mTerms.Count; index < count; ++index)
      {
        if (this.mTerms[index].Term == term)
        {
          this.mTerms.RemoveAt(index);
          this.mDictionary.Remove(term);
          break;
        }
      }
    }

    public static void ValidateFullTerm(ref string Term)
    {
      Term = Term.Replace('\\', '/');
      Term = Term.Trim();
      if (!Term.StartsWith(LanguageSource.EmptyCategory) || Term.Length <= LanguageSource.EmptyCategory.Length || Term[LanguageSource.EmptyCategory.Length] != '/')
        return;
      Term = Term.Substring(LanguageSource.EmptyCategory.Length + 1);
    }

    public bool IsEqualTo(LanguageSource Source)
    {
      if (Source.mLanguages.Count != this.mLanguages.Count)
        return false;
      int index1 = 0;
      for (int count = this.mLanguages.Count; index1 < count; ++index1)
      {
        if (Source.GetLanguageIndex(this.mLanguages[index1].Name) < 0)
          return false;
      }
      if (Source.mTerms.Count != this.mTerms.Count)
        return false;
      for (int index2 = 0; index2 < this.mTerms.Count; ++index2)
      {
        if (Source.GetTermData(this.mTerms[index2].Term) == null)
          return false;
      }
      return true;
    }

    internal bool ManagerHasASimilarSource()
    {
      int index = 0;
      for (int count = LocalizationManager.Sources.Count; index < count; ++index)
      {
        LanguageSource source = LocalizationManager.Sources[index];
        if (Object.op_Inequality((Object) source, (Object) null) && source.IsEqualTo(this) && Object.op_Inequality((Object) source, (Object) this))
          return true;
      }
      return false;
    }

    public void ClearAllData()
    {
      this.mTerms.Clear();
      this.mLanguages.Clear();
      this.mDictionary.Clear();
    }

    public Object FindAsset(string Name)
    {
      if (this.Assets != null)
      {
        int index = 0;
        for (int length = this.Assets.Length; index < length; ++index)
        {
          if (Object.op_Inequality(this.Assets[index], (Object) null) && this.Assets[index].name == Name)
            return this.Assets[index];
        }
      }
      return (Object) null;
    }

    public bool HasAsset(Object Obj) => Array.IndexOf<Object>(this.Assets, Obj) >= 0;

    public void AddAsset(Object Obj)
    {
      Array.Resize<Object>(ref this.Assets, this.Assets.Length + 1);
      this.Assets[this.Assets.Length - 1] = Obj;
    }

    public enum eGoogleUpdateFrequency
    {
      Always,
      Never,
      Daily,
      Weekly,
      Monthly,
    }

    public enum eInputSpecialization
    {
      PC,
      Touch,
      Controller,
    }
  }
}
