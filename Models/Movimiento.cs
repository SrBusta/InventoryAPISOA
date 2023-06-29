namespace InventoryAPI.Models
{

    public class Movimiento
    {
        public int id {get; set;}
        public int producto_id { get; set;}
        public string tipo_movimiento { get; set;}
        public int cantidad { get; set; }
        public DateOnly fecha_movimiento { get; set; }
        public int usuario_id { get; set; }

    }
}
