// Decompiled with JetBrains decompiler
// Type: LuaClass
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LuaClass : MonoBehaviour
{
  private const string source = "\r\n        Account = { balance = 0 };\r\n        \r\n        function Account:new(o)    \r\n            o = o or {};\r\n            setmetatable(o, { __index = self });     \r\n            return o;  \r\n        end  \r\n  \r\n        function Account.deposit(self, v)  \r\n            self.balance = self.balance + v;  \r\n        end  \r\n  \r\n        function Account:withdraw(v)  \r\n            if (v) > self.balance then error 'insufficient funds'; end  \r\n            self.balance = self.balance - v;  \r\n        end \r\n\r\n        SpecialAccount = Account:new();\r\n\r\n        function SpecialAccount:withdraw(v)  \r\n            if v - self.balance >= self:getLimit() then  \r\n                error 'insufficient funds';  \r\n            end  \r\n            self.balance = self.balance - v;  \r\n        end  \r\n  \r\n        function SpecialAccount.getLimit(self)  \r\n            return self.limit or 0;  \r\n        end  \r\n\r\n        s = SpecialAccount:new{ limit = 1000 };\r\n        print(s.balance);  \r\n        s:deposit(100.00);\r\n\r\n        print (s.limit);  \r\n        print (s.getLimit(s))  \r\n        print (s.balance)  \r\n    ";

  private void Start()
  {
    LuaScriptMgr luaScriptMgr = new LuaScriptMgr();
    luaScriptMgr.Start();
    luaScriptMgr.lua.DoString("\r\n        Account = { balance = 0 };\r\n        \r\n        function Account:new(o)    \r\n            o = o or {};\r\n            setmetatable(o, { __index = self });     \r\n            return o;  \r\n        end  \r\n  \r\n        function Account.deposit(self, v)  \r\n            self.balance = self.balance + v;  \r\n        end  \r\n  \r\n        function Account:withdraw(v)  \r\n            if (v) > self.balance then error 'insufficient funds'; end  \r\n            self.balance = self.balance - v;  \r\n        end \r\n\r\n        SpecialAccount = Account:new();\r\n\r\n        function SpecialAccount:withdraw(v)  \r\n            if v - self.balance >= self:getLimit() then  \r\n                error 'insufficient funds';  \r\n            end  \r\n            self.balance = self.balance - v;  \r\n        end  \r\n  \r\n        function SpecialAccount.getLimit(self)  \r\n            return self.limit or 0;  \r\n        end  \r\n\r\n        s = SpecialAccount:new{ limit = 1000 };\r\n        print(s.balance);  \r\n        s:deposit(100.00);\r\n\r\n        print (s.limit);  \r\n        print (s.getLimit(s))  \r\n        print (s.balance)  \r\n    ");
  }

  private void Update()
  {
  }
}
