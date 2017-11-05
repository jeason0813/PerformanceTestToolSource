select p.object_name ObjectName, p.counter_name CounterName, p.instance_name InstanceName, p.cntr_value Value
from sys.dm_os_performance_counters p
