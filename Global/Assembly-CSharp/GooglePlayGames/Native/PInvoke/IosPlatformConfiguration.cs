// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.IosPlatformConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.OurUtils;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal sealed class IosPlatformConfiguration : PlatformConfiguration
  {
    private IosPlatformConfiguration(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal void SetClientId(string clientId)
    {
      Misc.CheckNotNull<string>(clientId);
      GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration.IosPlatformConfiguration_SetClientID(this.SelfPtr(), clientId);
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration.IosPlatformConfiguration_Dispose(selfPointer);
    }

    internal static IosPlatformConfiguration Create()
    {
      return new IosPlatformConfiguration(GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration.IosPlatformConfiguration_Construct());
    }
  }
}
