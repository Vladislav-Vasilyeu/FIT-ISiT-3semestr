select КЛИЕНТЫ.Наименование_фирмы_заказчика, (ЗАКАЗЫ.Количество * ТОВАРЫ.Цена) as [Цена заказа]
from ЗАКАЗЫ
inner join  КЛИЕНТЫ on ЗАКАЗЫ.id_клиента = КЛИЕНТЫ.id_клиента
inner join ТОВАРЫ on ТОВАРЫ.id_товара = ЗАКАЗЫ.id_товара
where (ЗАКАЗЫ.Количество * ТОВАРЫ.Цена) > 100000
order by [Цена заказа] desc

select КЛИЕНТЫ.Наименование_фирмы_заказчика, ЗАКАЗЫ.Количество
from ЗАКАЗЫ
inner join КЛИЕНТЫ on КЛИЕНТЫ.id_клиента = ЗАКАЗЫ.id_клиента
where ЗАКАЗЫ.Количество >= 10


create function ASDF(@товар nvarchar(20)) returns int
as
begin 
declare @id_товара int;
set @id_товара = (select ТОВАРЫ.id_товара from ТОВАРЫ where ТОВАРЫ.Наименование_товара = @товар);
declare @count_pokyp int = (select count(*) from ЗАКАЗЫ where ЗАКАЗЫ.id_товара = @id_товара);
return @count_pokyp;
end

declare @result int = dbo.ASDF('Стул');
print @result


drop function ASDF