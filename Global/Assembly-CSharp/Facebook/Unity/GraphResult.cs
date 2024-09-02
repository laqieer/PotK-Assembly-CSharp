// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.GraphResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal class GraphResult : ResultBase, IGraphResult, IResult
  {
    internal GraphResult(WWW result)
      : base(new ResultContainer(result.text), result.error, false)
    {
      this.Init(this.RawResult);
      if (result.error != null)
        return;
      this.Texture = result.texture;
    }

    public IList<object> ResultList { get; private set; }

    public Texture2D Texture { get; private set; }

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
