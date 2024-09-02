// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.GroupCreateResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal class GroupCreateResult : ResultBase, IGroupCreateResult, IResult
  {
    internal GroupCreateResult(string result)
      : base(result)
    {
      string str;
      if (this.ResultDictionary == null || !this.ResultDictionary.TryGetValue<string>("id", out str))
        return;
      this.GroupId = str;
    }

    public string GroupId { get; private set; }
  }
}
