using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinyoo.CrabyterDb.Models
{
    public class SVOPModel
    {
        public List<SVOPEventItem> Events { get; set; }

        public List<SVOPX> Labels { get; set; }

        public List<SVOPInspectItem> Inspects { get; set; }

        public SVOPModel()
        {
            this.Events = new List<SVOPEventItem>();
            this.Labels = new List<SVOPX>();
            this.Inspects = new List<SVOPInspectItem>();
        }
    }

    public class SVOPEventItem
    {
        public int Id { get; set; }

        public string Eventdate { get; set; }

        public int Eventtype { get; set; }

        public string Eventname { get; set; }

        public string Icon { get; set; }

        public string Desc { get; set; }

        public decimal Left { get; set; }

        public decimal Width { get; set; }

        public string Url { get; set; }
    }

    public class SVOPX
    {
        public string Label { get; set; }

        public decimal Left { get; set; }

    }

    public class SVOPInspectItem
    {
        public string Name { get; set; }

        public string Linecolor { get; set; }

        public int Linewidth { get; set; }

        public string Fillcolor { get; set; }

        public List<SVOPInspectItemData> Datas { get; set; }

        public SVOPInspectItem()
        {
            this.Linewidth = 2;
            this.Datas = new List<SVOPInspectItemData>();
        }
    }

    public class SVOPInspectItemData
    {
        public int Id { get; set; }

        public string Val { get; set; }

        public string Desc { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public string Active { get; set; }

        public SVOPInspectItemData()
        {
            this.Active = "0";
        }
    }
}
