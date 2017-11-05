select isnull(event_xml.value('(./data[@name="batch_text"]/value)[1]', 'varchar(max)'), event_xml.value('(./data[@name="statement"]/value)[1]', 'varchar(max)')) TextData
, convert(varchar(23), dateadd(hh, datediff(hh, getutcdate(), current_timestamp), event_xml.value('(./@timestamp)', 'datetime2')), 21) StartTime
, event_xml.value('(./action[@name="database_name"]/value)[1]', 'varchar(128)') DatabaseName
from
(
	select x.object_name Type, convert(xml, event_data) event_data_xml
	from sys.fn_xe_file_target_read_file('{0}*.xel', null, null, null) x
) t
cross apply event_data_xml.nodes('//event') n (event_xml)
