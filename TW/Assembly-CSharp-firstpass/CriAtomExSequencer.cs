// Decompiled with JetBrains decompiler
// Type: CriAtomExSequencer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

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
