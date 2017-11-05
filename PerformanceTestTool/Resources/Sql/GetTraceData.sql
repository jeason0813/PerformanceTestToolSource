select t.TextData, t.Reads, t.Writes, t.CPU, t.RowCounts, t.Duration / 1000 Duration, convert(varchar(23), t.StartTime, 21) StartTime
from fn_trace_gettable('{0}.trc', default) t
