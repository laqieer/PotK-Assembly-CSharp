// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.GroupCreateResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  internal class GroupCreateResult : ResultBase, IGroupCreateResult, IResult
  {
    public const string IDKey = "id";

    public GroupCreateResult(ResultContainer resultContainer)
      : base(resultContainer)
    {
      string str;
      if (this.ResultDictionary == null || !this.ResultDictionary.TryGetValue<string>("id", out str))
        return;
      this.GroupId = str;
    }

    public string GroupId { get; private set; }

    public override string ToString()
    {
      return Utilities.FormatToString(base.ToString(), this.GetType().Name, (IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "GroupId",
          this.GroupId
        }
      });
    }
  }
}
