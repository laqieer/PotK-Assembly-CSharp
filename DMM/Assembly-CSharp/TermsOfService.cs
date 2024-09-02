// Decompiled with JetBrains decompiler
// Type: TermsOfService
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

[AddComponentMenu("Utility/Agreement/TermsOfService")]
public class TermsOfService : MonoBehaviour
{
  private static int? update_date_;
  [SerializeField]
  [Tooltip("更新年月日(YYYYMMDD)")]
  private string UpdateDate_ = "20200401";
  [SerializeField]
  [Tooltip("rule.txt")]
  public TermsOfService.Content content_;
  [SerializeField]
  [Tooltip("privacy_policy.txt")]
  private TextAsset privacyPolicy_;

  public static int update_date
  {
    get
    {
      if (TermsOfService.update_date_.HasValue)
        return TermsOfService.update_date_.Value;
      TermsOfService.initialize();
      return TermsOfService.update_date_.Value;
    }
  }

  private static void initialize() => TermsOfService.update_date_ = new int?(int.Parse(TermsOfService.GetData().UpdateDate_, NumberStyles.AllowHexSpecifier));

  public static TermsOfService GetData() => Resources.Load<GameObject>("Agreement/TermsOfService").GetComponent<TermsOfService>();

  public string UpdateDate
  {
    get => this.UpdateDate_;
    set
    {
    }
  }

  public TermsOfService.Content content
  {
    get
    {
      if (!this.content_.isLoaded)
        this.content_.loadText(this.content_.asset_.text);
      return this.content_;
    }
  }

  public string privacyPolicy => this.privacyPolicy_.text;

  private void Awake() => this.content_.loadText(this.content_.asset_.text);

  [Serializable]
  public class Content
  {
    public TextAsset asset_;

    public bool isLoaded { get; private set; }

    public string title { get; set; }

    public string header { get; set; }

    public string text { get; set; }

    public string titleDissent { get; set; }

    public string textDissent { get; set; }

    public void setTextAsset(TextAsset txtAsset)
    {
      this.asset_ = txtAsset;
      this.isLoaded = false;
      if (!((UnityEngine.Object) txtAsset != (UnityEngine.Object) null))
        return;
      this.loadText(txtAsset.text);
    }

    public void loadText(string data)
    {
      if (this.isLoaded || string.IsNullOrEmpty(data))
        return;
      int num = 0;
      using (StringReader stringReader = new StringReader(data))
      {
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        List<string> stringList3 = new List<string>();
        while (stringReader.Peek() != -1)
        {
          string str = stringReader.ReadLine();
          if (str.StartsWith("#"))
          {
            if (str.Equals("#title"))
            {
              num = 1;
              continue;
            }
            if (str.Equals("#header"))
            {
              num = 2;
              continue;
            }
            if (str.Equals("#main"))
            {
              num = 3;
              continue;
            }
            if (str.Equals("#titleDissent"))
            {
              num = 4;
              continue;
            }
            if (str.Equals("#dissent"))
            {
              num = 5;
              continue;
            }
          }
          switch (num)
          {
            case 1:
              this.title = str;
              continue;
            case 2:
              stringList1.Add(str);
              continue;
            case 3:
              stringList2.Add(str);
              continue;
            case 4:
              this.titleDissent = str;
              continue;
            case 5:
              stringList3.Add(str);
              continue;
            default:
              continue;
          }
        }
        this.header = string.Join("\n", (IEnumerable<string>) stringList1);
        this.text = string.Join("\n", (IEnumerable<string>) stringList2);
        this.textDissent = string.Join("\n", (IEnumerable<string>) stringList3);
      }
      this.isLoaded = true;
    }
  }
}
