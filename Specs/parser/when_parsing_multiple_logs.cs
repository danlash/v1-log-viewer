using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs.parser
{
	class when_parsing_multiple_logs : spec
	{
		private IEnumerable<ExceptionLog> _logs;

		#region LOG TEXT
		private const string LOGS = @"
==== /Motorola 2011-04-19 22:06:58 ====
VersionOne.Eventing.EventProcessingException: Error processing event: 
Task:395766:1419992,Member:268089,Changed, created 4/19/2011 9:47:03 PM, previous audit: 1419991; 
[no event asset captured]. ---> System.Data.SqlClient.SqlException: The query processor could not start the necessary thread resources for parallel query execution.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj)
   at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at System.Data.SqlClient.SqlDataReader.HasMoreRows()
   at System.Data.SqlClient.SqlDataReader.ReadInternal(Boolean setTimeout)
   at System.Data.SqlClient.SqlDataReader.Read()
   at VersionOne.Data.Sql2k.PreparedBatch.GetResult(SqlDataReader dr)
   at VersionOne.Data.Sql2k.PreparedBatch.Execute(SqlConnection cn, Int32 commandTimeout)
   at VersionOne.Data.Sql2k.DataStore.ExecuteWithRetry(PreparedBatch pb)
   at VersionOne.Data.Sql2k.DataStore.Execute(Batch batch)
   at VersionOne.Meta.SelectBuilder.VersionOne.ISelectStatement.Execute(IDataStore store)
   at VersionOne.Meta.SelectBuilder.VersionOne.ISelectStatement.Execute(IDataStore store, Oid oid)
   at VersionOne.Domain.Eventing.SubscriptionMatcher.GetUnfiltered(EventEntry eventEntry)
   at VersionOne.Eventing.QueueProcessorBase.ProcessEvent(EventEntry entry)
   at VersionOne.Eventing.BlockingQueueProcessor.ProcessingLoop()
   --- End of inner exception stack trace ---
--- Call Stack ---
   at VersionOne.Web.Util.ExceptionLogger.Log(Exception e)
   at VersionOne.Eventing.BlockingQueueProcessor.ProcessingLoop()
   at VersionOne.Eventing.BlockingQueueProcessor.StartProcessingInternal()
   at VersionOne.Eventing.QueueProcessorBase.StartProcessing()
   at System.Threading.ThreadHelper.ThreadStart_Context(Object state)
   at System.Threading.ExecutionContext.runTryCode(Object userData)
   at System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(TryCode code, CleanupCode backoutCode, Object userData)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.ThreadHelper.ThreadStart()
==== Build: 10.2.8001.95 ====

==== /Motorola 2011-04-19 22:06:58 ====
VersionOne.V1Exception: 
/*parameters*/ declare @p0$ int, @p1$ int, @p2$ varchar(8000), @p3$ bigint, @p4$ varchar(8000)
/*input*/ select @p0$=1419992, @p1$=395766, @p2$='Task', @p3$=9, @p4$='Member'
declare @p0 int,@p1 int,@p2 varchar(8000),@p3 bigint,@p4 varchar(8000)
select @p0=@p0$,@p1=@p1$,@p2=@p2$,@p3=@p3$,@p4=@p4$
create table #_B ([_E] int,[_D] int,[_A_ID] int,primary key([_E],[_D]))
set nocount on;set xact_abort off;begin tran;save tran TX
/* Task Selection */
begin
insert #_B([_E],[_D],[_A_ID])
select @p0,_A.[ID],_A.[ID]
from [Motorola].dbo.[Task] _A
where (_A.[AuditBegin]<=@p0 and (_A.[AuditEnd] is null or @p0<_A.[AuditEnd]) and (_A.[ID]=@p1 and _A.[AssetType]=@p2))
if @@ERROR<>0 goto ER
end
/* Task Projection */
select _G.[ID] [_I],_F.[_E] [_J],_G.[AssetType] [_S],_T.[AuditID] [_U]
from #_B _F
join [Motorola].dbo.[Task] _G on (_G.[AuditBegin]<=_F.[_E] and (_G.[AuditEnd] is null or _F.[_E]<_G.[AuditEnd]) and _G.[ID]=_F.[_D])
join [Motorola].dbo.[AssetAuditWithNext] _T on (_T.[ID]=_G.[ID] and _T.[AssetType]=@p2 and _T.[AuditID]<=_F.[_E] and (_T.[NextAuditID] is null or _F.[_E]<_T.[NextAuditID]))
/* Task.Viewers */
select _H.[_D] [_D],_H.[_E] [_E],_K.[ID] [_O],_K.[AssetType] [_P],_Q.[AuditID] [_R]
from #_B _H
join [Motorola].dbo.[Member] _K on (_K.[AuditBegin]<=_H.[_E] and (_K.[AuditEnd] is null or _H.[_E]<_K.[AuditEnd]) and 1=1)
join [Motorola].dbo.[AssetAuditWithNext] _Q on (_Q.[ID]=_K.[ID] and _Q.[AssetType]=@p4 and _Q.[AuditID]<=_H.[_E] and (_Q.[NextAuditID] is null or _H.[_E]<_Q.[NextAuditID]))
join [Motorola].dbo.[Task] _L on (_L.[AuditBegin]<=_H.[_E] and (_L.[AuditEnd] is null or _H.[_E]<_L.[AuditEnd]) and _L.[ID]=_H.[_A_ID])
join [Motorola].dbo.[BaseAsset] _M on (_M.[ID]=_L.[ID] and (_L.[AuditEnd] is null or _M.[AuditBegin]<_L.[AuditEnd]) and (_M.[AuditEnd] is null or _L.[AuditBegin]<_M.[AuditEnd]) and _M.[AuditBegin]<=_H.[_E] and (_M.[AuditEnd] is null or _H.[_E]<_M.[AuditEnd]))
left join [Motorola].dbo.[EffectiveACL] _N on (_N.[MemberID]=_K.[ID] and _N.[ScopeID]=_M.[SecurityScopeID])
where (isnull(_N.[RightsMask],0) & @p3)=@p3
goto OK;ER:rollback tran TX;OK:commit
drop table #_B
GO
 ---> System.Data.SqlClient.SqlException: The query processor could not start the necessary thread resources for parallel query execution.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj)
   at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at System.Data.SqlClient.SqlDataReader.HasMoreRows()
   at System.Data.SqlClient.SqlDataReader.ReadInternal(Boolean setTimeout)
   at System.Data.SqlClient.SqlDataReader.Read()
   at VersionOne.Data.Sql2k.PreparedBatch.GetResult(SqlDataReader dr)
   at VersionOne.Data.Sql2k.PreparedBatch.Execute(SqlConnection cn, Int32 commandTimeout)
   at VersionOne.Data.Sql2k.DataStore.ExecuteWithRetry(PreparedBatch pb)
   --- End of inner exception stack trace ---
