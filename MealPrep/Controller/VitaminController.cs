using MealPrep.Dao;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Controller
{
    public class VitaminController
    {
        private VitaminDao vitaminDao;
        private const string ERRO_VITAMIN_ALREADY_EXIST = "Vitamin already exist if this id {0} or this name {1}";

        public VitaminController(VitaminDao vitaminDao)
        {
            this.vitaminDao = vitaminDao;
        }

        public List<Vitamin> GetAllVitamins()
        {
            return vitaminDao.GetAllVitamins();
        }

        public bool VitaminExist(Vitamin vitamin)
        {
            return GetAllVitamins().Exists(v => v.VitaminID == vitamin.VitaminID || v.Name == vitamin.Name);
        }

        public bool AddVitamin(Vitamin vitamin)
        {
            if (!VitaminExist(vitamin))
            {
                return vitaminDao.AddVitamin(vitamin);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
