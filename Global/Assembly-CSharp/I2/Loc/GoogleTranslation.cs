// Decompiled with JetBrains decompiler
// Type: I2.Loc.GoogleTranslation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

#nullable disable
namespace I2.Loc
{
  public static class GoogleTranslation
  {
    public static bool CanTranslate()
    {
      return LocalizationManager.Sources.Count > 0 && !string.IsNullOrEmpty(LocalizationManager.Sources[0].Google_WebServiceURL);
    }

    public static void Translate(
      string text,
      string LanguageCodeFrom,
      string LanguageCodeTo,
      Action<string> OnTranslationReady)
    {
      CoroutineManager.pInstance.StartCoroutine(GoogleTranslation.WaitForTranslation(GoogleTranslation.GetTranslationWWW(text, LanguageCodeFrom, LanguageCodeTo), OnTranslationReady, text));
    }

    [DebuggerHidden]
    private static IEnumerator WaitForTranslation(
      WWW www,
      Action<string> OnTranslationReady,
      string OriginalText)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GoogleTranslation.\u003CWaitForTranslation\u003Ec__Iterator111()
      {
        www = www,
        OnTranslationReady = OnTranslationReady,
        OriginalText = OriginalText,
        \u003C\u0024\u003Ewww = www,
        \u003C\u0024\u003EOnTranslationReady = OnTranslationReady,
        \u003C\u0024\u003EOriginalText = OriginalText
      };
    }

    public static string ForceTranslate(
      string text,
      string LanguageCodeFrom,
      string LanguageCodeTo)
    {
      WWW translationWww = GoogleTranslation.GetTranslationWWW(text, LanguageCodeFrom, LanguageCodeTo);
      do
        ;
      while (!translationWww.isDone);
      if (string.IsNullOrEmpty(translationWww.error))
        return GoogleTranslation.ParseTranslationResult(translationWww.text, text);
      Debug.LogError((object) ("-- " + translationWww.error));
      foreach (KeyValuePair<string, string> responseHeader in translationWww.responseHeaders)
        Debug.Log((object) (responseHeader.Value + "=" + responseHeader.Key));
      return string.Empty;
    }

    public static WWW GetTranslationWWW(
      string text,
      string LanguageCodeFrom,
      string LanguageCodeTo)
    {
      LanguageCodeFrom = GoogleLanguages.GetGoogleLanguageCode(LanguageCodeFrom);
      LanguageCodeTo = GoogleLanguages.GetGoogleLanguageCode(LanguageCodeTo);
      if (GoogleTranslation.TitleCase(text) == text)
        text = text.ToLower();
      return new WWW(string.Format("{0}?action=Translate&list={1}:{2}={3}", (object) LocalizationManager.Sources[0].Google_WebServiceURL, (object) LanguageCodeFrom, (object) LanguageCodeTo, (object) Uri.EscapeUriString(text)));
    }

    public static string ParseTranslationResult(string html, string OriginalText)
    {
      try
      {
        string s = html;
        if (GoogleTranslation.TitleCase(OriginalText) == OriginalText)
          s = GoogleTranslation.TitleCase(s);
        return s;
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ex.Message);
        return string.Empty;
      }
    }

    public static void Translate(
      List<TranslationRequest> requests,
      Action<List<TranslationRequest>> OnTranslationReady)
    {
      CoroutineManager.pInstance.StartCoroutine(GoogleTranslation.WaitForTranslation(GoogleTranslation.GetTranslationWWW(requests), OnTranslationReady, requests));
    }

    public static WWW GetTranslationWWW(List<TranslationRequest> requests)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(LocalizationManager.Sources[0].Google_WebServiceURL);
      stringBuilder.Append("?action=Translate&list=");
      bool flag = true;
      foreach (TranslationRequest request in requests)
      {
        if (!flag)
          stringBuilder.Append("<I2Loc>");
        stringBuilder.Append(request.LanguageCode);
        stringBuilder.Append(":");
        for (int index = 0; index < request.TargetLanguagesCode.Length; ++index)
        {
          if (index != 0)
            stringBuilder.Append(",");
          stringBuilder.Append(request.TargetLanguagesCode[index]);
        }
        stringBuilder.Append("=");
        string stringToEscape = !(GoogleTranslation.TitleCase(request.Text) == request.Text) ? request.Text : request.Text.ToLowerInvariant();
        stringBuilder.Append(Uri.EscapeUriString(stringToEscape));
        flag = false;
      }
      string o = stringBuilder.ToString();
      Debug.Log((object) o);
      return new WWW(o);
    }

    [DebuggerHidden]
    private static IEnumerator WaitForTranslation(
      WWW www,
      Action<List<TranslationRequest>> OnTranslationReady,
      List<TranslationRequest> requests)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GoogleTranslation.\u003CWaitForTranslation\u003Ec__Iterator112()
      {
        www = www,
        OnTranslationReady = OnTranslationReady,
        requests = requests,
        \u003C\u0024\u003Ewww = www,
        \u003C\u0024\u003EOnTranslationReady = OnTranslationReady,
        \u003C\u0024\u003Erequests = requests
      };
    }

    public static string ParseTranslationResult(string html, List<TranslationRequest> requests)
    {
      Debug.Log((object) html);
      if (html.StartsWith("<!DOCTYPE html>") || html.StartsWith("<HTML>"))
        return "There was a problem contacting the WebService. Please try again later";
      string[] strArray = html.Split(new string[1]
      {
        "<I2Loc>"
      }, StringSplitOptions.None);
      string[] separator = new string[1]{ "<i2>" };
      for (int index1 = 0; index1 < Mathf.Min(requests.Count, strArray.Length); ++index1)
      {
        TranslationRequest request = requests[index1] with
        {
          Results = strArray[index1].Split(separator, StringSplitOptions.None)
        };
        if (GoogleTranslation.TitleCase(request.Text) == request.Text)
        {
          for (int index2 = 0; index2 < request.Results.Length; ++index2)
            request.Results[index2] = GoogleTranslation.TitleCase(request.Results[index2]);
        }
        requests[index1] = request;
      }
      return string.Empty;
    }

    public static string UppercaseFirst(string s)
    {
      if (string.IsNullOrEmpty(s))
        return string.Empty;
      char[] charArray = s.ToLower().ToCharArray();
      charArray[0] = char.ToUpper(charArray[0]);
      return new string(charArray);
    }

    public static string TitleCase(string s)
    {
      if (string.IsNullOrEmpty(s))
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(s);
      stringBuilder[0] = char.ToUpper(stringBuilder[0]);
      int index = 1;
      for (int length = s.Length; index < length; ++index)
        stringBuilder[index] = !char.IsWhiteSpace(stringBuilder[index - 1]) ? char.ToLower(stringBuilder[index]) : char.ToUpper(stringBuilder[index]);
      return stringBuilder.ToString();
    }
  }
}
