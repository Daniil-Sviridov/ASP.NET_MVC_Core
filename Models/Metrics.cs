using System.Collections;

namespace MVC_study.Models
{
    public class Metrics : IMetrics
    {

        public int index = 0;

        public int metrics = 0;

        public int privacy = 0;

        public int products = 0;


        public void incindex()
        {
            index = ++index;
        }

        public void incmetrics()
        {
            metrics = ++metrics;
        }

        public void incprivacy()
        {
            privacy = ++privacy;
        }

        public void incproducts()
        {
            products = ++products;
        }
    }
}
