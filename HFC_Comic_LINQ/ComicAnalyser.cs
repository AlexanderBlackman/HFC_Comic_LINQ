using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HFC_Comic_LINQ
{
    static class ComicAnalyser
    {
        static private PriceRange CalculatePriceRange(Comic comic)
        {
            if (Comic.Prices[comic.Issue] > 100)
                return PriceRange.Expensive;
            else
                return PriceRange.Cheap;
        }

        static public IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            //sometimes it is best to first use var, and then use QA&R to get the explicit type for the returntype.
            var grouped =

                  from comic in comics
                  orderby prices[comic.Issue]
                  group comic by CalculatePriceRange(comic) into priceGroup
                  select priceGroup;
                

            return grouped;
        }

        static public IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review>reviews)
        {
            var joined =
                from comic in comics
                orderby comic.Issue
                join review in reviews
                on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
            return joined;
               


        }
    }
}
