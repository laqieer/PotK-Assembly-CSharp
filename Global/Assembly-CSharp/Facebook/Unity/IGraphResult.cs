// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IGraphResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  public interface IGraphResult : IResult
  {
    IList<object> ResultList { get; }

    Texture2D Texture { get; }
  }
}
