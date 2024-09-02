// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IAppLinkResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  public interface IAppLinkResult : IResult
  {
    string Url { get; }

    string TargetUrl { get; }

    string Ref { get; }

    IDictionary<string, object> Extras { get; }
  }
}
