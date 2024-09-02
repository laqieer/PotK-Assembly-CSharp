// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AppRequestResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class AppRequestResult : ResultBase, IAppRequestResult, IResult
  {
    public AppRequestResult(string result)
      : base(result)
    {
      if (this.ResultDictionary == null)
        return;
      string str1;
      if (this.ResultDictionary.TryGetValue<string>("request", out str1))
        this.RequestID = str1;
      string str2;
      if (!this.ResultDictionary.TryGetValue<string>("to", out str2))
        return;
      this.To = (IEnumerable<string>) str2.Split(',');
    }

    public string RequestID { get; private set; }

    public IEnumerable<string> To { get; private set; }
  }
}
