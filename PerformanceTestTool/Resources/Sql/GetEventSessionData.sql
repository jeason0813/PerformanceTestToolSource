select isnull(event_xml.value('(./data[@name="batch_text"]/value)[1]', 'varchar(max)'), event_xml.value('(./data[@name="statement"]/value)[1]', 'varchar(max)')) TextData
, event_xml.value('(./data[@name="logical_reads"]/value)[1]', 'bigint') Reads
, event_xml.value('(./data[@name="writes"]/value)[1]', 'bigint') Writes
, event_xml.value('(./data[@name="cpu_time"]/value)[1]', 'bigint') CPU
, event_xml.value('(./data[@name="row_count"]/value)[1]', 'bigint') RowCounts
, event_xml.value('(./data[@name="duration"]/value)[1]', 'bigint') / 1000 Duration
, convert(varchar(23), dateadd(hh, datediff(hh, getutcdate(), current_timestamp), event_xml.value('(./@timestamp)', 'datetime2')), 21) StartTime
from
(
	select x.object_name Type, convert(xml, event_data) event_data_xml
	from sys.fn_xe_file_target_read_file('{0}*.xel', null, null, null) x
) t
cross apply event_data_xml.nodes('//event') n (event_xml)
