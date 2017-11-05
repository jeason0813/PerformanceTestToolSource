declare @on bit
set @on = 1

-- SQL:BatchCompleted
exec sp_trace_setevent {0}, 12, 1, @on	-- TextData
exec sp_trace_setevent {0}, 12, 14, @on	-- StartTime
exec sp_trace_setevent {0}, 12, 16, @on	-- Reads
exec sp_trace_setevent {0}, 12, 17, @on	-- Writes
exec sp_trace_setevent {0}, 12, 18, @on	-- CPU
exec sp_trace_setevent {0}, 12, 48, @on	-- RowCounts
exec sp_trace_setevent {0}, 12, 13, @on	-- Duration

exec sp_trace_setstatus {0}, 1
