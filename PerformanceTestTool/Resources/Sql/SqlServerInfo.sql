declare @ram sql_variant
select @ram = cfg.value
from sys.configurations cfg
where cfg.name = 'max server memory (MB)'

select i.cpu_count 'Logical CPU Count', i.hyperthread_ratio 'Hyperthread Ratio', i.cpu_count / i.hyperthread_ratio 'Physical CPU Count', i.{0} 'Physical Memory (MB)', @@version version, @ram ram
from sys.dm_os_sys_info i
