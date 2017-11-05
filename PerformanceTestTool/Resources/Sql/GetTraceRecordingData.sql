select t.TextData, convert(varchar(23), t.StartTime, 21) StartTime, t.DatabaseName
from fn_trace_gettable('{0}.trc', default) t
