// Decompiled with JetBrains decompiler
// Type: LocalizationPreset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
[ExecuteInEditMode]
public class LocalizationPreset : MonoBehaviour
{
  private static LocalizationPreset instance;
  public LanguageCollection language;
  public GameObject agreementSource;
  public GameObject langSourcePrefab;
  public bool EnableLocalization;
  private GameObject GlobalLangSource;

  public static LocalizationPreset Instance
  {
    get
    {
      if (Object.op_Equality((Object) LocalizationPreset.instance, (Object) null))
        LocalizationPreset.GetInstance();
      return LocalizationPreset.instance;
    }
  }

  private void Awake()
  {
    if (Object.op_Implicit((Object) LocalizationPreset.instance))
      Object.Destroy((Object) this);
    else
      LocalizationPreset.instance = this;
    if (this.EnableLocalization)
      PlayerPrefs.SetString("LanguageToLoad", "English");
    this.ChangeGlobalLanguage(PlayerPrefs.GetString("LanguageToLoad"));
  }

  public void ChangeGlobalLanguage(string Language)
  {
    switch (Language)
    {
      case "Japanese":
        this.EnableLocalization = false;
        LocalizationPreset.Instance.language = LanguageCollection.Japanese;
        break;
      case "English":
        this.EnableLocalization = true;
        LocalizationPreset.Instance.language = LanguageCollection.English;
        break;
    }
    if (!this.EnableLocalization)
      ;
  }

  private void StartTranslate()
  {
    LocalizationPreset.Translate("うとよ", "ja", "en", new Action<string, GameObject>(this.OnTranslationReady), ((Component) this).gameObject);
  }

  private void OnTranslationReady(string onTranslationReady, GameObject go)
  {
  }

  public static void Translate(
    string text,
    string LanguageCodeFrom,
    string LanguageCodeTo,
    Action<string, GameObject> OnTranslationReady,
    GameObject go)
  {
    CoroutineManager.pInstance.StartCoroutine(LocalizationPreset.WaitForTranslation(LocalizationPreset.GetTranslationWWW(text, LanguageCodeFrom, LanguageCodeTo), OnTranslationReady, text.ToUpper() == text, go));
  }

  [DebuggerHidden]
  private static IEnumerator WaitForTranslation(
    WWW www,
    Action<string, GameObject> OnTranslationReady,
    bool MakeAllCaps,
    GameObject go)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LocalizationPreset.\u003CWaitForTranslation\u003Ec__Iterator11A()
    {
      www = www,
      OnTranslationReady = OnTranslationReady,
      MakeAllCaps = MakeAllCaps,
      go = go,
      \u003C\u0024\u003Ewww = www,
      \u003C\u0024\u003EOnTranslationReady = OnTranslationReady,
      \u003C\u0024\u003EMakeAllCaps = MakeAllCaps,
      \u003C\u0024\u003Ego = go
    };
  }

  public static string ForceTranslate(string text, string LanguageCodeFrom, string LanguageCodeTo)
  {
    Debug.LogWarning((object) ("Translation was not found, querying google translate: " + text + " from " + LanguageCodeFrom + " to " + LanguageCodeTo));
    WWW translationWww = LocalizationPreset.GetTranslationWWW(text, LanguageCodeFrom, LanguageCodeTo);
    do
      ;
    while (!translationWww.isDone);
    if (string.IsNullOrEmpty(translationWww.error))
      return LocalizationPreset.ParseTranslationResult(translationWww.text, text.ToUpper() == text);
    Debug.LogError((object) translationWww.error);
    return string.Empty;
  }

  private static WWW GetTranslationWWW(string text, string LanguageCodeFrom, string LanguageCodeTo)
  {
    return new WWW(Uri.EscapeUriString(string.Format("http://www.google.com/translate_t?hl=en&vi=c&ie=UTF8&oe=UTF8&submit=Translate&langpair={0}|{1}&text={2}", (object) LanguageCodeFrom, (object) LanguageCodeTo, (object) text)));
  }

  private static string ParseTranslationResult(string html, bool MakeAllCaps)
  {
    try
    {
      int startIndex = html.IndexOf("TRANSLATED_TEXT") + "TRANSLATED_TEXT='".Length;
      int num = html.IndexOf("';INPUT_TOOL_PATH", startIndex);
      string translationResult = Regex.Replace(Regex.Replace(html.Substring(startIndex, num - startIndex), "\\\\x([a-fA-F0-9]{2})", (MatchEvaluator) (match => char.ConvertFromUtf32(int.Parse(match.Groups[1].Value, NumberStyles.HexNumber)))), "&#(\\d+);", (MatchEvaluator) (match => char.ConvertFromUtf32(int.Parse(match.Groups[1].Value)))).Replace("<br>", "\n");
      if (MakeAllCaps)
        translationResult = translationResult.ToUpper();
      return translationResult;
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ex.Message);
      return string.Empty;
    }
  }

  private static void GetInstance()
  {
    new GameObject(nameof (LocalizationPreset)).AddComponent<LocalizationPreset>();
  }

  public GameObject languageResource { get; set; }

  public GameObject agreementResource { get; set; }
}
