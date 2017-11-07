using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateCheckerRunner
{
    public class DataRepository
    {
        public List<string> Get()
        {
            List<string> list = new List<string>();

            list.Add("Caballero");
            list.Add("Cabrio");
            list.Add("Cabriolet");
            list.Add("Calais");
            list.Add("Camargue");
            list.Add("Camaro");
            list.Add("Camry");
            list.Add("Capri");
            list.Add("Caprice");
            list.Add("Caravan");
            list.Add("Caravana");
            list.Add("Caravelle");
            list.Add("Caravella");
            list.Add("Carry");
            list.Add("Catera");
            list.Add("Cattera");
            list.Add("Cavalier");
            list.Add("Cayenne");
            list.Add("Celebrity");
            list.Add("Celica");
            list.Add("Century");
            list.Add("Challenger");
            list.Add("Champ");
            list.Add("Charade");
            return list;
        }

        public List<string[]> GetAll()
        {
            List<string[]> l = new List<string[]>
            {
                new[]{"Coca Cola", "Coca Cola Ltd."},
                new[]{"Method", "Methods"},
                new[]{"Potato", "Ketchup"},
                new[]{"Potato", "Potato mix"},
                new[]{"Tarakan", "Potato mix"},
                new[]{"Tenggarong", "Gorontalo"},
                new[]{"Ambon", "Makasar"},
                new[]{"Tual", "Manado"},
                new[]{"Ternate", "Palu"},
                new[]{"Tidore", "Pare-Pare"},
                new[]{"Bima", "Palopo"},
                new[]{"Mataram", "Tomohon"},
                new[]{"Kupang", "Banda Aceh"},
                new[]{"Atambua", "Potato mix"},
                new[]{"Jayapura", "Potato mix"},
                new[]{"Merauke", "Mera-uke"},
                new[]{"Kota Sorong", "Potato mix"},
                new[]{"Monokwari", "Potato mix"},
                new[]{"Bau-Bau", "Potato mix"},
                new[]{"Bitung", "Potato mix"}
            };
            return l;
        }
    }
}
