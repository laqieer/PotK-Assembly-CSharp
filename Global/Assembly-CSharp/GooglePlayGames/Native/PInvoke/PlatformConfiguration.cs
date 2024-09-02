// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.PlatformConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal abstract class PlatformConfiguration : BaseReferenceHolder
  {
    protected PlatformConfiguration(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal HandleRef AsHandle() => this.SelfPtr();
  }
}
