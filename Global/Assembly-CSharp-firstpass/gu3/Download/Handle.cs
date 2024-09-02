// Decompiled with JetBrains decompiler
// Type: gu3.Download.Handle
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace gu3.Download
{
  internal class Handle
  {
    private static Dictionary<IDownloadHandler, GCHandle> cache = new Dictionary<IDownloadHandler, GCHandle>();
    private uint referenceCount;
    private IDownloadHandler handler;

    private Handle(IDownloadHandler handler) => this.handler = handler;

    public static IntPtr ToIntPtr(IDownloadHandler handler)
    {
      GCHandle gcHandle1;
      if (!Handle.cache.TryGetValue(handler, out gcHandle1))
      {
        GCHandle gcHandle2 = GCHandle.Alloc((object) new Handle(handler));
        Handle.cache[handler] = gcHandle2;
        gcHandle1 = gcHandle2;
      }
      ++((Handle) gcHandle1.Target).referenceCount;
      return GCHandle.ToIntPtr(gcHandle1);
    }

    public static IDownloadHandler FromIntPtr(IntPtr ptr)
    {
      return ((Handle) GCHandle.FromIntPtr(ptr).Target).handler;
    }

    public static void Remove(IDownloadHandler handler)
    {
      GCHandle gcHandle;
      if (!Handle.cache.TryGetValue(handler, out gcHandle))
        return;
      Handle target = (Handle) gcHandle.Target;
      if (--target.referenceCount > 0U)
        return;
      Handle.cache.Remove(target.handler);
      gcHandle.Free();
    }

    public static void RemoveAll()
    {
      foreach (GCHandle gcHandle in Handle.cache.Values)
        gcHandle.Free();
      Handle.cache.Clear();
    }
  }
}
