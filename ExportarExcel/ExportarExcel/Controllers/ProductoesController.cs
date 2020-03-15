using ExportarExcel.Data;
using ExportarExcel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ExportarExcel.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descontinuado,FechaDaLanzamiento,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descontinuado,FechaDaLanzamiento,Precio")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ExportarExcel()
        {
            string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var productos = _context.Productos.AsNoTracking().ToList();
            
            using (var libro = new ExcelPackage())
            {
                libro.Workbook.Properties.Author = "Benjamín Camacho";
                libro.Workbook.Properties.Company = "aspnetcoremaster.com";
                libro.Workbook.Properties.Keywords = "Excel,Epplus";

                ExcelWorksheet hoja = libro.Workbook.Worksheets.Add("MiHoja de Excel");
                ExcelWorksheet copiaHoja = libro.Workbook.Worksheets.Add("copia",hoja);
                var hojaProductos = libro.Workbook.Worksheets.Add("Productos");

                hoja.Cells["A1"].Value = "Valor asignado desde C#";
                hoja.Cells["A1"].Style.Font.Color.SetColor(Color.Red);
                hoja.Cells["A1"].Style.Font.Name = "Calibri";
                hoja.Cells["A1"].Style.Font.Size = 40;


                hoja.Cells["B1"].Value = "2020/03/07";
                hoja.Cells["B1"].Style.Numberformat.Format = "dd/mm/aaaa";

                hojaProductos.Cells["A1"].LoadFromCollection(productos, PrintHeaders: true);
                
                
                for (var col = 1; col < productos.Count + 1; col++)
                {
                    hojaProductos.Column(col).AutoFit();
                }

                // Agregar formato de tabla
                var tabla = hojaProductos.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: productos.Count + 1, toColumn: 5), "Productos");
                tabla.ShowHeader = true;
                tabla.TableStyle = TableStyles.Light6;
                tabla.ShowTotal = true;
               
                return File(libro.GetAsByteArray(), excelContentType, "Productos.xlsx");
            }
        }
        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
