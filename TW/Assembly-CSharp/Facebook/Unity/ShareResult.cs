// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ShareResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal class ShareResult : ResultBase, IResult, IShareResult
  {
    internal ShareResult(string result)
      : base(result)
    {
      object obj;
      if (this.ResultDictionary == null || !this.ResultDictionary.TryGetValue("id", out obj))
        return;
      this.PostId = obj as string;
    }

    public string PostId { get; private set; }
  }
}
