// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResource
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
namespace CriMana.Detail
{
  public abstract class RendererResource : IDisposable
  {
    private bool disposed;

    ~RendererResource() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
        this.OnDisposeManaged();
      this.OnDisposeUnmanaged();
      this.disposed = true;
    }

    protected abstract void OnDisposeManaged();

    protected abstract void OnDisposeUnmanaged();

    public abstract bool IsPrepared();

    public abstract bool ContinuePreparing();

    public abstract void AttachToPlayer(int playerId);

    public abstract bool UpdateFrame(int playerId, FrameInfo frameInfo);

    public abstract bool UpdateMaterial(Material material);

    public abstract bool IsSuitable(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader);

    public static uint NextPowerOfTwo(uint x)
    {
      --x;
      x |= x >> 1;
      x |= x >> 2;
      x |= x >> 4;
      x |= x >> 8;
      x |= x >> 16;
      return x + 1U;
    }

    public static int NextPowerOfTwo(int x) => (int) RendererResource.NextPowerOfTwo((uint) x);

    public static int Ceiling16(int x) => x + 15 & -16;

    public static int Ceiling64(int x) => x + 63 & -64;

    public static int Ceiling256(int x) => x + (int) byte.MaxValue & -256;
  }
}
