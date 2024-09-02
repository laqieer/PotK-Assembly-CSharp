// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity
{
  public interface IResult
  {
    string Error { get; }

    IDictionary<string, object> ResultDictionary { get; }

    string RawResult { get; }

    bool Cancelled { get; }
  }
}
