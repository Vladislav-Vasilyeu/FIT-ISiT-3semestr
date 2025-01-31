partial class Куст : Растение, ICloneable
{
    public Размеры Размеры { get; set; }
    public Типы_Растений Тип => Типы_Растений.Куст;
}