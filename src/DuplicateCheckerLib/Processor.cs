//  Copyright (c) 2018, Jordi Corbilla
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

namespace DuplicateCheckerLib
{
    public class Processor
    {
        public List<Match> CloseFit;
        public List<Match> Exact;
        public List<Match> Similar;
        public List<Match> Different;
        private readonly List<Item> _repository;

        public Processor(List<Item> items)
        {
            CloseFit = new List<Match>();
            Exact = new List<Match>();
            Similar = new List<Match>();
            Different = new List<Match>();
            _repository = items;
        }

        public void FindDuplicates()
        {
            Dictionary<string, bool> keys = new Dictionary<string, bool>();

            //Loop through all the data
            //Highly cpu intensive
            foreach (Item left in _repository)
            {
                foreach (Item right in _repository)
                {
                    if (left.Id != right.Id)
                    {
                        string id1 = $"{left.Id}-{right.Id}";
                        string id2 = $"{right.Id}-{left.Id}";
                        //only unique values
                        if (!keys.TryGetValue(id1, out _) && !keys.TryGetValue(id2, out _))
                        {
                            //This will ensure that we only look at real matches and no duplicated entries
                            keys.Add(id1, true);
                            keys.Add(id2, true);

                            Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                            switch (cost.Type)
                            {
                                case MatchType.CloseFit:
                                    CloseFit.Add(cost);
                                    break;
                                case MatchType.Exact:
                                    Exact.Add(cost);
                                    break;
                                case MatchType.Similar:
                                    Similar.Add(cost);
                                    break;
                                case MatchType.Different:
                                    Different.Add(cost);
                                    break;
                            }

                        }
                    }
                }
            }
        }
    }
}
