// Decompiled with JetBrains decompiler
// Type: Net.AppPeer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using GameCore.Stat;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
namespace Net
{
  public class AppPeer : Peer
  {
    [DebuggerHidden]
    private IEnumerator ReceiveUntilF(
      int timeoutMilliseconds,
      Func<AppPeer.ReceivedMessage, bool> pred,
      Promise<AppPeer.ReceivedMessage> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new AppPeer.\u003CReceiveUntilF\u003Ec__IteratorB72()
      {
        timeoutMilliseconds = timeoutMilliseconds,
        pred = pred,
        promise = promise,
        \u003C\u0024\u003EtimeoutMilliseconds = timeoutMilliseconds,
        \u003C\u0024\u003Epred = pred,
        \u003C\u0024\u003Epromise = promise,
        \u003C\u003Ef__this = this
      };
    }

    public Future<AppPeer.ReceivedMessage> ReceiveUntil(
      int timeoutMilliseconds,
      Func<AppPeer.ReceivedMessage, bool> pred)
    {
      return new Future<AppPeer.ReceivedMessage>((Func<Promise<AppPeer.ReceivedMessage>, IEnumerator>) (promise => this.ReceiveUntilF(timeoutMilliseconds, pred, promise)));
    }

    public Future<AppPeer.ReceivedMessage> ReceiveOps(params AppServerOperation[] ops)
    {
      return this.ReceiveUntil(-1, (Func<AppPeer.ReceivedMessage, bool>) (r => ((IEnumerable<AppServerOperation>) ops).Any<AppServerOperation>((Func<AppServerOperation, bool>) (c => r.Error != null || c == (AppServerOperation) r.Header.Type))));
    }

    public Future<AppPeer.ReceivedMessage> ReceiveOps(
      int timeoutMilliseconds,
      params AppServerOperation[] ops)
    {
      return this.ReceiveUntil(timeoutMilliseconds, (Func<AppPeer.ReceivedMessage, bool>) (r => ((IEnumerable<AppServerOperation>) ops).Any<AppServerOperation>((Func<AppServerOperation, bool>) (c => r.Error != null || c == (AppServerOperation) r.Header.Type))));
    }

    [DebuggerHidden]
    private IEnumerator ReceiveTypeE(
      int timeoutMilliseconds,
      Promise<AppPeer.ReceivedMessage> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new AppPeer.\u003CReceiveTypeE\u003Ec__IteratorB73()
      {
        timeoutMilliseconds = timeoutMilliseconds,
        promise = promise,
        \u003C\u0024\u003EtimeoutMilliseconds = timeoutMilliseconds,
        \u003C\u0024\u003Epromise = promise,
        \u003C\u003Ef__this = this
      };
    }

    public Future<AppPeer.ReceivedMessage> ReceiveType(int timeoutMilliseconds = -1)
    {
      return new Future<AppPeer.ReceivedMessage>((Func<Promise<AppPeer.ReceivedMessage>, IEnumerator>) (promise => this.ReceiveTypeE(timeoutMilliseconds, promise)));
    }

    [DebuggerHidden]
    private IEnumerator SendNothrowE(Func<Future<int>> send, Promise<AppPeer.SendMessage> promise)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new AppPeer.\u003CSendNothrowE\u003Ec__IteratorB74()
      {
        send = send,
        promise = promise,
        \u003C\u0024\u003Esend = send,
        \u003C\u0024\u003Epromise = promise
      };
    }

    public Future<AppPeer.SendMessage> SendNothrow(Func<Future<int>> send)
    {
      return new Future<AppPeer.SendMessage>((Func<Promise<AppPeer.SendMessage>, IEnumerator>) (promise => this.SendNothrowE(send, promise)));
    }

