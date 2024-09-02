// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ShareResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class ShareResult : ResultBase, IResult, IShareResult
  {
    internal ShareResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      if (this.ResultDictionary == null)
        return;
      string str;
      if (this.ResultDictionary.TryGetValue<string>(ShareResult.PostIDKey, out str))
      {
        this.PostId = str;
      }
      else
      {
        if (!this.ResultDictionary.TryGetValue<string>("postId", out str))
          return;
        this.PostId = str;
      }
    }

    public string PostId { get; private set; }

    internal static string PostIDKey => Constants.IsWeb ? "post_id" : "id";

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "PostId",
          this.PostId
        }
      });
    }
  }
}
