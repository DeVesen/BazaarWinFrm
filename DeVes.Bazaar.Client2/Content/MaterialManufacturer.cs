using DeVes.Bazaar.Client2.BasarComServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeVes.Bazaar.Client2.Content
{
    public class MaterialManufacturerProxi
    {
        private static readonly object LockObj = Guid.NewGuid();

        private static MaterialManufacturerProxi _instance;
        public static MaterialManufacturerProxi Instance
        {
            get
            {
                lock (MaterialManufacturerProxi.LockObj)
                {
                    return MaterialManufacturerProxi._instance;
                }
            }
        }


        private MaterialManufacturerProxi()
        { }


        public BizManufacturer MaterialManufacturerGet(Guid id)
        {
            return new BasarComClient().ManufacturerGet(id);
        }

        public BizManufacturer MaterialManufacturerGetByName(string name)
        {
            return this.MaterialManufacturerGetAll().FirstOrDefault(p => string.Compare(p.Designation, name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public BizManufacturer[] MaterialManufacturerGetAll()
        {
            return new BasarComClient().ManufacturerGetAll() ?? new BizManufacturer[0];
        }


        public bool MaterialManufacturerCreate(BizManufacturer manufacturer)
        {
            return new BasarComClient().ManufacturerCreate(manufacturer);
        }

        public bool MaterialManufacturerUpdate(BizManufacturer manufacturer)
        {
            return new BasarComClient().ManufacturerUpdate(manufacturer);
        }

        public bool MaterialManufacturerRemove(Guid manufacturerId)
        {
            return new BasarComClient().ManufacturerRemove(manufacturerId);
        }

        public bool MaterialManufacturerRemove(BizManufacturer manufacturer)
        {
            if (manufacturer == null) return false;

            return manufacturer.Id.HasValue && new BasarComClient().ManufacturerRemove(manufacturer.Id.Value);
        }


        public static void Inistialize()
        {
            lock (MaterialManufacturerProxi.LockObj)
            {
                MaterialManufacturerProxi._instance = new MaterialManufacturerProxi();
            }
        }
    }
}