    public Future<AppPeer.SendMessage> StatRequest()
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[0], new object[0], 0);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(0, args, 5000)));
    }

    public Future<AppPeer.SendMessage> JoinRoom(string battleToken)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[1]
      {
        nameof (battleToken)
      }, new object[1]{ (object) battleToken }, 1);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(1, args, 5000)));
    }

    public Future<AppPeer.SendMessage> ReadyCompleted()
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[0], new object[0], 0);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(2, args, 5000)));
    }

    public Future<AppPeer.SendMessage> LocateUnitsCompleted(Tuple<int, int, int>[] unitPositions)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[1]
      {
        nameof (unitPositions)
      }, new object[1]{ (object) unitPositions }, 1);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(3, args, 5000)));
    }

    public Future<AppPeer.SendMessage> TurnInitializeCompleted()
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[0], new object[0], 0);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(4, args, 5000)));
    }

    public Future<AppPeer.SendMessage> MoveUnitTimeout(int? currentUnitPositionId)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[1]
      {
        nameof (currentUnitPositionId)
      }, new object[1]{ (object) currentUnitPositionId }, 1);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(5, args, 5000)));
    }

    public Future<AppPeer.SendMessage> MoveUnit(int unitPositionId, int row, int column)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[3]
      {
        nameof (column),
        nameof (row),
        nameof (unitPositionId)
      }, new object[3]
      {
        (object) column,
        (object) row,
        (object) unitPositionId
      }, 3);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(6, args, 5000)));
    }

    public Future<AppPeer.SendMessage> MoveUnitWithAttack(
      int unitPositionId,
      int row,
      int column,
      int targetUnitPositionId,
      bool isHeal,
      int attackStatusIndex)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[6]
      {
        nameof (attackStatusIndex),
        nameof (column),
        nameof (isHeal),
        nameof (row),
        nameof (targetUnitPositionId),
        nameof (unitPositionId)
      }, new object[6]
      {
        (object) attackStatusIndex,
        (object) column,
        (object) isHeal,
        (object) row,
        (object) targetUnitPositionId,
        (object) unitPositionId
      }, 6);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(7, args, 5000)));
    }

    public Future<AppPeer.SendMessage> MoveUnitWithSkill(
      int unitPositionId,
      int row,
      int column,
      int[] targetUnitPositionIds,
      int skillId)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[5]
      {
        nameof (column),
        nameof (row),
        nameof (skillId),
        nameof (targetUnitPositionIds),
        nameof (unitPositionId)
      }, new object[5]
      {
        (object) column,
        (object) row,
        (object) skillId,
        (object) targetUnitPositionIds,
        (object) unitPositionId
      }, 5);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(8, args, 5000)));
    }

    public Future<AppPeer.SendMessage> ActionUnitCompleted()
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[0], new object[0], 0);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(9, args, 5000)));
    }

    public Future<AppPeer.SendMessage> WipedOutCompleted()
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[0], new object[0], 0);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(10, args, 5000)));
    }

    public Future<AppPeer.SendMessage> RecoveryRequest(string battleToken)
    {
      AssocList<string, object> args = new AssocList<string, object>(new string[1]
      {
        nameof (battleToken)
      }, new object[1]{ (object) battleToken }, 1);
      return this.SendNothrow((Func<Future<int>>) (() => this.Send(11, args, 5000)));
    }

    [Serializable]
    public class Stat
    {
      public GameServerStat stat;

      public override string ToString()
      {
        return "Stat(" + string.Format("stat={0}, ", this.stat == null ? (object) "[null]" : (object) this.stat.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["stat"] = (object) this.stat
        };
      }
    }

    [Serializable]
    public class Ready
    {
      public byte[] buffer;
      public int order;

      public override string ToString()
      {
        return "Ready(" + string.Format("buffer={0}, ", this.buffer == null ? (object) "[null]" : (object) this.buffer.ToString()) + string.Format("order={0}, ", (object) this.order.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["buffer"] = (object) this.buffer,
          ["order"] = (object) this.order
        };
      }
    }

    [Serializable]
    public class LocateUnits
    {
      public int locationTimeoutMilliseconds;

      public override string ToString()
      {
        return "LocateUnits(" + string.Format("locationTimeoutMilliseconds={0}, ", (object) this.locationTimeoutMilliseconds.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["locationTimeoutMilliseconds"] = (object) this.locationTimeoutMilliseconds
        };
      }
    }

    [Serializable]
    public class GameInitialize
    {
      public Tuple<int, int, int>[] unitPositions;

      public override string ToString()
      {
        return "GameInitialize(" + string.Format("unitPositions={0}, ", this.unitPositions == null ? (object) "[null]" : (object) this.unitPositions.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["unitPositions"] = (object) this.unitPositions
        };
      }
    }

    [Serializable]
    public class TurnInitialize
    {
      public int remainTurn;
      public Tuple<int, int, int>[] respawnUnitPositions;
      public int[] points;
      public Tuple<int, int>[] deadUnitRespawnCounts;

      public override string ToString()
      {
        return "TurnInitialize(" + string.Format("remainTurn={0}, ", (object) this.remainTurn.ToString()) + string.Format("respawnUnitPositions={0}, ", this.respawnUnitPositions == null ? (object) "[null]" : (object) this.respawnUnitPositions.ToString()) + string.Format("points={0}, ", this.points == null ? (object) "[null]" : (object) this.points.ToString()) + string.Format("deadUnitRespawnCounts={0}, ", this.deadUnitRespawnCounts == null ? (object) "[null]" : (object) this.deadUnitRespawnCounts.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["remainTurn"] = (object) this.remainTurn,
          ["respawnUnitPositions"] = (object) this.respawnUnitPositions,
          ["points"] = (object) this.points,
          ["deadUnitRespawnCounts"] = (object) this.deadUnitRespawnCounts
        };
      }
    }

    [Serializable]
    public class MoveUnitRequest
    {
      public int order;
      public int moveTimeoutMilliseconds;

      public override string ToString()
      {
        return "MoveUnitRequest(" + string.Format("order={0}, ", (object) this.order.ToString()) + string.Format("moveTimeoutMilliseconds={0}, ", (object) this.moveTimeoutMilliseconds.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["order"] = (object) this.order,
          ["moveTimeoutMilliseconds"] = (object) this.moveTimeoutMilliseconds
        };
      }
    }

    [Serializable]
    public class ActionUnit
    {
      public BL.AIUnitNetwork aiUnit;
      public int[] points;
      public Tuple<int, int>[] deadUnitRespawnCounts;

      public override string ToString()
      {
        return "ActionUnit(" + string.Format("aiUnit={0}, ", this.aiUnit == null ? (object) "[null]" : (object) this.aiUnit.ToString()) + string.Format("points={0}, ", this.points == null ? (object) "[null]" : (object) this.points.ToString()) + string.Format("deadUnitRespawnCounts={0}, ", this.deadUnitRespawnCounts == null ? (object) "[null]" : (object) this.deadUnitRespawnCounts.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["aiUnit"] = (object) this.aiUnit,
          ["points"] = (object) this.points,
          ["deadUnitRespawnCounts"] = (object) this.deadUnitRespawnCounts
        };
      }
    }

    [Serializable]
    public class WipedOut
    {
      public bool[] isWipedOuts;
      public int[] points;

      public override string ToString()
      {
        return "WipedOut(" + string.Format("isWipedOuts={0}, ", this.isWipedOuts == null ? (object) "[null]" : (object) this.isWipedOuts.ToString()) + string.Format("points={0}, ", this.points == null ? (object) "[null]" : (object) this.points.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["isWipedOuts"] = (object) this.isWipedOuts,
          ["points"] = (object) this.points
        };
      }
    }

    [Serializable]
    public class FinishBattle
    {
      public PvpVictoryEffectEnum[] victoryEffects;

      public override string ToString()
      {
        return "FinishBattle(" + string.Format("victoryEffects={0}, ", this.victoryEffects == null ? (object) "[null]" : (object) this.victoryEffects.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["victoryEffects"] = (object) this.victoryEffects
        };
      }
    }

    [Serializable]
    public class Recovery
    {
      public RecoveryType recovery;

      public override string ToString()
      {
        return "Recovery(" + string.Format("recovery={0}, ", this.recovery == null ? (object) "[null]" : (object) this.recovery.ToString()) + ")";
      }

      public Dictionary<string, object> ToJson()
      {
        return new Dictionary<string, object>()
        {
          ["recovery"] = (object) this.recovery
        };
      }
    }

    [Serializable]
    public class NoRoom
    {
      public override string ToString() => "NoRoom(" + ")";

      public Dictionary<string, object> ToJson() => new Dictionary<string, object>();
    }

    [Serializable]
    public class ReceivedMessage
    {
      public Peer.CommonHeader Header;
      public Exception Error;
      public AppPeer.Stat Stat;
      public AppPeer.Ready Ready;
      public AppPeer.LocateUnits LocateUnits;
      public AppPeer.GameInitialize GameInitialize;
      public AppPeer.TurnInitialize TurnInitialize;
      public AppPeer.MoveUnitRequest MoveUnitRequest;
      public AppPeer.ActionUnit ActionUnit;
      public AppPeer.WipedOut WipedOut;
      public AppPeer.FinishBattle FinishBattle;
      public AppPeer.Recovery Recovery;
      public AppPeer.NoRoom NoRoom;

      public override string ToString()
      {
        string str = string.Format("ReceivedMessage(Header={0}, ", (object) this.Header);
        if (this.Stat != null)
          str += this.Stat.ToString();
        if (this.Ready != null)
          str += this.Ready.ToString();
        if (this.LocateUnits != null)
          str += this.LocateUnits.ToString();
        if (this.GameInitialize != null)
          str += this.GameInitialize.ToString();
        if (this.TurnInitialize != null)
          str += this.TurnInitialize.ToString();
        if (this.MoveUnitRequest != null)
          str += this.MoveUnitRequest.ToString();
        if (this.ActionUnit != null)
          str += this.ActionUnit.ToString();
        if (this.WipedOut != null)
          str += this.WipedOut.ToString();
        if (this.FinishBattle != null)
          str += this.FinishBattle.ToString();
        if (this.Recovery != null)
          str += this.Recovery.ToString();
        if (this.NoRoom != null)
          str += this.NoRoom.ToString();
        return str + ")";
      }

      public void ThrowIfError()
      {
        if (this.Error != null)
          throw this.Error;
      }
    }

    [Serializable]
    public class SendMessage
    {
      public int SendId;
      public Exception Error;

      public override string ToString()
      {
        return string.Format("SendMessage(SendId={0}, Error={1})", (object) this.SendId, (object) this.Error);
      }

      public void ThrowIfError()
      {
        if (this.Error != null)
          throw this.Error;
      }
    }
  }
}
