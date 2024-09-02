// Decompiled with JetBrains decompiler
// Type: GameCore.IELisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace GameCore
{
  public class IELisp
  {
    protected Stack<Dictionary<string, object>> envStack;
    protected Dictionary<string, object> globalEnv;
    protected readonly Dictionary<int, Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>> specialForms;
    public SExpNumber numberDic;
    public object trueObject = new object();
    public int applyCount;
    protected Stopwatch timer;
    protected long thresholdMS;
    protected Stack<object> evalStack;
    public string error;
    public List<object> errorObjects;

    public IELisp(SExpNumber ndic)
    {
      this.envStack = new Stack<Dictionary<string, object>>();
      this.globalEnv = new Dictionary<string, object>();
      this.evalStack = new Stack<object>();
      this.envStack.Push(this.globalEnv);
      this.defineIEPrimitives();
      this.defunIEPrimitives();
      this.numberDic = ndic;
      this.specialForms = new Dictionary<int, Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>>()
      {
        {
          "quote".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_quote)
        },
        {
          "and".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_and)
        },
        {
          "or".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_or)
        },
        {
          "if".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_if)
        },
        {
          "while".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_while)
        },
        {
          "foreach".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_foreach)
        },
        {
          "progn".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_progn)
        },
        {
          "setq".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_setq)
        },
        {
          "defun".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_defun)
        },
        {
          "let".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_let)
        },
        {
          "mapcar".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_mapcar)
        },
        {
          "eval".GetHashCode(),
          new Func<object, Stack<Dictionary<string, object>>, IELisp.ReturnObject, IEnumerator>(this.sf_eval)
        }
      };
    }

    protected bool checkArgLen(string func, Cons args, int len)
    {
      if (SExp.length((object) args) >= len)
        return true;
      this.setArgumentError(func, len);
      return false;
    }

    public static Cons nthCons(int idx, Cons l)
    {
      switch (idx)
      {
        case 0:
          return l;
        case 1:
          return l.cdr as Cons;
        case 2:
          return l.cdr is Cons cdr1 ? cdr1.cdr as Cons : (Cons) null;
        case 3:
          return l.cdr is Cons cdr2 && cdr2.cdr is Cons cdr3 ? cdr3.cdr as Cons : (Cons) null;
        case 4:
          return l.cdr is Cons cdr4 && cdr4.cdr is Cons cdr5 && cdr5.cdr is Cons cdr6 ? cdr6.cdr as Cons : (Cons) null;
        default:
          return IELisp.nthCons(idx - 4, IELisp.nthCons(4, l));
      }
    }

    public object nth(int idx, Cons l)
    {
      if (l == null)
        return (object) null;
      return IELisp.nthCons(idx, l)?.car;
    }

    protected T checkType<T>(string func, object v)
    {
      if (v is T obj)
        return obj;
      this.setError(func + ":引数 (" + v + ") 型エラー (" + (object) typeof (T) + ")", (object) func, v);
      throw new Exception(this.error);
    }

    protected T checkType<T>(string func, Cons args, int idx)
    {
      if (SExp.length((object) args) <= idx)
        return (T) this.setArgumentError(func, idx);
      return this.nth(idx, args) is T obj ? obj : (T) this.setTypeError<T>(func, args, idx);
    }

    protected object setTypeError<T>(string func, Cons args, int idx)
    {
      this.setError(func + ":引数[" + (object) idx + "] 型エラー (" + (object) typeof (T) + ")", (object) func, this.nth(idx, args));
      throw new Exception(this.error);
    }

    protected object setArgumentError(string func, int idx)
    {
      this.setError(func + ":引数の数が合っていない", (object) func, (object) idx);
      throw new Exception(this.error);
    }

    public static bool symbolp_(object obj) => obj is string;

    public static bool lambdap_(object lam) => SExp.car(lam) as string == "lambda";

    public object defun(string name, Func<Cons, object> func)
    {
      this.globalEnv[name] = (object) func;
      return (object) func;
    }

    public object setq(string sym, object val, Stack<Dictionary<string, object>> es = null)
    {
      if (es != null)
      {
        foreach (Dictionary<string, object> e in es)
        {
          if (e.ContainsKey(sym))
          {
            object obj = val;
            e[sym] = obj;
            return obj;
          }
        }
      }
      object obj1 = val;
      this.globalEnv[sym] = obj1;
      return obj1;
    }

    private void defineIEPrimitives()
    {
      this.setq("t", this.trueObject);
      this.setq("nil", (object) null);
    }

    private void defunIEFourArithmeticOperations(string exp)
    {
      string key = exp;
      if (key == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (IELisp.\u003C\u003Ef__switch\u0024map2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        IELisp.\u003C\u003Ef__switch\u0024map2 = new Dictionary<string, int>(5)
        {
          {
            "+",
            0
          },
          {
            "-",
            1
          },
          {
            "*",
            2
          },
          {
            "/",
            3
          },
          {
            "%",
            4
          }
        };
      }
      int num1;
      // ISSUE: reference to a compiler-generated field
      if (!IELisp.\u003C\u003Ef__switch\u0024map2.TryGetValue(key, out num1))
        return;
      switch (num1)
      {
        case 0:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            float f = (float) this.checkType<Decimal?>(exp, args, 0).Value;
            for (Cons cdr = args.cdr as Cons; cdr != null; cdr = cdr.cdr as Cons)
            {
              float num2 = (float) this.checkType<Decimal?>(exp, cdr.car).Value;
              f += num2;
            }
            return (object) this.numberDic.numberObject(f);
          }));
          break;
        case 1:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            float f = (float) this.checkType<Decimal?>(exp, args, 0).Value;
            for (Cons cdr = args.cdr as Cons; cdr != null; cdr = cdr.cdr as Cons)
            {
              float num3 = (float) this.checkType<Decimal?>(exp, cdr.car).Value;
              f -= num3;
            }
            return (object) this.numberDic.numberObject(f);
          }));
          break;
        case 2:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            float f = (float) this.checkType<Decimal?>(exp, args, 0).Value;
            for (Cons cdr = args.cdr as Cons; cdr != null; cdr = cdr.cdr as Cons)
            {
              float num4 = (float) this.checkType<Decimal?>(exp, cdr.car).Value;
              f *= num4;
            }
            return (object) this.numberDic.numberObject(f);
          }));
          break;
        case 3:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            float f = (float) this.checkType<Decimal?>(exp, args, 0).Value;
            for (Cons cdr = args.cdr as Cons; cdr != null; cdr = cdr.cdr as Cons)
            {
              float num5 = (float) this.checkType<Decimal?>(exp, cdr.car).Value;
              f /= num5;
            }
            return (object) this.numberDic.numberObject(f);
          }));
          break;
        case 4:
          this.defun(exp, (Func<Cons, object>) (args => (object) this.numberDic.numberObject((float) this.checkType<Decimal?>(exp, args, 0).Value % (float) this.checkType<Decimal?>(exp, args, 1).Value)));
          break;
      }
    }

    private void defunIELogicalOperations(string exp)
    {
      string key = exp;
      if (key == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (IELisp.\u003C\u003Ef__switch\u0024map3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        IELisp.\u003C\u003Ef__switch\u0024map3 = new Dictionary<string, int>(6)
        {
          {
            "<",
            0
          },
          {
            ">",
            1
          },
          {
            "<=",
            2
          },
          {
            ">=",
            3
          },
          {
            "=",
            4
          },
          {
            "not",
            5
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (!IELisp.\u003C\u003Ef__switch\u0024map3.TryGetValue(key, out num))
        return;
      switch (num)
      {
        case 0:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 2))
              return (object) null;
            return (double) (float) this.checkType<Decimal?>(exp, args, 0).Value < (double) (float) this.checkType<Decimal?>(exp, args, 1).Value ? this.trueObject : (object) null;
          }));
          break;
        case 1:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 2))
              return (object) null;
            return (double) (float) this.checkType<Decimal?>(exp, args, 0).Value > (double) (float) this.checkType<Decimal?>(exp, args, 1).Value ? this.trueObject : (object) null;
          }));
          break;
        case 2:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 2))
              return (object) null;
            return (double) (float) this.checkType<Decimal?>(exp, args, 0).Value <= (double) (float) this.checkType<Decimal?>(exp, args, 1).Value ? this.trueObject : (object) null;
          }));
          break;
        case 3:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 2))
              return (object) null;
            return (double) (float) this.checkType<Decimal?>(exp, args, 0).Value >= (double) (float) this.checkType<Decimal?>(exp, args, 1).Value ? this.trueObject : (object) null;
          }));
          break;
        case 4:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 2))
              return (object) null;
            return this.checkType<Decimal?>(exp, args, 0).Value == this.checkType<Decimal?>(exp, args, 1).Value ? this.trueObject : (object) null;
          }));
          break;
        case 5:
          this.defun(exp, (Func<Cons, object>) (args =>
          {
            if (!this.checkArgLen(exp, args, 1))
              return (object) null;
            return args.car == null ? this.trueObject : (object) null;
          }));
          break;
      }
    }

    private void defunIEPrimitives()
    {
      this.defun("car", (Func<Cons, object>) (args => this.checkArgLen("car", args, 1) ? SExp.car(args.car) : (object) null));
      this.defun("cdr", (Func<Cons, object>) (args => this.checkArgLen("cdr", args, 1) ? SExp.cdr(args.car) : (object) null));
      this.defun("cons", (Func<Cons, object>) (args => this.checkArgLen("cons", args, 2) ? (object) SExp.cons(args.car, this.nth(1, args)) : (object) null));
      this.defun("consp", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("consp", args, 1))
          return (object) null;
        object car = args.car;
        return car == null || SExp.consp_(car) ? this.trueObject : (object) null;
      }));
      this.defun("atom", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("atom", args, 1))
          return (object) null;
        return SExp.atom_(args.car) ? this.trueObject : (object) null;
      }));
      this.defun("eq", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("eq", args, 2))
          return (object) null;
        return args.car.Equals(this.nth(1, args)) ? this.trueObject : (object) null;
      }));
      this.defun("list", (Func<Cons, object>) (args => (object) args));
      this.defun("length", (Func<Cons, object>) (args => this.checkArgLen("length", args, 1) ? (object) this.numberDic.numberObject(SExp.length(args.car)) : (object) null));
      this.defunIEFourArithmeticOperations("+");
      this.defunIEFourArithmeticOperations("-");
      this.defunIEFourArithmeticOperations("*");
      this.defunIEFourArithmeticOperations("/");
      this.defunIEFourArithmeticOperations("%");
      this.defunIELogicalOperations("<");
      this.defunIELogicalOperations(">");
      this.defunIELogicalOperations("=");
      this.defunIELogicalOperations("not");
      this.defunIELogicalOperations(">=");
      this.defunIELogicalOperations("<=");
      this.defun("nth", (Func<Cons, object>) (args => this.checkArgLen("nth", args, 2) ? this.nth((int) this.checkType<Decimal?>("nth", args, 0).Value, this.nth(1, args) as Cons) : (object) null));
      this.defun("tail", (Func<Cons, object>) (args => this.checkArgLen("tail", args, 1) ? SExp.car((object) SExp.lastCons(args.car)) : (object) null));
      this.defun("union", (Func<Cons, object>) (args => this.checkArgLen("union", args, 2) ? SExp.union(args.car, this.nth(1, args)) : (object) null));
      this.defun("intersection", (Func<Cons, object>) (args => this.checkArgLen("intersection", args, 2) ? SExp.intersection(args.car, this.nth(1, args)) : (object) null));
      this.defun("set-difference", (Func<Cons, object>) (args => this.checkArgLen("set-difference", args, 2) ? SExp.setDifference(args.car, this.nth(1, args)) : (object) null));
      this.defun("member", (Func<Cons, object>) (args => this.checkArgLen("member", args, 2) ? SExp.member(args.car, this.nth(1, args)) : (object) null));
      this.defun("remove", (Func<Cons, object>) (args => this.checkArgLen("remove", args, 2) ? (object) SExp.remove_(args.car, this.nth(1, args)) : (object) null));
      this.defun("append", (Func<Cons, object>) (args => SExp.append(args)));
      this.defun("assoc", (Func<Cons, object>) (args => this.checkArgLen("assoc", args, 2) ? SExp.assoc(args.car, this.nth(1, args)) : (object) null));
      this.defun("numberp", (Func<Cons, object>) (args =>
      {
        if (!this.checkArgLen("numberp", args, 1))
          return (object) null;
        return args.car is Decimal? ? this.trueObject : (object) null;
      }));
      this.defun("print", (Func<Cons, object>) (args =>
      {
        SExpString sexpString1 = this.checkType<SExpString>("print", args, 0);
        string str = string.Empty;
        for (Cons cdr = args.cdr as Cons; cdr != null; cdr = cdr.cdr as Cons)
        {
          object car = cdr.car;
          if (car is SExpString)
          {
            SExpString sexpString2 = car as SExpString;
            str += sexpString2.strValue;
          }
          else
            str = car != null ? (car != this.trueObject ? str + car : str + "t") : str + "nil";
        }
        return (object) (sexpString1.strValue + str);
      }));
    }

    protected virtual void setError(string e, params object[] args)
    {
      this.error = e + "\nLast S-Expression:" + this.evalStack.Peek();
      if (this.errorObjects == null)
        this.errorObjects = new List<object>();
      foreach (object obj in args)
        this.errorObjects.Add(obj);
    }

    protected virtual object symbolValE(string sym, Stack<Dictionary<string, object>> es)
    {
      foreach (Dictionary<string, object> e in es)
      {
        if (e.ContainsKey(sym))
          return e[sym];
      }
      this.setError("未定義シンボルを参照", (object) sym);
      return (object) null;
    }

    protected object applyPrimitiveE(Func<Cons, object> func, object args) => func(args as Cons);

    [DebuggerHidden]
    private IEnumerator applyE(
      object func,
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CapplyE\u003Ec__Iterator5()
      {
        func = func,
        args = args,
        ret = ret,
        es = es,
        \u003C\u0024\u003Efunc = func,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Eret = ret,
        \u003C\u0024\u003Ees = es,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator evalArgsE(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CevalArgsE\u003Ec__Iterator6()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_quote(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_quote\u003Ec__Iterator7()
      {
        args = args,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Eret = ret
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_and(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_and\u003Ec__Iterator8()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_or(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_or\u003Ec__Iterator9()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_if(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_if\u003Ec__IteratorA()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_while(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_while\u003Ec__IteratorB()
      {
        ret = ret,
        args = args,
        es = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_foreach(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_foreach\u003Ec__IteratorC()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_progn(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_progn\u003Ec__IteratorD()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_setq(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_setq\u003Ec__IteratorE()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_defun(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_defun\u003Ec__IteratorF()
      {
        args = args,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_let(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_let\u003Ec__Iterator10()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_mapcar(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_mapcar\u003Ec__Iterator11()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator sf_eval(
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003Csf_eval\u003Ec__Iterator12()
      {
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator evalCallE(
      object func,
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CevalCallE\u003Ec__Iterator13()
      {
        func = func,
        args = args,
        es = es,
        ret = ret,
        \u003C\u0024\u003Efunc = func,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator applyLambdaE(
      object lam,
      object args,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CapplyLambdaE\u003Ec__Iterator14()
      {
        lam = lam,
        ret = ret,
        args = args,
        es = es,
        \u003C\u0024\u003Elam = lam,
        \u003C\u0024\u003Eret = ret,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Ees = es,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator evalE(
      object sexp,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CevalE\u003Ec__Iterator15()
      {
        sexp = sexp,
        es = es,
        ret = ret,
        \u003C\u0024\u003Esexp = sexp,
        \u003C\u0024\u003Ees = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator evalBodyE(
      object sexp,
      Stack<Dictionary<string, object>> es,
      IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CevalBodyE\u003Ec__Iterator16()
      {
        ret = ret,
        sexp = sexp,
        es = es,
        \u003C\u0024\u003Eret = ret,
        \u003C\u0024\u003Esexp = sexp,
        \u003C\u0024\u003Ees = es,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator topLevelCallE(object func, object args, IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CtopLevelCallE\u003Ec__Iterator17()
      {
        func = func,
        args = args,
        ret = ret,
        \u003C\u0024\u003Efunc = func,
        \u003C\u0024\u003Eargs = args,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator evalTopLevelE(object sexp, IELisp.ReturnObject ret)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new IELisp.\u003CevalTopLevelE\u003Ec__Iterator18()
      {
        sexp = sexp,
        ret = ret,
        \u003C\u0024\u003Esexp = sexp,
        \u003C\u0024\u003Eret = ret,
        \u003C\u003Ef__this = this
      };
    }

    public class ReturnObject
    {
      public object value;
    }
  }
}
