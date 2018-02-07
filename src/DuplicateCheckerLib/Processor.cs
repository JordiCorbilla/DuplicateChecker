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
        public List<Match> closeFit;
        public List<Match> exact;
        public List<Match> similar;
        public List<Match> different;
        private List<Item> repository;

        public Processor(List<Item> items)
        {
            closeFit = new List<Match>();
            exact = new List<Match>();
            similar = new List<Match>();
            different = new List<Match>();
            repository = items;
        }

        public void FindDuplicates()
        {
            Dictionary<string, bool> keys = new Dictionary<string, bool>();

            //Loop through all the data
            //Highly cpu intensive
            int count = 0;
            foreach (Item left in repository)
            {
                foreach (Item right in repository)
                {
                    if (left.Id != right.Id)
                    {
                        string Id1 = $"{left.Id}-{right.Id}";
                        string Id2 = $"{right.Id}-{left.Id}";
                        bool value;
                        //only unique values
                        if (!keys.TryGetValue(Id1, out value) && !keys.TryGetValue(Id2, out value))
                        {
                            //This will ensure that we only look at real matches and no duplicated entries
                            keys.Add(Id1, true);
                            keys.Add(Id2, true);

                            Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                            count++;
                            switch (cost.Type)
                            {
                                case MatchType.closefit:
                                    closeFit.Add(cost);
                                    break;
                                case MatchType.exact:
                                    exact.Add(cost);
                                    break;
                                case MatchType.similar:
                                    similar.Add(cost);
                                    break;
                                case MatchType.different:
                                    different.Add(cost);
                                    break;
                            }

                        }
                    }
                }
            }
        }
    }
}
