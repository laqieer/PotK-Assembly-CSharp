// Decompiled with JetBrains decompiler
// Type: CriAtomExSequencer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

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
