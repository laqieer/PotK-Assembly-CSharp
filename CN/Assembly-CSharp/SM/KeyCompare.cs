// Decompiled with JetBrains decompiler
// Type: SM.KeyCompare
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
