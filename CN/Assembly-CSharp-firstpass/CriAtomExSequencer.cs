// Decompiled with JetBrains decompiler
// Type: CriAtomExSequencer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
public static class CriAtomExSequencer
{
  public static void SetEventCallback(CriAtomExSequencer.EventCbFunc func, string separator = "\t")
  {
    CriAtom.SetEventCallback(func, separator);
  }

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void EventCbFunc(string eventParamsString);
}