--- Call Stack ---
   at VersionOne.Web.Util.ExceptionLogger.Log(Exception e)
   at VersionOne.Data.Sql2k.DataStore.ExecuteWithRetry(PreparedBatch pb)
   at VersionOne.Data.Sql2k.DataStore.Execute(Batch batch)
   at VersionOne.Meta.SelectBuilder.VersionOne.ISelectStatement.Execute(IDataStore store)
   at VersionOne.Meta.SelectBuilder.VersionOne.ISelectStatement.Execute(IDataStore store, Oid oid)
   at VersionOne.Domain.Eventing.SubscriptionMatcher.GetUnfiltered(EventEntry eventEntry)
   at VersionOne.Eventing.QueueProcessorBase.ProcessEvent(EventEntry entry)
   at VersionOne.Eventing.BlockingQueueProcessor.ProcessingLoop()
   at VersionOne.Eventing.BlockingQueueProcessor.StartProcessingInternal()
   at VersionOne.Eventing.QueueProcessorBase.StartProcessing()
   at System.Threading.ThreadHelper.ThreadStart_Context(Object state)
   at System.Threading.ExecutionContext.runTryCode(Object userData)
   at System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(TryCode code, CleanupCode backoutCode, Object userData)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.ThreadHelper.ThreadStart()
==== Build: 10.2.8001.95 ====
";
		#endregion

		public override void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();

			_logs = parser.Parse(LOGS.ToStream());
		}

		[Test]
		public void it_should_find_2_logs()
		{
			_logs.Count().should_be(2);
		}
	}
}
