﻿using MealPrep.Repository;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrep.Properties;

namespace MealPrep.Controller
{
    public class VitaminController
    {
        private VitaminDao vitaminDao;

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
            List<Vitamin> allVitamins = GetAllVitamins();
            return allVitamins.Exists(v => v.Name == vitamin.Name) || (vitamin.VitaminID > 0 && allVitamins.Exists(v => v.VitaminID == vitamin.VitaminID || v.Name == vitamin.Name));
        }

        public bool AddVitamin(Vitamin vitamin)
        {
            if (!VitaminExist(vitamin))
            {
                vitamin.VitaminID = vitamin.VitaminID > 0 ? vitamin.VitaminID : GetNextValidId();
                return vitaminDao.AddVitamin(vitamin);
            }
            else
            {
                throw new Exception(String.Format(Resources.ErrorVitaminAlreadyExistWithThisIdOrThisName, vitamin.VitaminID, vitamin.Name));
            }
        }

        private int GetNextValidId()
        {
            return GetAllVitamins().Max(v => v.VitaminID) + 1;
        }

        public DataTable GetTableAllVitamins()
        {
            List<Vitamin> vitamins = GetAllVitamins();
            DataTable vitaminTable = TableVitamin();
            foreach (Vitamin vitamin in vitamins.OrderBy(v => v.Name))
            {
                vitaminTable.Rows.Add(vitamin.VitaminID, vitamin.Name);
            }

            return vitaminTable;
        }

        public DataTable TableVitamin()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");

            return table;
        }
    }
}
