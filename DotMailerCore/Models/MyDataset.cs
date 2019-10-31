using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Models
{
    public class Dataset
    {
        public IList<double> Data { get; set; }
    }

    public class MyDataset : Dataset
    {
        public new IList<Tuple<int, int>> Data { get; set; }
    }
}
