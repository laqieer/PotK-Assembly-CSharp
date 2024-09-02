// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AppLinkResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class AppLinkResult : ResultBase, IAppLinkResult, IResult
  {
    public AppLinkResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      if (this.ResultDictionary == null)
        return;
      string str1;
      if (this.ResultDictionary.TryGetValue<string>("url", out str1))
        this.Url = str1;
      string str2;
      if (this.ResultDictionary.TryGetValue<string>("target_url", out str2))
        this.TargetUrl = str2;
      string str3;
      if (this.ResultDictionary.TryGetValue<string>("ref", out str3))
        this.Ref = str3;
      IDictionary<string, object> dictionary;
      if (!this.ResultDictionary.TryGetValue<IDictionary<string, object>>("extras", out dictionary))
        return;
      this.Extras = dictionary;
    }

    public string Url { get; private set; }

    public string TargetUrl { get; private set; }

    public string Ref { get; private set; }

    public IDictionary<string, object> Extras { get; private set; }

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "Url",
          this.Url
        },
        {
          "TargetUrl",
          this.TargetUrl
        },
        {
          "Ref",
          this.Ref
        },
        {
          "Extras",
          this.Extras.ToJson()
        }
      });
    }
  }
}
