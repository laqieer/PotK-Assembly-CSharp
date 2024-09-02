// Decompiled with JetBrains decompiler
// Type: Language.LanguageService
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SimpleJSON;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Language
{
  [ExecuteInEditMode]
  public class LanguageService
  {
    private static LanguageService _instance;
    public List<LanguageInfo> Languages = new List<LanguageInfo>()
    {
      LanguageInfo.English
    };
    public List<string> LanguageNames = new List<string>();
    private LanguageInfo _language = new LanguageInfo()
    {
      Name = "English"
    };

    public LanguageService() => this.LoadContent();

    public static LanguageService Instance
    {
      get => LanguageService._instance ?? (LanguageService._instance = new LanguageService());
    }

    public List<string> Files { get; set; }

    public Dictionary<string, Dictionary<string, string>> StringsByFile { get; set; }

    public Dictionary<string, string> Strings { get; set; }

    public LanguageInfo Language
    {
      get => this._language;
      set
      {
        if (!this.HasLanguage(value))
          Debug.LogError((object) ("Invalid Language " + (object) value));
        this._language = value;
        this.ReadJosnFiles();
      }
    }

    private bool HasLanguage(LanguageInfo language)
    {
      foreach (LanguageInfo language1 in this.Languages)
      {
        if (language1.Equals(language))
          return true;
      }
      return false;
    }

    public void LoadContent()
    {
      this.LoadAllLanguages((JSONClass) JSONNode.Parse(Resources.Load<TextAsset>("LocalizationConfig").text));
    }

    private void LoadAllLanguages(JSONClass jsonClass)
    {
      LanguageInfo languageInfo1 = LanguageInfo.English;
      foreach (KeyValuePair<string, JSONNode> keyValuePair in jsonClass)
      {
        LanguageInfo languageInfo2 = new LanguageInfo((string) keyValuePair.Value);
        this.LanguageNames.Add(languageInfo2.Name);
        this.Languages.Add(languageInfo2);
        if (keyValuePair.Key == "Default")
          languageInfo1 = languageInfo2;
      }
      this.Language = languageInfo1;
    }

    public string GetFromFile(string groupId, string key, string fallback)
    {
      if (!this.StringsByFile.ContainsKey(groupId))
      {
        Debug.LogWarning((object) ("Localization File Not Found : " + groupId));
        return fallback;
      }
      Dictionary<string, string> dictionary = this.StringsByFile[groupId];
      if (dictionary.ContainsKey(key))
        return dictionary[key];
      Debug.LogWarning((object) ("Localization Key Not Found : " + key));
      return fallback;
    }

    private void ReadJosnFiles()
    {
      this.Strings = new Dictionary<string, string>();
      this.StringsByFile = new Dictionary<string, Dictionary<string, string>>();
      this.Files = new List<string>();
      TextAsset[] source = Resources.LoadAll<TextAsset>("Localization/" + this.Language.Name + "/");
      if (!((IEnumerable<TextAsset>) source).Any<TextAsset>())
        Debug.LogError((object) ("Localization Files Not Found : " + this.Language.Name));
      foreach (TextAsset resource in source)
        this.ReadTextAsset(resource);
    }

    private void ReadTextAsset(TextAsset resource)
    {
      JSONNode jsonNode = JSONNode.Parse(resource.text);
      this.Files.Add(((Object) resource).name);
      this.StringsByFile.Add(((Object) resource).name, new Dictionary<string, string>());
      foreach (KeyValuePair<string, JSONNode> keyValuePair in (JSONClass) jsonNode)
      {
        this.StringsByFile[((Object) resource).name].Add(keyValuePair.Key, (string) keyValuePair.Value);
        if (this.Strings.ContainsKey(keyValuePair.Key))
          Debug.LogWarning((object) ("Duplicate string : " + (object) resource + " : " + keyValuePair.Key));
        else
          this.Strings.Add(keyValuePair.Key, (string) keyValuePair.Value);
      }
    }

    public string GetStringByKey(string key, string fallback)
    {
      if (this.Strings.ContainsKey(key))
        return this.Strings[key];
      Debug.LogWarning((object) string.Format("Localization Key Not Found {0} : {1} ", (object) this.Language.Name, (object) key));
      return fallback;
    }

    public void UpdateText(GameObject textObj, string key, params string[] value)
    {
      UILabel component = ((Component) textObj.transform).GetComponent<UILabel>();
      string format = this.GetStringByKey(key, component.text);
      if (value.Length > 0)
      {
        for (int index = 0; index < value.Length; ++index)
          format = string.Format(format, (object) value[index]);
      }
      component.text = format;
    }
  }
}
