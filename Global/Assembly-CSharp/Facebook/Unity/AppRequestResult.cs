// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AppRequestResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class AppRequestResult : ResultBase, IAppRequestResult, IResult
  {
    public const string RequestIDKey = "request";
    public const string ToKey = "to";

    public AppRequestResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      if (this.ResultDictionary == null)
        return;
      string str1;
      if (this.ResultDictionary.TryGetValue<string>("request", out str1))
        this.RequestID = str1;
      string str2;
      if (this.ResultDictionary.TryGetValue<string>("to", out str2))
      {
        this.To = (IEnumerable<string>) str2.Split(',');
      }
      else
      {
        IEnumerable<object> objects;
        if (!this.ResultDictionary.TryGetValue<IEnumerable<object>>("to", out objects))
          return;
        List<string> stringList = new List<string>();
        foreach (object obj in objects)
        {
          if (obj is string str3)
            stringList.Add(str3);
        }
        this.To = (IEnumerable<string>) stringList;
      }
    }

    public string RequestID { get; private set; }

    public IEnumerable<string> To { get; private set; }

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "RequestID",
          this.RequestID
        },
        {
          "To",
          this.To == null ? (string) null : this.To.ToCommaSeparateList()
        }
      });
    }
  }
}
