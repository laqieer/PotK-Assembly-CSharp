// Decompiled with JetBrains decompiler
// Type: TimeSpanExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;

#nullable disable
public static class TimeSpanExtension
{
  public static string DisplayString(this TimeSpan self)
  {
    if (self.TotalDays >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalDays).ToString()
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        }
      });
    if (self.TotalHours >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalHours).ToString()
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        }
      });
    if (self.TotalMinutes >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalMinutes).ToString()
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
        }
      });
    if (self.TotalSeconds >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) ((int) self.TotalSeconds).ToString()
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_SECOND
        }
      });
    return Consts.Format(Consts.GetInstance().DISPLAY_STRING, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) "0"
      },
      {
        (object) "time",
        (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_SECOND
      }
    });
  }

  public static string DisplayStringForFriends(this TimeSpan self)
  {
    if (self.TotalDays >= 3.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "３"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalDays >= 2.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "２"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalDays >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "１"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalHours >= 12.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "１２"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalHours >= 6.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "６"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalHours >= 3.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "３"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalHours >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "１"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().INSIDE
        }
      });
    if (self.TotalMinutes >= 30.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "３０"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
        },
        {
          (object) "status",
          (object) Consts.GetInstance().FRONT
        }
      });
    if (self.TotalMinutes >= 10.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) "１０"
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
        },
        {
          (object) "status",
          (object) Consts.GetInstance().FRONT
        }
      });
    return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) "５"
      },
      {
        (object) "time",
        (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
      },
      {
        (object) "status",
        (object) Consts.GetInstance().FRONT
      }
    });
  }

  public static string DisplayStringForFriendsApplied(this TimeSpan self)
  {
    if ((double) self.Days < 1.0)
      return string.Format(Consts.GetInstance().TODAY);
    return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) self.Days.ToString()
      },
      {
        (object) "time",
        (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
      },
      {
        (object) "status",
        (object) Consts.GetInstance().FRONT
      }
    });
  }

  public static string DisplayStringForGuildMember(this TimeSpan self)
  {
    if (self.TotalDays >= 14.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_14
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalDays >= 7.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_7
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalDays >= 3.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_3
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalDays >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_1
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_DAY
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalHours >= 12.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_12
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalHours >= 6.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_6
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalHours >= 1.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_1
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_HOUR
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalMinutes >= 30.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
      {
        {
          (object) "value",
          (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_30
        },
        {
          (object) "time",
          (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
        },
        {
          (object) "status",
          (object) Consts.GetInstance().OVER
        }
      });
    if (self.TotalMinutes < 10.0)
      return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_GUILD);
    return Consts.Format(Consts.GetInstance().DISPLAY_STRING_FOR_FRIEND, (IDictionary) new Hashtable()
    {
      {
        (object) "value",
        (object) Consts.GetInstance().DISPLAY_STRING_FOR_GUILD_10
      },
      {
        (object) "time",
        (object) Consts.GetInstance().COLOSSEUM_BONUS_TIME_MINUE
      },
      {
        (object) "status",
        (object) Consts.GetInstance().OVER
      }
    });
  }
}
