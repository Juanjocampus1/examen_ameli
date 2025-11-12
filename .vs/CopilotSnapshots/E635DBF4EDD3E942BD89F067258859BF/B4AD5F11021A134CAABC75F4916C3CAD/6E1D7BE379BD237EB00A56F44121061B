using Examen_DEWES_JuanJose_acebedo_lara2.Data.Repositorios;
using Examen_DEWES_JuanJose_acebedo_lara2.Models.Dto;
using Examen_DEWES_JuanJose_acebedo_lara2.Models.Entity;

namespace Examen_DEWES_JuanJose_acebedo_lara2.Servicios
{
    public class VentaService
    {
        private readonly IVentaRepository _repositorio;
        private const int STOCK_MINIMO = 10;

        public VentaService(IVentaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public List<VentaDTO> Listar()
        {
            var ventas = _repositorio.Listar();
            return ventas.Select(v => new VentaDTO
            {
                Id_venta = v.Id_venta,
                Producto = v.Producto,
                Cantidad = v.Cantidad,
                Precio = v.Precio
            }).ToList();
        }

        public List<VentaDTO> ListarPorProducto(string producto)
        {
            var ventas = _repositorio.ListarPorProducto(producto);
            return ventas.Select(v => new VentaDTO
            {
                Id_venta = v.Id_venta,
                Producto = v.Producto,
                Cantidad = v.Cantidad,
                Precio = v.Precio
            }).ToList();
        }

        public VentaDTO? ObtenerPorId(int id)
        {
            var venta = _repositorio.ObtenerPorId(id);
            if (venta == null) return null;

            return new VentaDTO
            {
                Id_venta = venta.Id_venta,
                Producto = venta.Producto,
                Cantidad = venta.Cantidad,
                Precio = venta.Precio
            };
        }

        public (bool exito, string mensaje) Crear(VentaDTO dto)
        {
            int stockActual = _repositorio.ObtenerStockPorProducto(dto.Producto);

            if (stockActual < STOCK_MINIMO)
            {
                return (false, $"Stock insuficiente. Stock actual: {stockActual}");
            }

            var venta = new Venta
            {
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio
            };

            _repositorio.Crear(venta);
            return (true, "Venta creada correctamente");
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }

        public List<string> ObtenerProductos()
        {
            return _repositorio.Listar()
                .Select(v => v.Producto)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
        }
    }
}
