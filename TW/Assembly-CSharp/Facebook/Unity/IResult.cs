// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
