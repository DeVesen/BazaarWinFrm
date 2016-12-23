using System;
using System.Linq;
using DeVes.Bazaar.Client2.BasarComServiceReference;

namespace DeVes.Bazaar.Client2.Content
{
    public class MaterialCategoryProxi
    {
        private static readonly object LockObj = Guid.NewGuid();

        private static MaterialCategoryProxi _instance;
        public static MaterialCategoryProxi Instance
        {
            get
            {
                lock (MaterialCategoryProxi.LockObj)
                {
                    return MaterialCategoryProxi._instance;
                }
            }
        }


        private MaterialCategoryProxi()
        { }


        public BizMaterialCategory MaterialCategoryGet(Guid id)
        {
            return new BasarComClient().MaterialCategoryGet(id);
        }

        public BizMaterialCategory MaterialCategoryGetByName(string name)
        {
            return this.MaterialCategoryGetAll().FirstOrDefault(p => string.Compare(p.Designation, name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public BizMaterialCategory[] MaterialCategoryGetAll()
        {
            return new BasarComClient().MaterialCategoryGetAll() ?? new BizMaterialCategory[0];
        }


        public bool MaterialCategoryCreate(BizMaterialCategory category)
        {
            return new BasarComClient().MaterialCategoryCreate(category);
        }

        public bool MaterialCategoryUpdate(BizMaterialCategory category)
        {
            return new BasarComClient().MaterialCategoryUpdate(category);
        }

        public bool MaterialCategoryRemove(Guid manufacturerId)
        {
            return new BasarComClient().MaterialCategoryRemove(manufacturerId);
        }

        public bool MaterialCategoryRemove(BizMaterialCategory category)
        {
            if (category == null) return false;

            return category.Id.HasValue && new BasarComClient().MaterialCategoryRemove(category.Id.Value);
        }


        public static void Inistialize()
        {
            lock (MaterialCategoryProxi.LockObj)
            {
                MaterialCategoryProxi._instance = new MaterialCategoryProxi();
            }
        }
    }
}
