// Decompiled with JetBrains decompiler
// Type: System.Tuple
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace System
{
  public static class Tuple
  {
    public static Tuple<T1> Create<T1>(T1 item1) => new Tuple<T1>(item1);

    public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
    {
      return new Tuple<T1, T2>(item1, item2);
    }

    public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    {
      return new Tuple<T1, T2, T3>(item1, item2, item3);
    }

    public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(
      T1 item1,
      T2 item2,
      T3 item3,
      T4 item4)
    {
      return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
    }

    public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(
      T1 item1,
      T2 item2,
      T3 item3,
      T4 item4,
      T5 item5)
    {
      return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
    }

    public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(
      T1 item1,
      T2 item2,
      T3 item3,
      T4 item4,
      T5 item5,
      T6 item6)
    {
      return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
    }

    public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(
      T1 item1,
      T2 item2,
      T3 item3,
      T4 item4,
      T5 item5,
      T6 item6,
      T7 item7)
    {
      return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
    }
  }
}
