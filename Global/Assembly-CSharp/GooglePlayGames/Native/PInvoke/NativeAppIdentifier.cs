// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeAppIdentifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeAppIdentifier : BaseReferenceHolder
  {
    internal NativeAppIdentifier(IntPtr pointer)
      : base(pointer)
    {
    }

    [DllImport("gpg")]
    internal static extern IntPtr NearbyUtils_ConstructAppIdentifier(string appId);

    internal string Id()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_arg, out_size) => NearbyConnectionTypes.AppIdentifier_GetIdentifier(this.SelfPtr(), out_arg, out_size)));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      NearbyConnectionTypes.AppIdentifier_Dispose(selfPointer);
    }

    internal static NativeAppIdentifier FromString(string appId)
    {
      return new NativeAppIdentifier(NativeAppIdentifier.NearbyUtils_ConstructAppIdentifier(appId));
    }
  }
}
