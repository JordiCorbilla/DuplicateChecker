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

namespace DuplicateCheckerRunner
{
    public class DataRepository
    {
        public List<Car> Get()
        {
            List<Car> list = new List<Car>();

            list.Add(new Car { Id = 1, Name = "Caballero" });
            list.Add(new Car { Id = 2, Name = "Cabrio" });
            list.Add(new Car { Id = 3, Name = "Cabriolet" });
            list.Add(new Car { Id = 4, Name = "Calais" });
            list.Add(new Car { Id = 5, Name = "Camargue" });
            list.Add(new Car { Id = 6, Name = "Camaro" });
            list.Add(new Car { Id = 7, Name = "Camry" });
            list.Add(new Car { Id = 8, Name = "Capri" });
            list.Add(new Car { Id = 9, Name = "Caprice" });
            list.Add(new Car { Id = 10, Name = "Caravan" });
            list.Add(new Car { Id = 11, Name = "Caravana" });
            list.Add(new Car { Id = 12, Name = "Caravelle" });
            list.Add(new Car { Id = 13, Name = "Caravella" });
            list.Add(new Car { Id = 14, Name = "Carry" });
            list.Add(new Car { Id = 15, Name = "Catera" });
            list.Add(new Car { Id = 16, Name = "Cattera" });
            list.Add(new Car { Id = 17, Name = "Cavalier" });
            list.Add(new Car { Id = 18, Name = "Cayenne" });
            list.Add(new Car { Id = 19, Name = "Celebrity" });
            list.Add(new Car { Id = 20, Name = "Celica" });
            list.Add(new Car { Id = 21, Name = "Century" });
            list.Add(new Car { Id = 22, Name = "Challenger" });
            list.Add(new Car { Id = 23, Name = "Champ" });
            list.Add(new Car { Id = 24, Name = "Charade" });
            list.Add(new Car { Id = 25, Name = "Charade" });
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
