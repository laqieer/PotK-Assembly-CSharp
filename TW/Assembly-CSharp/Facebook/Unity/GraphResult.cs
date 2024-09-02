// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.GraphResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal class GraphResult : ResultBase, IGraphResult, IResult
  {
    internal GraphResult(WWW result)
      : base(result.text, result.error, false)
    {
      this.Init(this.RawResult);
    }

    public IList<object> ResultList { get; private set; }

    private void Init(string rawResult)
    {
      if (string.IsNullOrEmpty(rawResult))
        return;
      switch (Json.Deserialize(this.RawResult))
      {
        case IDictionary<string, object> dictionary:
          this.ResultDictionary = dictionary;
          break;
        case IList<object> objectList:
          this.ResultList = objectList;
          break;
      }
    }
  }
}
