//  Copyright (c) 2017, Jordi Corbilla
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are met:
//
//  - Redistributions of source code must retain the above copyright notice,
//    this list of conditions and the following disclaimer.
//  - Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//  - Neither the name of this library nor the names of its contributors may be
//    used to endorse or promote products derived from this software without
//    specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//  AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
//  ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
//  LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//  CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//  SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
//  INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
//  CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
//  POSSIBILITY OF SUCH DAMAGE.

using System.Collections.Generic;
using System.Data.SqlClient;
using DuplicateCheckerLib;

namespace DuplicateCheckerRunner
{
    public class DataRepository : IDataRepository
    {
        public List<Car> Get()
        {
            List<Car> list = new List<Car>
            {
                new Car {Id = 1, Name = "Caballero"},
                new Car {Id = 2, Name = "Cabrio"},
                new Car {Id = 3, Name = "Cabriolet"},
                new Car {Id = 4, Name = "Calais"},
                new Car {Id = 5, Name = "Camargue"},
                new Car {Id = 6, Name = "Camaro"},
                new Car {Id = 7, Name = "Camry"},
                new Car {Id = 8, Name = "Capri"},
                new Car {Id = 9, Name = "Caprice"},
                new Car {Id = 10, Name = "Caravan"},
                new Car {Id = 11, Name = "Caravana"},
                new Car {Id = 12, Name = "Caravelle"},
                new Car {Id = 13, Name = "Caravella"},
                new Car {Id = 14, Name = "Carry"},
                new Car {Id = 15, Name = "Catera"},
                new Car {Id = 16, Name = "Cattera"},
                new Car {Id = 17, Name = "Cavalier"},
                new Car {Id = 18, Name = "Cayenne"},
                new Car {Id = 19, Name = "Celebrity"},
                new Car {Id = 20, Name = "Celica"},
                new Car {Id = 21, Name = "Century"},
                new Car {Id = 22, Name = "Challenger"},
                new Car {Id = 23, Name = "Champ"},
                new Car {Id = 24, Name = "Charade"},
                new Car {Id = 25, Name = "Charade"}
            };

            return list;
        }

