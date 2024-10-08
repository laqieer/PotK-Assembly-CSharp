﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.CallbackUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.OurUtils;
using System;

#nullable disable
namespace GooglePlayGames.Native
{
  internal static class CallbackUtils
  {
    internal static Action<T> ToOnGameThread<T>(Action<T> toConvert)
    {
      return toConvert == null ? (Action<T>) (_param0 => { }) : (Action<T>) (val => PlayGamesHelperObject.RunOnGameThread((Action) (() => toConvert(val))));
    }

    internal static Action<T1, T2> ToOnGameThread<T1, T2>(Action<T1, T2> toConvert)
    {
      return toConvert == null ? (Action<T1, T2>) ((_param0, _param1) => { }) : (Action<T1, T2>) ((val1, val2) => PlayGamesHelperObject.RunOnGameThread((Action) (() => toConvert(val1, val2))));
    }

    internal static Action<T1, T2, T3> ToOnGameThread<T1, T2, T3>(Action<T1, T2, T3> toConvert)
    {
      return toConvert == null ? (Action<T1, T2, T3>) ((_param0, _param1, _param2) => { }) : (Action<T1, T2, T3>) ((val1, val2, val3) => PlayGamesHelperObject.RunOnGameThread((Action) (() => toConvert(val1, val2, val3))));
    }
  }
}
