select �������.������������_�����_���������, (������.���������� * ������.����) as [���� ������]
from ������
inner join  ������� on ������.id_������� = �������.id_�������
inner join ������ on ������.id_������ = ������.id_������
where (������.���������� * ������.����) > 100000
order by [���� ������] desc

select �������.������������_�����_���������, ������.����������
from ������
inner join ������� on �������.id_������� = ������.id_�������
where ������.���������� >= 10


create function ASDF(@����� nvarchar(20)) returns int
as
begin 
declare @id_������ int;
set @id_������ = (select ������.id_������ from ������ where ������.������������_������ = @�����);
declare @count_pokyp int = (select count(*) from ������ where ������.id_������ = @id_������);
return @count_pokyp;
end

declare @result int = dbo.ASDF('����');
print @result


drop function ASDF