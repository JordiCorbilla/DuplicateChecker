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

using System;

namespace DuplicateCheckerLib
{
    public class LevenshteinDistance
    {
        public static int Get(string left, string right)
        {
            int leftLength = left.Length;
            int rightLength = right.Length;

            //Build the matrix for both words
            int[,] matrix = new int[leftLength + 1, rightLength + 1];

            // Base case, return the length of the strings
            if (leftLength == 0)
                return rightLength;

            if (rightLength == 0)
                return leftLength;

            //Populate the first column and first row
            for (int i = 0; i <= leftLength; i++)
                matrix[i, 0] = i;

            for (int j = 0; j <= rightLength; j++)
                matrix[0, j] = j;

            // Calculate the distance
            for (int i = 1; i <= leftLength; i++)
            {
                //Loop throgh each character
                for (int j = 1; j <= rightLength; j++)
                {
                    // Calculate the cost
                    int cost = (right[j - 1] == left[i - 1]) ? 0 : 1;

                    // set the value
                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
                }
            }
            // Return the last item that contains the calculation
            return matrix[leftLength, rightLength];
        }
    }
}
