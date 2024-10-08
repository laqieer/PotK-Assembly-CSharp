﻿// Decompiled with JetBrains decompiler
// Type: GameCore.LispCore.Lisp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      if (!(exp == "+"))
      {
        if (!(exp == "-"))
        {
          if (!(exp == "*"))
          {
            if (!(exp == "/"))
            {
              if (!(exp == "%"))
                return;
              this.defun(exp, (Func<List<object>, object>) (args =>
              {
                Decimal? nullable1 = args[0] as Decimal?;
                Decimal? nullable2 = args[1] as Decimal?;
                if (!nullable1.HasValue || !nullable2.HasValue)
                  return (object) null;
                Decimal? nullable3 = nullable1;
                Decimal? nullable4 = nullable2;
                return nullable3.HasValue & nullable4.HasValue ? (object) new Decimal?(nullable3.GetValueOrDefault() % nullable4.GetValueOrDefault()) : (object) new Decimal?();
              }));
            }
            else
              this.defun(exp, (Func<List<object>, object>) (args =>
              {
                Decimal? nullable1 = args[0] as Decimal?;
                Decimal? nullable2 = args[1] as Decimal?;
                if (!nullable1.HasValue || !nullable2.HasValue)
                  return (object) null;
                Decimal? nullable3 = nullable1;
                Decimal? nullable4 = nullable2;
                return nullable3.HasValue & nullable4.HasValue ? (object) new Decimal?(nullable3.GetValueOrDefault() / nullable4.GetValueOrDefault()) : (object) new Decimal?();
              }));
          }
          else
            this.defun(exp, (Func<List<object>, object>) (args =>
            {
              Decimal? nullable1 = args[0] as Decimal?;
              Decimal? nullable2 = args[1] as Decimal?;
              if (!nullable1.HasValue || !nullable2.HasValue)
                return (object) null;
              Decimal? nullable3 = nullable1;
              Decimal? nullable4 = nullable2;
              return nullable3.HasValue & nullable4.HasValue ? (object) new Decimal?(nullable3.GetValueOrDefault() * nullable4.GetValueOrDefault()) : (object) new Decimal?();
            }));
        }
        else
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            Decimal? nullable1 = args[0] as Decimal?;
            Decimal? nullable2 = args[1] as Decimal?;
            if (!nullable1.HasValue || !nullable2.HasValue)
              return (object) null;
            Decimal? nullable3 = nullable1;
            Decimal? nullable4 = nullable2;
            return nullable3.HasValue & nullable4.HasValue ? (object) new Decimal?(nullable3.GetValueOrDefault() - nullable4.GetValueOrDefault()) : (object) new Decimal?();
          }));
      }
      else
        this.defun(exp, (Func<List<object>, object>) (args =>
        {
          Decimal? nullable1 = args[0] as Decimal?;
          Decimal? nullable2 = args[1] as Decimal?;
          if (!nullable1.HasValue || !nullable2.HasValue)
            return (object) null;
          Decimal? nullable3 = nullable1;
          Decimal? nullable4 = nullable2;
          return nullable3.HasValue & nullable4.HasValue ? (object) new Decimal?(nullable3.GetValueOrDefault() + nullable4.GetValueOrDefault()) : (object) new Decimal?();
        }));
    }

    private void defunLogicalOperations(string exp)
    {
      if (!(exp == "and"))
      {
        if (!(exp == "or"))
        {
          if (!(exp == "<"))
          {
            if (!(exp == ">"))
            {
              if (!(exp == "="))
              {
                if (!(exp == "not"))
                  return;
                this.defun(exp, (Func<List<object>, object>) (args =>
                {
                  bool? nullable1 = args[0] as bool?;
                  if (!nullable1.HasValue)
                    return (object) false;
                  bool? nullable2 = nullable1;
                  return nullable2.HasValue ? (object) new bool?(!nullable2.GetValueOrDefault()) : (object) new bool?();
                }));
              }
              else
                this.defun(exp, (Func<List<object>, object>) (args =>
                {
                  Decimal? nullable1 = args[0] as Decimal?;
                  Decimal? nullable2 = args[1] as Decimal?;
                  if (!nullable1.HasValue || !nullable2.HasValue)
                    return (object) false;
                  Decimal? nullable3 = nullable1;
                  Decimal? nullable4 = nullable2;
                  return (object) (nullable3.GetValueOrDefault() == nullable4.GetValueOrDefault() & nullable3.HasValue == nullable4.HasValue);
                }));
            }
            else
              this.defun(exp, (Func<List<object>, object>) (args =>
              {
                Decimal? nullable1 = args[0] as Decimal?;
                Decimal? nullable2 = args[1] as Decimal?;
                if (!nullable1.HasValue || !nullable2.HasValue)
                  return (object) false;
                Decimal? nullable3 = nullable1;
                Decimal? nullable4 = nullable2;
                return (object) (nullable3.GetValueOrDefault() > nullable4.GetValueOrDefault() & (nullable3.HasValue & nullable4.HasValue));
              }));
          }
          else
            this.defun(exp, (Func<List<object>, object>) (args =>
            {
              Decimal? nullable1 = args[0] as Decimal?;
              Decimal? nullable2 = args[1] as Decimal?;
              if (!nullable1.HasValue || !nullable2.HasValue)
                return (object) false;
              Decimal? nullable3 = nullable1;
              Decimal? nullable4 = nullable2;
              return (object) (nullable3.GetValueOrDefault() < nullable4.GetValueOrDefault() & (nullable3.HasValue & nullable4.HasValue));
            }));
        }
        else
          this.defun(exp, (Func<List<object>, object>) (args =>
          {
            bool? nullable1 = args[0] as bool?;
            bool? nullable2 = args[1] as bool?;
            return nullable1.HasValue && nullable2.HasValue ? (nullable1.Value ? (object) true : (nullable2.Value ? (object) true : (object) false)) : (object) false;
          }));
      }
      else
        this.defun(exp, (Func<List<object>, object>) (args =>
        {
          bool? nullable1 = args[0] as bool?;
          bool? nullable2 = args[1] as bool?;
          return nullable1.HasValue && nullable2.HasValue ? (!nullable1.Value ? (object) false : (nullable2.Value ? (object) true : (object) false)) : (object) false;
        }));
    }

    private void definePrimitives()
    {
      this.setq("true", (object) true);
      this.setq("false", (object) false);
    }

    private void defunPrimitives()
    {
      this.defun("car", (Func<List<object>, object>) (args => SExp.car(args[0])));
      this.defun("cdr", (Func<List<object>, object>) (args => SExp.cdr(args[0])));
      this.defun("cons", (Func<List<object>, object>) (args => (object) SExp.cons(args[0], args[1])));
      this.defun("atom", (Func<List<object>, object>) (args => (object) SExp.atom_(args[0])));
      this.defun("eq", (Func<List<object>, object>) (args => (object) args[0].Equals(args[1])));
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

    public static bool? functionp(object o) => new bool?(o is Func<List<object>, object> || Lisp.lambdap_(o));

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

    protected object applyPrimitive(Func<List<object>, object> func, object args) => func(SExp.toCSList<object>(args));

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

    protected virtual object apply(object func, object args) => func is Func<List<object>, object> ? this.applyPrimitive(func as Func<List<object>, object>, args) : this.applyLambda(func, args);

    protected object evalCall(object func, object args, Dictionary<string, object> e)
    {
      if (func is string str)
      {
        if (str == "quote")
          return SExp.car(args);
        if (!(str == "if"))
        {
          if (!(str == "while"))
          {
            if (str == "setq")
              return this.setq(SExp.car(args) as string, this.eval(SExp.car(SExp.cdr(args)), e));
            return str == "defun" ? this.setq(SExp.car(args) as string, (object) SExp.cons((object) "lambda", (object) SExp.cons(SExp.car(SExp.cdr(args)), SExp.cdr(SExp.cdr(args))))) : this.apply(this.eval(func, e), SExp.mapcar((Func<object, object>) (x => this.eval(x, e)), args));
          }
          object obj = (object) null;
          while (true)
          {
            bool? nullable = this.eval(SExp.car(args), e) as bool?;
            if ((!nullable.HasValue ? 0 : (nullable.Value ? 1 : 0)) != 0)
              obj = this.evalBody(SExp.cdr(args), e);
            else
              break;
          }
          return obj;
        }
        bool? nullable1 = this.eval(SExp.car(args), e) as bool?;
        return (!nullable1.HasValue ? 0 : (nullable1.Value ? 1 : 0)) != 0 ? this.eval(SExp.car(SExp.cdr(args)), e) : this.evalBody(SExp.cdr(SExp.cdr(args)), e);
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
