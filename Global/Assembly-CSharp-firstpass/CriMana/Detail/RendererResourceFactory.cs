// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceFactory
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace CriMana.Detail
{
  public abstract class RendererResourceFactory : IDisposable
  {
    private static SortedList<int, RendererResourceFactory> factoryList = new SortedList<int, RendererResourceFactory>();
    private bool disposed;

    public static void RegisterFactory(RendererResourceFactory factory, int priority)
    {
      RendererResourceFactory.factoryList.Add(priority, factory);
    }

    public static void DisposeAllFactories()
    {
      foreach (KeyValuePair<int, RendererResourceFactory> factory in RendererResourceFactory.factoryList)
        factory.Value.Dispose();
      RendererResourceFactory.factoryList.Clear();
    }

    public static RendererResource DispatchAndCreate(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader)
    {
      foreach (KeyValuePair<int, RendererResourceFactory> factory in RendererResourceFactory.factoryList)
      {
        RendererResource rendererResource = factory.Value.CreateRendererResource(playerId, movieInfo, additive, userShader);
        if (rendererResource != null)
          return rendererResource;
      }
      Debug.LogError((object) "[CRIWARE] unsupported movie.");
      return (RendererResource) null;
    }

    ~RendererResourceFactory() => this.Dispose(false);

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

    public abstract RendererResource CreateRendererResource(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader);
  }
}
