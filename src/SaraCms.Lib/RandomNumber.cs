// ***********************************************************************
// Assembly         : SaraCms.Lib
// Author           : Michael Randall
// Created          : 06-01-2015
//
// Last Modified By : Michael Randall
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="RandomNumber.cs" company="Randall Web Design">
//     Copyright © Randall Web Design 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace SaraCms.Lib
{
    using System;
    public class RandomNumber
    {
        private static readonly Random Global = new Random();
        [ThreadStatic]
        private static Random _local;

        public int Next(int max)
        {
            var localBuffer = _local;
            if (localBuffer == null)
            {
                int seed;
                lock (Global) seed = Global.Next();
                localBuffer = new Random(seed);
                _local = localBuffer;
            }
            return localBuffer.Next(max);
        }

        public int Next(int min, int max)
        {
            var localBuffer = _local;
            if (localBuffer == null)
            {
                int seed;
                lock (Global) seed = Global.Next();
                localBuffer = new Random(seed);
                _local = localBuffer;
            }
            return localBuffer.Next(min, max);
        }
    }
}
