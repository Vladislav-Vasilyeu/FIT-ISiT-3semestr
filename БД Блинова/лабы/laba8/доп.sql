CREATE VIEW vw_�������_����������_�_������� AS
SELECT 
    COALESCE(�������.������������_�����_���������, '��� �������') AS ������,
    COALESCE(������.������������_������, '��� ������') AS �����,
    SUM(������.����������) AS [����� ���������� �������],
    SUM(������.���������� * ������.����) AS [����� ����� �������]
FROM 
    ������
INNER JOIN 
    ������� ON ������.id_������� = �������.id_�������
INNER JOIN 
    ������ ON ������.id_������ = ������.id_������
GROUP BY 
    CUBE(�������.������������_�����_���������, ������.������������_������);

	SELECT * from vw_�������_����������_�_�������