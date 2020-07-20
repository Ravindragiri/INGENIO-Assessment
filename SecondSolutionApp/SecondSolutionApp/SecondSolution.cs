using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6 {
    public class SecondSolution
    {
        public List<Result> GetSampleDataSet()
        {
            List<Result> result = new List<Result>() {
            new Result () {
                    CategoryId = 100,
                        ParentCategoryId = -1,
                        Name = "Business",
                        Keywords = "Money"
                },
                new Result () {
                    CategoryId = 200,
                        ParentCategoryId = -1,
                        Name = "Tutoring",
                        Keywords = "Teaching"
                },
                new Result () {
                    CategoryId = 101,
                        ParentCategoryId = 100,
                        Name = "Accounting",
                        Keywords = "Taxes"
                },
                new Result () {
                    CategoryId = 102,
                        ParentCategoryId = 100,
                        Name = "Taxation"
                },
                new Result () {
                    CategoryId = 201,
                        ParentCategoryId = 200,
                        Name = "Computer"
                },
                new Result () {
                    CategoryId = 103,
                        ParentCategoryId = 101,
                        Name = "Corporate Tax"
                },
                new Result () {
                    CategoryId = 202,
                        ParentCategoryId = 201,
                        Name = "Operating System"
                },
                new Result () {
                    CategoryId = 109,
                        ParentCategoryId = 101,
                        Name = "Small business Taxt"
                },
            };
            return result;
        }

        public IEnumerable<int> GetLevelResult(int level, IEnumerable<int> parentCategoryIds = null)
        {
            var results = default(IEnumerable<int>);
            var dataSet = GetSampleDataSet();
            if (dataSet != null)
            {
                if (parentCategoryIds == null || !parentCategoryIds.Any())
                {
                    results = dataSet.Where(e => e.ParentCategoryId == -1).Select(e => e.CategoryId);
                }
                else
                {
                    results = from d in dataSet
                              join catId in parentCategoryIds on d.ParentCategoryId equals catId
                              select d.CategoryId;
                }
                --level;
                if(level < 1 || results == null || !results.Any())
                {
                    return results;
                }
                return GetLevelResult(level, results);
            }
            return results;
        }
    }
}