// Decompiled with JetBrains decompiler
// Type: gu3.LocalNotification
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
namespace gu3
{
  public class LocalNotification
  {
    private const string LIBNAME = "UnityLocalNotification";

    [DllImport("UnityLocalNotification")]
    private static extern void LocalNotification_cancelNotificationsWithCategory(string category);

    [DllImport("UnityLocalNotification")]
    private static extern void LocalNotification_show(
      ref LocalNotification.Notification notification);

    [DllImport("UnityLocalNotification")]
    private static extern void LocalNotification_schedule(
      ref LocalNotification.Notification notification,
      int year,
      int month,
      int day,
      int hour,
      int minute,
      int second);

    [DllImport("UnityLocalNotification")]
    private static extern void LocalNotification_scheduleWithRepeat(
      ref LocalNotification.Notification notification,
      int hour,
      int minute,
      int second,
      int repeat);

    [DllImport("UnityLocalNotification")]
    private static extern void LocalNotification_scheduleWithTimeInterval(
      ref LocalNotification.Notification notification,
      int seconds);

    public static void CancelNotificationsWithCategory(string category)
    {
      LocalNotification.LocalNotification_cancelNotificationsWithCategory(category);
    }

    public static void Show(LocalNotification.Notification notification)
    {
      LocalNotification.LocalNotification_show(ref notification);
    }

    public static void Schedule(
      LocalNotification.Notification notification,
      int year,
      int month,
      int day,
      int hour,
      int minute,
      int second)
    {
      LocalNotification.LocalNotification_schedule(ref notification, year, month, day, hour, minute, second);
    }

    public static void ScheduleWithRepeat(
      LocalNotification.Notification notification,
      int hour,
      int minute,
      int second,
      LocalNotification.Weekday repeat)
    {
      LocalNotification.LocalNotification_scheduleWithRepeat(ref notification, hour, minute, second, (int) repeat);
    }

    public static void ScheduleWithTimeInterval(
      LocalNotification.Notification notification,
      int seconds)
    {
      LocalNotification.LocalNotification_scheduleWithTimeInterval(ref notification, seconds);
    }

    public enum Weekday
    {
      NonRepeat = 0,
      Sunday = 1,
      Monday = 2,
      Tuesday = 4,
      Wednesday = 8,
      Thursday = 16, // 0x00000010
      Friday = 32, // 0x00000020
      Saturday = 64, // 0x00000040
      Everyday = 127, // 0x0000007F
    }

    public struct Notification
    {
      [MarshalAs(UnmanagedType.LPStr)]
      public string message;
      [MarshalAs(UnmanagedType.LPStr)]
      public string category;
    }
  }
}
