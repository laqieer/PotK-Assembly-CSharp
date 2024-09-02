// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.SExpReader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore.LispCore
{
  public class SExpReader
  {
    private object data;
    private string str;
    private SExpNumber numberDic;

    public SExpReader()
    {
    }

    public SExpReader(SExpNumber ndic) => this.numberDic = ndic;

    private Decimal? numberObject(Decimal d)
    {
      return this.numberDic != null ? this.numberDic.numberObject(d) : new Decimal?(d);
    }

    public object parse(string s, bool retList = false)
    {
      if (string.IsNullOrEmpty(s))
        return (object) null;
      try
      {
        this.str = s;
        if (retList)
        {
          Cons cons1 = SExp.cons((object) null, (object) null);
          Cons cons2 = cons1;
          int p1 = 0;
          do
          {
            cons2.cdr = (object) SExp.cons((object) null, (object) null);
            int p2 = this.readObj(p1);
            (cons2.cdr as Cons).car = this.data;
            cons2 = cons2.cdr as Cons;
            p1 = this.removeWhiteSpace(p2);
          }
          while (p1 != this.str.Length);
          return cons1.cdr;
        }
        this.readObj(0);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        this.str = (string) null;
      }
      return this.data;
    }

    private string substring(string s, int start, int end)
    {
      if (start >= s.Length)
        return string.Empty;
      return end >= s.Length ? s.Substring(start) : s.Substring(start, end - start);
    }

    private string readCharAt(string s, int i) => this.substring(s, i, i + 1);

    private int readObj(int p)
    {
      p = this.removeWhiteSpace(p);
      string key = this.readCharAt(this.str, p);
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapD == null)
        {
          // ISSUE: reference to a compiler-generated field
          SExpReader.\u003C\u003Ef__switch\u0024mapD = new Dictionary<string, int>(2)
          {
            {
              "(",
              0
            },
            {
              ")",
              1
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapD.TryGetValue(key, out num))
        {
          if (num == 0)
            return this.readList(p + 1);
          if (num == 1)
            throw new Exception("readObj : ')'");
        }
      }
      return this.readPrimitive(p);
    }

    private int makeSExpString(int p)
    {
      int start = p;
      for (; p != this.str.Length; ++p)
      {
        switch (this.readCharAt(this.str, p))
        {
          case "\\":
            ++p;
            break;
          case "\"":
            goto label_5;
        }
      }
label_5:
      this.data = (object) new SExpString(this.substring(this.str, start, p));
      return p;
    }

    private int makeToken(int p)
    {
      int start = p;
      string c = this.readCharAt(this.str, p);
      if (c == "\"")
        return this.makeSExpString(p + 1) + 1;
      for (; p != this.str.Length && !this.whiteSpacep(c) && !this.punctp(c); c = this.readCharAt(this.str, p))
        ++p;
      this.data = (object) this.substring(this.str, start, p);
      return p;
    }

    private int readPrimitive(int p)
    {
      p = this.makeToken(this.removeWhiteSpace(p));
      if (this.data is SExpString)
        return p;
      object obj = this.readNumber(this.data as string);
      if (obj == null)
        return p;
      this.data = obj;
      return p;
    }

    private object readNumber(string s)
    {
      Decimal result;
      return Decimal.TryParse(s, out result) ? (object) this.numberObject(result) : (object) null;
    }

    private int readList(int p)
    {
      List<object> args = new List<object>();
      p = this.removeWhiteSpace(p);
      while (this.readCharAt(this.str, p) != ")")
      {
        p = this.readObj(p);
        args.Add(this.data);
        p = this.removeWhiteSpace(p);
        if (this.readCharAt(this.str, p) == ".")
        {
          Cons lispList = SExp.toLispList<object>((IEnumerable<object>) args) as Cons;
          p = this.readObj(p + 1);
          SExp.lastCons((object) lispList).cdr = this.data;
          this.data = (object) lispList;
          p = this.removeWhiteSpace(p);
          if (this.readCharAt(this.str, p) != ")")
            throw new Exception("readList : '.' ')'");
          return p + 1;
        }
        if (p == this.str.Length)
          throw new Exception("readList : EOF.");
      }
      this.data = args.Count != 0 ? SExp.toLispList<object>((IEnumerable<object>) args) : (object) null;
      return p + 1;
    }

    private bool numberp(string c, bool is_first)
    {
      string key = c;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapE == null)
        {
          // ISSUE: reference to a compiler-generated field
          SExpReader.\u003C\u003Ef__switch\u0024mapE = new Dictionary<string, int>(12)
          {
            {
              "0",
              0
            },
            {
              "1",
              0
            },
            {
              "2",
              0
            },
            {
              "3",
              0
            },
            {
              "4",
              0
            },
            {
              "5",
              0
            },
            {
              "6",
              0
            },
            {
              "7",
              0
            },
            {
              "8",
              0
            },
            {
              "9",
              0
            },
            {
              ".",
              0
            },
            {
              "-",
              1
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapE.TryGetValue(key, out num))
        {
          if (num == 0)
            return true;
          if (num == 1)
            return is_first;
        }
      }
      return false;
    }

    private bool punctp(string c)
    {
      string key = c;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapF == null)
        {
          // ISSUE: reference to a compiler-generated field
          SExpReader.\u003C\u003Ef__switch\u0024mapF = new Dictionary<string, int>(2)
          {
            {
              "(",
              0
            },
            {
              ")",
              0
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024mapF.TryGetValue(key, out num) && num == 0)
          return true;
      }
      return false;
    }

    private bool whiteSpacep(string c)
    {
      string key = c;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024map10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SExpReader.\u003C\u003Ef__switch\u0024map10 = new Dictionary<string, int>(6)
          {
            {
              " ",
              0
            },
            {
              "\b",
              0
            },
            {
              "\f",
              0
            },
            {
              "\r",
              0
            },
            {
              "\n",
              0
            },
            {
              "\t",
              0
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (SExpReader.\u003C\u003Ef__switch\u0024map10.TryGetValue(key, out num) && num == 0)
          return true;
      }
      return false;
    }

    private int removeWhiteSpace(int p)
    {
      while (this.whiteSpacep(this.readCharAt(this.str, p)))
        ++p;
      return p;
    }
  }
}
