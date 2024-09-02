// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AppLinkResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class AppLinkResult : ResultBase, IAppLinkResult, IResult
  {
    public AppLinkResult(string result)
      : base(result)
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
  }
}
