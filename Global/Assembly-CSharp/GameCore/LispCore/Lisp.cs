// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.Lisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GameCore.LispCore
{
  public class Lisp
  {
    protected Dictionary<string, object> env;

    public Lisp()
    {
      this.env = new Dictionary<string, object>();
      this.definePrimitives();
      this.defunPrimitives();
    }

    public Lisp(Dictionary<string, object> e)
    {
      this.env = e;
      this.definePrimitives();
      this.defunPrimitives();
    }

    public object defun(string name, Func<List<object>, object> func, Dictionary<string, object> e = null)
    {
      if (e == null)
        this.env[name] = (object) func;
      else
        e[name] = (object) func;
      return (object) func;
    }

    private void defunFourArithmeticOperations(string exp)
    {
      string key = exp;
      if (key == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (Lisp.\u003C\u003Ef__switch\u0024mapC == null)
      {
        // ISSUE: reference to a compiler-generated field
        Lisp.\u003C\u003Ef__switch\u0024mapC = new Dictionary<string, int>(5)
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
      int num;
      // ISSUE: reference to a compiler-generated field
      if (!Lisp.\u003C\u003Ef__switch\u0024mapC.TryGetValue(key, out num))
        return;
      switch (num)
      {
        case 0:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable1 = args[0] as Decimal?;
            Decimal? nullable2 = args[1] as Decimal?;
            return nullable1.HasValue && nullable2.HasValue ? (!nullable1.HasValue || !nullable2.HasValue ? (object) new Decimal?() : (object) new Decimal?(nullable1.Value + nullable2.Value)) : (object) null;
          }));
          break;
        case 1:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable3 = args[0] as Decimal?;
            Decimal? nullable4 = args[1] as Decimal?;
            return nullable3.HasValue && nullable4.HasValue ? (!nullable3.HasValue || !nullable4.HasValue ? (object) new Decimal?() : (object) new Decimal?(nullable3.Value - nullable4.Value)) : (object) null;
          }));
          break;
        case 2:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable5 = args[0] as Decimal?;
            Decimal? nullable6 = args[1] as Decimal?;
            return nullable5.HasValue && nullable6.HasValue ? (!nullable5.HasValue || !nullable6.HasValue ? (object) new Decimal?() : (object) new Decimal?(nullable5.Value * nullable6.Value)) : (object) null;
          }));
          break;
        case 3:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable7 = args[0] as Decimal?;
            Decimal? nullable8 = args[1] as Decimal?;
            return nullable7.HasValue && nullable8.HasValue ? (!nullable7.HasValue || !nullable8.HasValue ? (object) new Decimal?() : (object) new Decimal?(nullable7.Value / nullable8.Value)) : (object) null;
          }));
          break;
        case 4:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable9 = args[0] as Decimal?;
            Decimal? nullable10 = args[1] as Decimal?;
            return nullable9.HasValue && nullable10.HasValue ? (!nullable9.HasValue || !nullable10.HasValue ? (object) new Decimal?() : (object) new Decimal?(nullable9.Value % nullable10.Value)) : (object) null;
          }));
          break;
      }
    }

    private void defunLogicalOperations(string exp)
    {
      string key = exp;
      if (key == null)
        return;
      // ISSUE: reference to a compiler-generated field
      if (Lisp.\u003C\u003Ef__switch\u0024mapD == null)
      {
        // ISSUE: reference to a compiler-generated field
        Lisp.\u003C\u003Ef__switch\u0024mapD = new Dictionary<string, int>(6)
        {
          {
            "and",
            0
          },
          {
            "or",
            1
          },
          {
            "<",
            2
          },
          {
            ">",
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
      if (!Lisp.\u003C\u003Ef__switch\u0024mapD.TryGetValue(key, out num))
        return;
      switch (num)
      {
        case 0:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            bool? nullable1 = args[0] as bool?;
            bool? nullable2 = args[1] as bool?;
            return nullable1.HasValue && nullable2.HasValue ? (object) new bool?(nullable1.Value && nullable2.Value) : (object) new bool?(false);
          }));
          break;
        case 1:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            bool? nullable3 = args[0] as bool?;
            bool? nullable4 = args[1] as bool?;
            return nullable3.HasValue && nullable4.HasValue ? (object) new bool?(nullable3.Value || nullable4.Value) : (object) new bool?(false);
          }));
          break;
        case 2:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable5 = args[0] as Decimal?;
            Decimal? nullable6 = args[1] as Decimal?;
            return nullable5.HasValue && nullable6.HasValue ? (object) new bool?(nullable5.HasValue && nullable6.HasValue && nullable5.Value < nullable6.Value) : (object) new bool?(false);
          }));
          break;
        case 3:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable7 = args[0] as Decimal?;
            Decimal? nullable8 = args[1] as Decimal?;
            return nullable7.HasValue && nullable8.HasValue ? (object) new bool?(nullable7.HasValue && nullable8.HasValue && nullable7.Value > nullable8.Value) : (object) new bool?(false);
          }));
          break;
        case 4:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable9 = args[0] as Decimal?;
            Decimal? nullable10 = args[1] as Decimal?;
            return nullable9.HasValue && nullable10.HasValue ? (object) new bool?(nullable9.GetValueOrDefault() == nullable10.GetValueOrDefault() && nullable9.HasValue == nullable10.HasValue) : (object) new bool?(false);
          }));
          break;
        case 5:
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            bool? nullable = args[0] as bool?;
            return nullable.HasValue ? (!nullable.HasValue ? (object) new bool?() : (object) new bool?(!nullable.Value)) : (object) new bool?(false);
          }));
          break;
      }
    }

    private void definePrimitives()
    {
      this.setq("true", (object) new bool?(true));
      this.setq("false", (object) new bool?(false));
    }

    private void defunPrimitives()
    {
      this.defun("car", (Func<List<object>, object>) (args => SExp.car(args[0])));
      this.defun("cdr", (Func<List<object>, object>) (args => SExp.cdr(args[0])));
      this.defun("cons", (Func<List<object>, object>) (args => (object) SExp.cons(args[0], args[1])));
      this.defun("atom", (Func<List<object>, object>) (args => (object) new bool?(SExp.atom_(args[0]))));
      this.defun("eq", (Func<List<object>, object>) (args => (object) new bool?(args[0].Equals(args[1]))));
      this.defun("list", (Func<List<object>, object>) (args => SExp.toLispList<object>((IEnumerable<object>) args)));
      this.defunFourArithmeticOperations("+");
      this.defunFourArithmeticOperations("-");
      this.defunFourArithmeticOperations("*");
      this.defunFourArithmeticOperations("/");
      this.defunFourArithmeticOperations("%");
      this.defunLogicalOperations("and");
      this.defunLogicalOperations("or");
      this.defunLogicalOperations("<");
      this.defunLogicalOperations(">");
      this.defunLogicalOperations("=");
      this.defunLogicalOperations("not");
    }

    public static bool symbolp_(object obj) => obj is string;

    public static bool? symbolp(object obj) => new bool?(obj is string);

    public static bool? functionp(object o)
    {
      return new bool?(o is Func<List<object>, object> || Lisp.lambdap_(o));
    }

    public static bool lambdap_(object lam) => SExp.car(lam) as string == "lambda";

    public static bool? lambdap(object lam) => Lisp.symbolEqual(SExp.car(lam), "lambda");

    private static bool? symbolEqual(object obj, string v) => new bool?(obj as string == v);

    public object symbolVal(string sym, Dictionary<string, object> e = null)
    {
      if (e != null && e.ContainsKey(sym))
        return e[sym];
      return this.env.ContainsKey(sym) ? this.env[sym] : (object) sym;
    }

    public object setq(string sym, object val, Dictionary<string, object> e = null)
    {
      if (e == null)
        this.env[sym] = val;
      else
        e[sym] = val;
      return val;
    }

    protected object applyPrimitive(Func<List<object>, object> func, object args)
    {
      return func(SExp.toCSList<object>(args));
    }

    protected object applyLambda(object lam, object args)
    {
      if (!Lisp.lambdap_(lam))
        return (object) null;
      Dictionary<string, object> e = new Dictionary<string, object>();
      for (object obj = SExp.car(SExp.cdr(lam)); SExp.consp_(obj); obj = SExp.cdr(obj))
      {
        e[SExp.car(obj) as string] = SExp.car(args);
        args = SExp.cdr(args);
      }
      return this.evalBody(SExp.cdr(SExp.cdr(lam)), e);
    }

    protected virtual object apply(object func, object args)
    {
      return func is Func<List<object>, object> ? this.applyPrimitive(func as Func<List<object>, object>, args) : this.applyLambda(func, args);
    }

    protected object evalCall(object func, object args, Dictionary<string, object> e)
    {
      if (func is string key)
      {
        if (key != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (Lisp.\u003C\u003Ef__switch\u0024mapE == null)
          {
            // ISSUE: reference to a compiler-generated field
            Lisp.\u003C\u003Ef__switch\u0024mapE = new Dictionary<string, int>(5)
            {
              {
                "quote",
                0
              },
              {
                "if",
                1
              },
              {
                "while",
                2
              },
              {
                "setq",
                3
              },
              {
                "defun",
                4
              }
            };
          }
          int num;
          // ISSUE: reference to a compiler-generated field
          if (Lisp.\u003C\u003Ef__switch\u0024mapE.TryGetValue(key, out num))
          {
            switch (num)
            {
              case 0:
                return SExp.car(args);
              case 1:
                bool? nullable1 = this.eval(SExp.car(args), e) as bool?;
                return (nullable1.HasValue ? (nullable1.Value ? 1 : 0) : 0) != 0 ? this.eval(SExp.car(SExp.cdr(args)), e) : this.evalBody(SExp.cdr(SExp.cdr(args)), e);
              case 2:
                object obj = (object) null;
                while (true)
                {
                  bool? nullable2 = this.eval(SExp.car(args), e) as bool?;
                  if ((nullable2.HasValue ? (nullable2.Value ? 1 : 0) : 0) != 0)
                    obj = this.evalBody(SExp.cdr(args), e);
                  else
                    break;
                }
                return obj;
              case 3:
                return this.setq(SExp.car(args) as string, this.eval(SExp.car(SExp.cdr(args)), e));
              case 4:
                return this.setq(SExp.car(args) as string, (object) SExp.cons((object) "lambda", (object) SExp.cons(SExp.car(SExp.cdr(args)), SExp.cdr(SExp.cdr(args)))));
            }
          }
        }
        return this.apply(this.eval(func, e), SExp.mapcar((Func<object, object>) (x => this.eval(x, e)), args));
      }
      return Lisp.lambdap_(func) ? this.applyLambda(func, SExp.mapcar((Func<object, object>) (x => this.eval(x, e)), args)) : (object) null;
    }

    public object eval(object sexp, Dictionary<string, object> e)
    {
      if (Lisp.symbolp_(sexp))
        return this.symbolVal(sexp as string, e);
      return SExp.atom_(sexp) ? sexp : this.evalCall(SExp.car(sexp), SExp.cdr(sexp), e);
    }

    public object evalBody(object sexp, Dictionary<string, object> e)
    {
      object obj1 = sexp;
      object obj2 = (object) null;
      for (; SExp.consp_(obj1); obj1 = SExp.cdr(obj1))
        obj2 = this.eval(SExp.car(obj1), e);
      return obj2;
    }

    public object evalTopLevel(object sexp) => this.eval(sexp, (Dictionary<string, object>) null);
  }
}
