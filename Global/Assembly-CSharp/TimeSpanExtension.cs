// Decompiled with JetBrains decompiler
// Type: TimeSpanExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;

#nullable disable
public static class TimeSpanExtension
{
  public static string DisplayString(this TimeSpan self)
  {
    if (self.TotalDays >= 99.0)
      return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "99"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_DAY")
        }
      });
    if (self.TotalDays >= 1.0)
      return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalDays).ToString()
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_DAY")
        }
      });
    if (self.TotalHours >= 1.0)
      return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalHours).ToString()
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_HOUR")
        }
      });
    if (self.TotalMinutes >= 1.0)
      return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalMinutes).ToString()
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_MINUE")
        }
      });
    if (self.TotalSeconds >= 1.0)
      return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalSeconds).ToString()
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_SECOND")
        }
      });
    return Consts.Lookup("DISPLAY_STRING", (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) "0"
      },
      {
        (object) "time",
        (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_SECOND")
      }
    });
  }

  public static string DisplayStringForFriends(this TimeSpan self)
  {
    if (self.TotalDays >= 3.0)
      return Consts.Lookup("LAST_PLAY_OVER_3_DAYS", (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) 3
        }
      });
    if (self.TotalDays >= 2.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "2"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_DAY")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalDays >= 1.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "1"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_DAY")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalHours >= 12.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "12"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_HOUR")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalHours >= 6.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "6"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_HOUR")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalHours >= 3.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "3"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_HOUR")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalHours >= 1.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "1"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_HOUR")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalMinutes >= 30.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "30"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_MINUE")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    if (self.TotalMinutes >= 10.0)
      return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "10"
        },
        {
          (object) "time",
          (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_MINUE")
        },
        {
          (object) "status",
          (object) Consts.Lookup("FRONT")
        }
      });
    return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) "5"
      },
      {
        (object) "time",
        (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_MINUE")
      },
      {
        (object) "status",
        (object) Consts.Lookup("FRONT")
      }
    });
  }

  public static string DisplayStringForFriendsApplied(this TimeSpan self)
  {
    if ((double) self.Days < 1.0)
      return string.Format(Consts.Lookup("TODAY"));
    return Consts.Lookup("DISPLAY_STRING_FOR_FRIEND", (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) self.Days.ToString()
      },
      {
        (object) "time",
        (object) Consts.Lookup("COLOSSEUM_BONUS_TIME_DAY")
      },
      {
        (object) "status",
        (object) Consts.Lookup("FRONT")
      }
    });
  }
}
