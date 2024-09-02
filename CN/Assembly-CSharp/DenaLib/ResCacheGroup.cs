// Decompiled with JetBrains decompiler
// Type: DenaLib.ResCacheGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace DenaLib
{
  public class ResCacheGroup
  {
    public List<ResCache> ResCacheList = new List<ResCache>();
    public long Size;
    public static int MaxCount = 100;
  }
}
