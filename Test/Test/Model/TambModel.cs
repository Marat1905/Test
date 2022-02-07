using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Dto;
using Test.Model.Data;

namespace Test.Model
{
   public static class TambModel
    {
        public static List<Tamb> GetAllTamb()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Tambs.Include(x=>x.Lab).ToList();
                return result;
            }
        }

        public static async Task<List<Tamb>> GetAllTambAsync()
        {
            return await Task.Run(() => GetAllTamb());
        }

        public static string NewCreatTamp()
        {
            string result = "Не смогли записать данные лабораторных показателей";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Tambs.Add(new Tamb
                {
                    WeightDryAct=1,
                    WeightDryRef=2,
                    WeightMainAct=3,
                    WeightMainRef=4
                    
                });

                db.SaveChanges();
                result = "Добавили лабораторные показатели";

            }
            return result;
        }

        public static string CreatLab(LabDto laborators)
        {
            string result = "Не смогли записать данные лабораторных показателей";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Labs.Add(new Lab
                {
                    BaseWeight = laborators.BaseWeight,
                    ProductBrand = laborators.ProductBrand,
                    BaseWeightLFace = laborators.BaseWeightLFace,
                    BaseWeightLMid = laborators.BaseWeightLMid,
                    TambId = laborators.TamId
                }) ;

                db.SaveChanges();
                result = "Добавили лабораторные показатели";

            }
            return result;
        }

        //Обновить лабораторные иследования
        public static string UpdateLab(LabDto laborators)
        {
            string result = "Не смогли обновить лабораторные показатели";
            using (ApplicationContext db = new ApplicationContext())
            {
                Lab Lab = db.Labs.FirstOrDefault(d => d.Id == laborators.Id);
                Lab.BaseWeight = laborators.BaseWeight;
                Lab.ProductBrand = laborators.ProductBrand;
                Lab.BaseWeightLFace = laborators.BaseWeightLFace;
                Lab.BaseWeightLMid = laborators.BaseWeightLMid;
                
                db.SaveChanges();
                result = "Обновили лабораторные показатели";
            }
            return result;
        }

    }
}