        public List<Item> GetComplex()
        {
            List<Item> list = new List<Item>
            {
                new Item {Id = 1, Name = "D&R Best-of – European Industries"},
                new Item {Id = 2, Name = "Bankhaus Neelmeyer Aktienstrategie"},
                new Item {Id = 3, Name = "HANSAINVEST LUX S.A."},
                new Item {Id = 4, Name = "Möller Feuerfesttechnik GmbH & Co. Kommanditgesellschaft"},
                new Item {Id = 5, Name = "SolarWorld Industries Sachsen GmbH"},
                new Item {Id = 6, Name = "Autohaus Klaus von der Weppen GmbH & Co. KG"},
                new Item {Id = 7, Name = "Wasser und Abwasser GmbH Boddenland"},
                new Item {Id = 8, Name = "PUTZMEISTER PAZARLAMA VE TICARET LIMITED SIRKETI"},
                new Item {Id = 9, Name = "Einig - Zenzen GmbH & Co KG."},
                new Item {Id = 10, Name = "Flossbach von Storch - Global Quality"},
                new Item {Id = 11, Name = "Flossbach von Storch - Global Convertible Bond"},
                new Item {Id = 12, Name = "Flossbach von Storch - Equity Opportunities"},
                new Item {Id = 13, Name = "Flossbach von Storch - Multiple Opportunities II"},
                new Item {Id = 14, Name = "Flossbach von Storch - Currency Diversification Bond"},
                new Item {Id = 15, Name = "Flossbach von Storch - Bond Opportunities"},
                new Item {Id = 16, Name = "Flossbach von Storch"},
                new Item {Id = 17, Name = "Flossbach von Storch - Bond Total Return"},
                new Item {Id = 18, Name = "Flossbach von Storch - Dividend"},
                new Item {Id = 19, Name = "Flossbach von Storch Invest S.A."},
                new Item {Id = 20, Name = "BD - Family Select"},
                new Item {Id = 21, Name = "HELIODOR Gerhausen GmbH & Co. KG"},
                new Item {Id = 22, Name = "Raiffeisen Bonds"},
                new Item {Id = 23, Name = "Raiffeisen World otvoreni investicijski fond s javnom ponudom"},
                new Item {Id = 24, Name = "Raiffeisen New Europe otvoreni investicijski fond s javnom ponudom"},
                new Item {Id = 25, Name = "Raiffeisen euroCash"},
                new Item {Id = 26, Name = "Raiffeisen Cash"},
                new Item {Id = 27, Name = "Raiffeisen Harmonic"},
                new Item {Id = 28, Name = "PUTZMEISTER MAKİNE SANAYİ VE TİCARET ANONİM ŞİRKETİ"},
                new Item {Id = 29, Name = "Raiffeisen Dynamic"},
                new Item {Id = 30, Name = "1. Energiefonds Saarpfalz GmbH & Co. KG"},
                new Item {Id = 31, Name = "Heinrich Carl Walter GmbH u. Co. KG"},
                new Item {Id = 32, Name = "VONTOBEL FUND - VONTOBEL FUND – UNCONVENTIONAL ENERGY"},
                new Item {Id = 33, Name = "VONTOBEL FUND - VONTOBEL FUND – GLOBAL CORPORATE BOND PRIME"},
                new Item {Id = 34, Name = "VONTOBEL FUND - VONTOBEL FUND – GLOBAL CORPORATE BOND CORE"},
                new Item {Id = 35, Name = "VONTOBEL FUND - VONTOBEL FUND – BOND MATURITY"},
                new Item {Id = 36, Name = "VONTOBEL FUND - VONTOBEL FUND – EMERGING MARKETS CORPORATE BOND"},
                new Item {Id = 37, Name = "Neunte Büttner Schiffahrtsgesellschaft mbH & Co. KG"},
                new Item {Id = 38, Name = "OWF Immobilien GmbH & Co. KG"},
                new Item {Id = 39, Name = "POLI-TAPE HOLDING GmbH"},
                new Item {Id = 40, Name = "Reuthwind GmbH & Co. KG"},
                new Item {Id = 41, Name = "POLI-TAPE Klebefolien GmbH"},
                new Item {Id = 42, Name = "MARANTEC Antriebs-und Steuerungstechnik GmbH & Co. KG"},
                new Item {Id = 43, Name = "CFT Hanseguss GmbH"},
                new Item {Id = 44, Name = "Lupus Imaging & Media GmbH & Co. KG"},
                new Item {Id = 45, Name = "MAD Recycling GmbH"},
                new Item {Id = 46, Name = "OWF GmbH & Co. KG"},
                new Item {Id = 47, Name = "SCI Seitz Consulting GmbH"},
                new Item {Id = 48, Name = "Nord-Real Invest GmbH & Co. KG"},
                new Item {Id = 49, Name = "Siempelkamp Tensioning Systems GmbH"},
                new Item {Id = 50, Name = "Condra Schiffahrts GmbH & Co. KG MS \"Ingrid\""},
                new Item {Id = 51, Name = "MS \"JRS CARINA\" Schiffahrtsgesellschaft mbH & Co. KG"},
                new Item {Id = 52, Name = "Siempelkamp Maschinen- und Anlagenbau GmbH"},
                new Item {Id = 53, Name = "MS Philemon Schifffahrtsgesellschaft mbH & Co. KG"},
                new Item {Id = 54, Name = "Dr. Lange & Partner GmbH & Co.KG"},
                new Item {Id = 55, Name = "Siempelkamp NIS Ingenieurgesellschaft mbH"},
                new Item {Id = 56, Name = "Streich Mode GmbH"},
                new Item {Id = 57, Name = "Falkenstein GmbH & Co.KG"},
                new Item {Id = 58, Name = "Glitzeria.de GmbH"},
                new Item {Id = 59, Name = "Siebte Büttner Schiffahrtsgesellschaft mbH & Co. KG"},
                new Item {Id = 60, Name = "AVG Abfallentsorgungs- und Verwertungsgesellschaft Köln mbH"},
                new Item {Id = 61, Name = "Justina GmbH & Co. KG"},
                new Item {Id = 62, Name = "Günnewig Holding GmbH & Co. KG"},
                new Item {Id = 63, Name = "Vier Wände GmbH"},
                new Item {Id = 64, Name = "Hotels in Potsdam & Neuss GmbH & Co. KG"},
                new Item {Id = 65, Name = "Streich Mode GmbH"},
                new Item {Id = 66, Name = "Falkenstein GmbH & Co.KG"},
                new Item {Id = 67, Name = "Glitzeria.de GmbH"},
                new Item {Id = 68, Name = "1. Energiefonds Saarpfalz GmbH & Co. KG."},
                new Item {Id = 69, Name = "Heinrich Carl Walter GmbH u. Co. KG."},
                new Item {Id = 70, Name = "VONTOBEL FUND - VONTOBEL FUND UNCONVENTIONAL ENERGY"},
                new Item {Id = 71, Name = "VONTOBEL FUND - VONTOBEL FUND GLOBAL CORPORATE BOND PRIME"}
            };
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

        public List<Item> LoadFromTable()
        {
            List<Item> items = new List<Item>();
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=xxx;Trusted_Connection=True;"))
            using (SqlCommand cmd = new SqlCommand("select id, name from x", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name"))
                            };
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }
    }
}
