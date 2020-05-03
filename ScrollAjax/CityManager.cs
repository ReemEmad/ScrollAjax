using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrollAjax
{
    public class CityManager
    {
        AjaxEntities ctx;
        public CityManager()
        {
            ctx = new AjaxEntities();
        }
        public List<City> GetAll()
        {
            return ctx.Cities.ToList();
        }

        public City GetById(int id)
        {
            return ctx.Cities.FirstOrDefault(c => c.id == id);
        }

        public List<City> getRange(int start, int end)
        {
            return ctx.Cities.OrderBy(c => c.id).Skip(start).Take(end - start).ToList();
        }   
    }
}