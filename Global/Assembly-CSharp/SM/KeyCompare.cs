// Decompiled with JetBrains decompiler
// Type: SM.KeyCompare
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace SM
{
  [Serializable]
  public class KeyCompare
  {
    protected bool _hasKey;
    protected object _key;

    public bool hasKey => this._hasKey;

    public object Key => this._key;
  }
}
