using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeVes.Bazaar.DataModel;

namespace DeVes.Bazaar.Server2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var _context = new BazaarStockSetContainer())
            {
                var _supplier = new Supplier()
                {
                    Number = 1,
                    Salutation = "Herr",
                    LastName = "Reichert"
                };
                _context.SupplierSet.Add(_supplier);

                _context.MaterialsSet.Add(new Materials()
                {
                    Number = 1,
                    SupplierNumber = 1,
                    MaterialName = "Hose",
                    PriceMin = 10
                });

                _context.SaveChanges();

                var _cont = _context;
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
