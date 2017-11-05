{1}
declare @on bit
set @on = 1

-- SQL:BatchCompleted
exec sp_trace_setevent {0}, 12, 1, @on	-- TextData
exec sp_trace_setevent {0}, 12, 14, @on	-- StartTime
exec sp_trace_setevent {0}, 12, 35, @on	-- DatabaseName

-- RPC:Completed
exec sp_trace_setevent {0}, 10, 1, @on	-- TextData
exec sp_trace_setevent {0}, 10, 14, @on	-- StartTime
exec sp_trace_setevent {0}, 10, 35, @on	-- DatabaseName

exec sp_trace_setfilter {0}, 1, 0, 7, N'exec sp[_]reset[_]connection'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET STATISTICS IO ON'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET STATISTICS IO OFF'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET NO_BROWSETABLE ON'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET NO_BROWSETABLE OFF'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET ARITHABORT ON'
exec sp_trace_setfilter {0}, 1, 0, 7, N'SET ARITHABORT OFF'
exec sp_trace_setfilter {0}, 1, 0, 1, NULL

exec sp_trace_setstatus {0}, 1
