// Decompiled with JetBrains decompiler
// Type: LogKit.Buffer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

namespace LogKit
{
  public class Buffer : List<Log>
  {
    private readonly int mSize;

    public bool IsAcquired { get; private set; }

    public int AvailableSize => this.mSize - this.Count;

    public Buffer(int size)
      : base(size)
      => this.mSize = size;

    public void Acquire() => this.IsAcquired = true;

    public void Release() => this.IsAcquired = false;
  }
}
